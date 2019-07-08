using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public static CloudSpawner instance;
    private class DifficultyUtil
    {
        // TODO
    }
    public void DifficultyAdjustMent(params object[] data)
    {
        /*
             At least one argument is expected.
             The argument is expected to be an int, indecating what operation should be carried out.
             
             if the 1st argument == 0 then : 
                -> there should be 1 more argument, which must be a float, indicating the probability of spawning a dark-cloud durring a game.

             if the 1st argument == 1 then : 
                -> there should be 2 more arguments (an int and a float respectively), the first being the target-number of clouds and the second
                   being the distance between clouds.
                   (note : the current implementation of this assumes that this method is being called AFTER PlacePlayerOverFirstCloud
                    has been called once and BEFORE any more clouds have been planned, which is why the current y-position value of the cloud
                    planer must be adjusted below)
         */


        Debug.Assert(data.Length >= 1);
        int c = (int)data[0];
        float f0 = 0f, f1 = 0f;
        switch (c)
        {
            case 0:
                Debug.Assert(data.Length == 2);
                f0 = (float)data[1];
                f0 = Mathf.Clamp(f0, 0, 1);
                CloudPlanner.SetLuck(1 - f0);
                break;
            case 1:
                Debug.Assert(data.Length == 3);
                cloudCountTarget = (int)data[1];
                f0 = (float)data[2];
                f1 = CloudPlanner.GetY() + CloudPlanner.DeltaY - f0;
                CloudPlanner.SetDeltaY(f0);
                CloudPlanner.SetY(f1);
                break;
        }
    }


    private int count=0;
    private class CloudPlan {
        public float Y_pos { get; private set; }
        public float X_frac { get; private set; }
        public int Section { get; private set; }
        public bool IsDark { get; private set; }
        public CloudPlan() {
            Y_pos = 0f;
            X_frac = 0f;
            Section = 0;
            IsDark = false;
        }
        public CloudPlan(float x, float y, int sec, bool isd)
        {
            X_frac = x;
            Y_pos = y;
            Section = sec%4;
            IsDark = isd;
        }
    }
    private class CloudPlanner {
        private static bool lastWasDark = false;
        private static float currentY = 0f;
        private static int currentSection = 0;
        private static int currentSectionDir = 1;
        private static void currentSectionInc() {
            Debug.Assert(currentSection>=0 && currentSection<=3 && (currentSectionDir==-1 || currentSectionDir==1));
            currentSection += currentSectionDir;
            if (currentSection == -1 || currentSection == 4)
            {
                currentSectionDir *= -1;
                currentSection += (2 * currentSectionDir);
            }
        }
        private static float deltaY = 5f;
        private static float luckFactor = .5f;
        public static void SetY(float y) { currentY = y; }
        public static float GetY() { return currentY; }
        public static void SetSection(int s) { currentSection = s % 4; }
        public static void SetDeltaY(float d) { deltaY = d; }
        public static void SetLuck(float l) { luckFactor = l; }
        public static void SetLWD(bool lwd)  { lastWasDark = lwd; }
        public static float DeltaY { get { return deltaY; } }
        public static CloudPlan PlanCloud() {
            float xf = Random.Range(0f, 1f);
            float yp = currentY;
            int se = currentSection;
            bool isd = false;
            if (!lastWasDark)
            {
                float r = Random.Range(0f, 1f);
                isd = r > luckFactor;
            }
            lastWasDark = isd;
            currentY -= deltaY;
            currentSection = (currentSection + 1) % 4;

            CloudPlan cp = new CloudPlan(xf, yp, se, isd);
            return cp;
        }
        public static CloudPlan PlanCloud(Queue<CloudPlan> cloudPlans) {
            CloudPlan cp = PlanCloud();
            cloudPlans.Enqueue(cp);
            return cp;
        }
    }
    private void MakeCloud_tool(CloudPlan cloudPlan, float xleftBound, float width, int choice)
    {
        float sliceWidth = width / 4;
        float sliceleftBound = xleftBound + cloudPlan.Section * sliceWidth;
        float xpos = sliceleftBound + cloudPlan.X_frac * sliceWidth;
        float ypos = cloudPlan.Y_pos;
        GameObject cloud;
        if (cloudPlan.IsDark)
        {
            cloud = Instantiate(darkCloud);
        }
        else
        {
            cloud = Instantiate(clouds[choice % clouds.Length]);
        }

        cloud.name = string.Format("cld({0})", count++);

        cloud.transform.position = new Vector2(xpos,ypos);

        if (!cloudPlan.IsDark)
        {
            collectiblesManager.MakeCollectable(new Vector2(xpos + cloudWidth / 4, ypos + .4f));
        }

        cloudManager.ReportClouds(1);
    }
    private void MakeCloud_tool(CloudPlan cloudPlan, float xleftBound, float width)
    {
        int c = Random.Range(0,clouds.Length);
        MakeCloud_tool(cloudPlan,xleftBound,width,c);
    }

    [SerializeField]
    private int cloudCountTarget = 5;

    [SerializeField]
    private Collectibles collectiblesManager;

    private CloudManager cloudManager;

    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject darkCloud;

    private Queue<CloudPlan> cloudPlans;
    private float camLeftBound = 0f, camWidth = 0f;
    private float cloudWidth = 0f;
    private void ComputeWidthAndBound() {
        /*
         trueH = 2 * camOrthSize
         pixSize = trueH / sc.h
         W.pixC = sc.W * cam.rect.W
         trueW = W.pixC * pixSize
               = (sc.W * cam.rect.W) * (trueH / sc.h)
               = (sc.W * cam.rect.W) * (2 * camOrthSize / sc.h)
               =  (2 * sc.W * cam.rect.W * camOrthSize) / sc.h
         */
        float computeCloudWidth() {
            float getWidth(int i) {
                GameObject obj = i < 0 ? darkCloud : clouds[i];
                return obj.GetComponent<SpriteRenderer>().sprite.bounds.extents.x * 2;
            }
            float sum = 0f;
            for (int i = -1; i < clouds.Length; i++) sum += getWidth(i);
            return sum/(clouds.Length+1);
        }
        cloudWidth = computeCloudWidth();
        camWidth = (2f * Screen.width * Camera.main.rect.width * Camera.main.orthographicSize) / (Screen.height);
        camLeftBound = Camera.main.transform.position.x - camWidth / 2;
        camWidth -= cloudWidth; // account for width of clouds
    }
    private void PlacePlayerOverFirstCloud() {
        // this should only be called AFTER ComputeWidthAndBound has been called
        
        // get objects and values
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        var sbe = clouds[0].GetComponent<SpriteRenderer>().sprite.bounds.extents; // sbe:=sprite.bounds.extents
        float playerYpos = player.transform.position.y;
        float cloudHeight = sbe.y * 2;
        float cloudWidth = sbe.x * 2;

        // set up the CloudPlanner
        CloudPlanner.SetY(playerYpos - cloudHeight);
        CloudPlanner.SetLWD(true);
        CloudPlanner.SetSection( Random.Range(0,4) );

        // plan first cloud
        CloudPlan cloudPlan = CloudPlanner.PlanCloud();

          

        // move the player to stand where the cloud will be
        Vector2 vector = player.transform.position;
        vector.x = camLeftBound + ((cloudPlan.Section + cloudPlan.X_frac) * (camWidth / 4)) + cloudWidth/4;
        player.transform.position = vector;

        // create and add cloud
        MakeCloud_tool(cloudPlan, camLeftBound, camWidth, 0);
    }

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        cloudManager = transform.GetComponentInParent<CloudManager>();
        cloudPlans = new Queue<CloudPlan>();
        ComputeWidthAndBound();
        PlacePlayerOverFirstCloud();

        Test();
    }

    // Update is called once per frame
    void Update()
    {
        MaintainClouds();
    }
    
    private void MaintainClouds() {
        const int qtarget = 30;
        while (cloudPlans.Count < qtarget)
            CloudPlanner.PlanCloud(cloudPlans);
        while (cloudManager.CloudCount < cloudCountTarget)
        {
            if (cloudPlans.Count == 0) break;
            MakeCloud_tool(cloudPlans.Dequeue() , camLeftBound, camWidth);
        }
    }
    private void Test() {
        IEnumerable<GameObject> allClouds() {
            yield return darkCloud;
            foreach (GameObject cld in clouds) yield return cld;
        }
        float sum=0, cur=0;
        int c=0;
        foreach (GameObject cld in allClouds())
        {
            c++;
            cur = ComputeWidth(cld);
          //  Debug.Log(string.Format("({0}:{1})",cld.name,cur));
            sum += cur;
        }
     //   Debug.Log(string.Format("ave={0}",sum/c));
    }
    private float ComputeWidth(GameObject obj)
    {
        Sprite sprite = obj.GetComponent<SpriteRenderer>().sprite;
        return 2*sprite.bounds.extents.x;
        
    }
}
