using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
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
        private static float deltaY = 5f;
        private static float luckFactor = .5f;
        public static void SetY(float y) { currentY = y; }
        public static void SetSection(int s) { currentSection = s % 4; }
        public static void SetDeltaY(float d) { deltaY = d; }
        public static void SetLuck(float l) { luckFactor = l; }
        public static void SetLWD(bool lwd)  { lastWasDark = lwd; }
        public static float DeltaY { get { return deltaY; } }
        public static void PlanCloud(Queue<CloudPlan> cloudPlans) {
            float xf = Random.Range(0f, 1f);
            float yp = currentY;
            int se = currentSection;
            bool isd = false;
            if (!lastWasDark)
            {
                float r = Random.Range(0f,1f);
                isd = r > luckFactor;
            }
            lastWasDark = isd;
            currentY -= deltaY;
            currentSection = (currentSection + 1) % 4;

            CloudPlan cp = new CloudPlan(xf,yp,se,isd);
            cloudPlans.Enqueue(cp);
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
        cloudManager.ReportClouds(1);
    }
    private void MakeCloud_tool(CloudPlan cloudPlan, float xleftBound, float width)
    {
        int c = Random.Range(0,clouds.Length-1);
        MakeCloud_tool(cloudPlan,xleftBound,width,c);
    }

    [SerializeField]
    private int cloudCountTarget = 5;

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
    private void PlaceFirstCloudUnderPlayer() {
        // this should only be called AFTER ComputeWidthAndBound has been called
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // compute initial cloud info
        float xpos = 0, ypos = 0; int sec = 0;
        {
            // compute initial cloud info
            float w = camWidth / 2;
            float b = camLeftBound;
            if (player.transform.position.x >= w + b)
            {
                sec += 2; b += w;
            }
            w /= 2;
            if (player.transform.position.x >= w + b)
            {
                sec += 1;
            }
            xpos = player.transform.position.x - cloudWidth / 2;
            ypos = player.transform.position.y - 3;
        }

        // create and add cloud
        {
            GameObject cloud = Instantiate(clouds[0]);
            cloud.transform.position = new Vector2(xpos,ypos);
        }

        // reset the cloud-planner
        CloudPlanner.SetY(ypos - CloudPlanner.DeltaY);
        CloudPlanner.SetSection( (sec+1)%4 );
    }

    // Start is called before the first frame update
    void Start()
    {
        cloudManager = transform.GetComponentInParent<CloudManager>();
        cloudPlans = new Queue<CloudPlan>();
        ComputeWidthAndBound();
        PlaceFirstCloudUnderPlayer();

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
            Debug.Log(string.Format("({0}:{1})",cld.name,cur));
            sum += cur;
        }
        Debug.Log(string.Format("ave={0}",sum/c));
    }
    private float ComputeWidth(GameObject obj)
    {
        Sprite sprite = obj.GetComponent<SpriteRenderer>().sprite;
        return 2*sprite.bounds.extents.x;
        
    }
}
