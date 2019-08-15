

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class SS_01_tester01 : MonoBehaviour
{

    #region old-testing stuff
    private class SwitchMachine {
        private static string sceneNameBase = "SampleScene_0";
        private static string sceneName = "";

        public static void Prep() {
            void func(Scene scene, LoadSceneMode mode) {
                var nm = scene.name;
                var c = nm[nm.Length - 1];
                c = (c == '1') ? '2' : '1';
                sceneName = sceneNameBase + c;
            }
            SceneManager.sceneLoaded += func;
        }

        public static void SwitchScene() {
            StopWatch.SaveData();
            SceneManager.LoadScene(sceneName);
        }
    }

    private class StopWatch {

        private const string initSign = "StopWatch_init";
        private const string tdp = "StopWatch_tdp";
        private const string lrt = "StopWatch_lrt";
        private const string tuo = "StopWatch_tuo";

        private static float timeDataPoint = 0f;
        private static float lastRecordedTime = 0f;
        private static bool turnedOn = false;

        public static bool IsOn() { return turnedOn; }
        public static void Start() {
            turnedOn = true;
            timeDataPoint = lastRecordedTime;
        }
        public static void Stop() {
            if (turnedOn)
            {
                turnedOn = false;
                timeDataPoint = lastRecordedTime - timeDataPoint;
            }
            SaveData();
        }
        public static float GetReading() {
            if (turnedOn) return lastRecordedTime - timeDataPoint;
            else return timeDataPoint;
        }

        public static void SaveData() {
            if (!PlayerPrefs.HasKey(initSign)) PlayerPrefs.SetInt(initSign, 0);
            PlayerPrefs.SetFloat(tdp, timeDataPoint);
            PlayerPrefs.SetFloat(lrt, lastRecordedTime);
            PlayerPrefs.SetInt(tuo, turnedOn ? 1 : 0);
        }
        public static void LoadData()
        {
            if (!PlayerPrefs.HasKey(initSign)) return;
            timeDataPoint = PlayerPrefs.GetFloat(tdp);
            lastRecordedTime = PlayerPrefs.GetFloat(lrt);
            turnedOn = PlayerPrefs.GetInt(tuo) == 1;

            if (turnedOn)
            {
                float rtss = Time.realtimeSinceStartup;
                float currentReading = lastRecordedTime - timeDataPoint;
                timeDataPoint = rtss - currentReading;
                lastRecordedTime = rtss;
            }
        }

        public static void UpdateState() {
            lastRecordedTime = Time.realtimeSinceStartup;
        }
    }

    private class PanelController {

        private static float FadeTime = 5f;

        public static float GetFadeTime() { return FadeTime; }

        private static float ComputeOp() {

            float y_scaler = 2f;
            if (!StopWatch.IsOn()) return 0f;
            var x = StopWatch.GetReading();
            x = Mathf.Clamp(x, 0, FadeTime);
            var y = 1 - Mathf.Abs(x * (2 / FadeTime) - 1);
            y = Mathf.Clamp(y_scaler * y, 0, 1);
            return y;

            #region ScratchWork
            /*
                y = 1-|xa+b|
             
                y|_{x=0} = 0, so 1-|b|=0, so |b|=1
                y|_{x=ft} = 0, so 1-|ft*a+b|=0, so |ft*a+b|=1
                y|_{x=ft/2} = 1, so 1-|(ft/2)*a+b|=1, so (ft/2)*a+b=0, so a=-(2/ft)b,
                so |a| = |-(2/ft)b| = (2/ft)|b| = 2/ft, so |a|=2/ft.


                if f(x) := 1 - |x*(2/ft)-1|, then : 
                   f(0) = 0
                   f(ft/2) = 1
                   f(ft) = 0

                  1 = |b| = |(-ft/2)*a| = (ft)(1/2)(a)*A,
                  so : a = 2A/ft, so |a|=2/ft


                    

             
             */
            #endregion
        }

        public static void UpdateState() {
            if (StopWatch.IsOn() && StopWatch.GetReading() >= FadeTime) StopWatch.Stop();
        }

        public static void MaintainPanel() {
            float op = 0f;
            bool ton = false;
            GetPanelState(ref op, ref ton);
            SS_01_panel.instance.PanelOn = ton;
            SS_01_panel.instance.Opacity = op;
        }

        public static void GetPanelState(ref float opacity, ref bool turnedOn) {
            opacity = ComputeOp();
            turnedOn = StopWatch.IsOn();
        }
        public static void StartFading() {
            StopWatch.Start();
        }
    }

    IEnumerator WaitTillDo(float waitTime, System.Action doThis) {
        float endTime = waitTime + Time.realtimeSinceStartup;
        while (Time.realtimeSinceStartup < endTime) yield return null;
        doThis();
    }
    #endregion

    private const string NAME = "com.google.android.gms.ads.initialization.OnInitializationCompleteListener";
    
    


  

    private void TryToMake() {

       var x = new AndroidJavaProxy(NAME);

        

        Debug.Log("~~test-ran");
    }

    public string input = "";
    public string display = "";
    public bool btn = false;
    public bool toggle_varification = false;

    private class TESTER {
        private static int TEST_HELPER(string s)
        {
            /*
             *  encoding : 
             *     0:=nothing-found
             *     2:=something-found, but no interface
             *     3:=something-found, and interface-found
             */
            int c = 0;
            var x = new AndroidJavaProxy(s);
            if (x == null) return c; else c += 2;
            var y = x.javaInterface;
            if (y != null) c += 1;
            return c;
        }
        private static string RUNTEST(string input)
        {
            int x = TEST_HELPER(input);
            string s = ((x/2)%2==1 ? "T" : "F") + (x%2==1 ? "T" : "F");
            return s;
        }

        public static void UPDATE(ref bool pressed, ref bool tv, string inp, ref string disp) {
            if (pressed)
            {
                pressed = false;
                disp = RUNTEST(inp);
                tv = !tv;
            }
        }
    }

    private void ObjStrTest() {
        var x = new AndroidJavaObject("java.lang.String", "asdf");
        var y = new AndroidJavaObject("java.lang.String", "asdf");

        

        bool b = x.Equals(y);

        Debug.Log("<x==y> == " + b);

        Debug.Log("end-ObjStrTest");
    }

    private void TestMyPlugin() {
        /*
            package : com.example.alexk.myunitypluginlibrary00
            className : MyPlugin00
            stringName : com.example.alexk.myunitypluginlibrary00.MyPlugin00
            staticMethodName : DoSomething
        */
        //   AndroidJavaObject plugin = new AndroidJavaObject("com.example.alexk.myunitypluginlibrary00.MyPlugin00");
        //   Debug.Log("trying to run-plugin");
        //   plugin.CallStatic("ShowMessage");
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity2d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        Debug.Log("activity-found == " + (activity!=null));
    }

    void Awake() {
       // TestMyPlugin();
        ObjStrTest();
        var x = new AndroidJavaProxy("asdf");
        x.Invoke("asdf", new object[0]);
        Debug.Log("ran-this test");
        
    }

    void Start() { TestMyPlugin(); }

    void Update() {
        TESTER.UPDATE(ref btn, ref toggle_varification, input, ref display);
    }

    /*
     let NAME := "com.google.android.gms.ads.initialization.OnInitializationCompleteListener"
need to try : 
  var x = new AndroidJavaProxy(NAME);
AndroidJavaProxy

     */






}
