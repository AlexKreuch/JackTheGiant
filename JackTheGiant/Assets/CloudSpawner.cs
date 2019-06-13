using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
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
    private void MakeCloud_tool(CloudPlan cloudPlan, float xleftBound, float width)
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
            int i = Random.Range(0,clouds.Length-1);
            cloud = Instantiate(clouds[i]);
        }
        cloud.transform.position = new Vector2(xpos,ypos);
        cloudManager.ReportClouds(1);
    }

    [SerializeField]
    private int cloudCountTarget = 5;

    private CloudManager cloudManager;

    [SerializeField]
    private GameObject[] clouds;
    [SerializeField]
    private GameObject darkCloud;

    private Queue<CloudPlan> cloudPlans;

    // Start is called before the first frame update
    void Start()
    {
        cloudManager = transform.GetComponentInParent<CloudManager>();
        cloudPlans = new Queue<CloudPlan>();
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
            MakeCloud_tool(cloudPlans.Dequeue() , 0, 5);
        }
    }
}
