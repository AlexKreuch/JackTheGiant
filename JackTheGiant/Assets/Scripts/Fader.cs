using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public static Fader instance;

    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start() {
        Animator animator = GetComponentInChildren<Animator>();
        bool b = ReportStatus(animator,"theAnimator");
        if (b)
        {
            GameObject obj = animator.gameObject;
            ReportStatus(obj,"animatorHost");
        }

    }

    private bool ReportStatus(Object obj, string title) {
        bool res = obj != null;
        if (res) Debug.Log(string.Format("{0} found | name == {1}", title, obj.name));
        else Debug.Log(title + " not-found");
        return res;
    }

    private const string triggerName = "StartFadeCycle";

    private void StartFader() {
        Animator animator = GetComponentInChildren<Animator>();
        animator.SetTrigger(triggerName);
        CFFC.SetTag();
    }

   

    private void ButtonCheck(ref bool btn, System.Action func) {
        if (btn)
        {
            btn = false;
            func();
        }
    }

    public bool btn = false;

    #region test pausing fader
    private void TestFader()
    {
        Animator animator = GetComponentInChildren<Animator>();
        if (animator.speed == 0) animator.speed = 1;
        else
        {
            PauseTime = Mathf.Clamp(PauseTime, 0f, 3f);
            StartCoroutine(util00(PauseTime + Time.realtimeSinceStartup, animator));
            animator.SetTrigger(triggerName);
            CFFC.SetTag();
        }
    }
    public bool PauseThis = false;
    public float PauseTime = 0f;
   
    private IEnumerator util00(float endTime,Animator animator) {
        while (Time.realtimeSinceStartup < endTime) yield return null;
        animator.speed = 0f;
    }
    #endregion


    #region search test code
    private Stack<bool> Record = new Stack<bool>();
    private float pivot = .5f;
    private void Step(bool x) {
        if (x) PauseTime += pivot;
        pivot /= 2;
        Record.Push(x);
    }

    private void press_0_btn() { Step(false); }
    private void press_1_btn() { Step(true); }
    private void press_B_btn() {
        
        if (Record.Count == 0) return;
        pivot *= 2;
        if (Record.Pop()) PauseTime -= pivot;

    }

    public bool press0 = false;
    public bool press1 = false;
    public bool pressB = false;
    public int cursor = 0;
    #endregion

    #region try to catch discontinuity
    // CFFC := Check For Fast Change
    class CFFC {
        private static int State = 0;
        private static Image image = null;
        private static float LastTime_a = 0f;
        private static float LastTime_b = 0f;
        private static float LastOp_a = 0f;
        private static float LastOp_b = 0f;

        private static float TimeTag = 0f;
        public static void SetTag() { TimeTag = Time.realtimeSinceStartup; }

        private static void StartStep_0() {
            State = 1;
            image = Fader.instance.GetComponentInChildren<Image>();
            LastTime_a = Time.realtimeSinceStartup;
            LastOp_a = image.color.a;
        }
        private static void StartStep_1() {
            State = 2;
            LastTime_b = Time.realtimeSinceStartup;
            LastOp_b = image.color.a;
            CheckForIssue();
        }
        private static void Step()
        {
            LastTime_a = LastTime_b;
            LastOp_a = LastOp_b;
            LastTime_b = Time.realtimeSinceStartup;
            LastOp_b = image.color.a;
            CheckForIssue();
        }
        private static void CheckForIssue() {
            float dif = Mathf.Abs( LastOp_a - LastOp_b );
            if (dif > Tol)
            {

                float tst = LastTime_a - TimeTag; // tst := Time Since Tag
                Debug.Log(string.Format("discontinuity Found : {0}->{1} at {2} | timer={3}",LastOp_a,LastOp_b,LastTime_b,tst));

            }
        }

        private static float Tol = 0f;

        public static void Update(float tolerance) {
            Tol = tolerance;
            switch (State)
            {
                case 0: StartStep_0(); break;
                case 1: StartStep_1(); break;
                case 2: Step(); break;
            }
        }
        
    }
    public float tol = .85f;
    public void asdf() {
        Animator animator = GetComponentInChildren<Animator>();
    }
    #endregion
    void Update() {
        ButtonCheck(ref btn , StartFader);
        ButtonCheck(ref PauseThis, TestFader);
        ButtonCheck(ref press0, press_0_btn);
        ButtonCheck(ref press1, press_1_btn);
        ButtonCheck(ref pressB, press_B_btn);
        cursor = Record.Count;
        CFFC.Update(tol);
    }
}
