

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SS_01_tester01 : MonoBehaviour
{


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
            PlayerPrefs.SetInt(tuo,turnedOn ? 1 : 0);
        }
        public static void LoadData()
        {
            if (!PlayerPrefs.HasKey(initSign)) return;
            timeDataPoint = PlayerPrefs.GetFloat(tdp);
            lastRecordedTime = PlayerPrefs.GetFloat(lrt);
            turnedOn = PlayerPrefs.GetInt(tuo)==1;

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
            x = Mathf.Clamp(x,0,FadeTime);
            var y = 1 - Mathf.Abs(x * (2 / FadeTime) - 1);
            y = Mathf.Clamp(y_scaler * y,0,1);
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
            if (StopWatch.IsOn() && StopWatch.GetReading()>=FadeTime) StopWatch.Stop();
        }

        public static void MaintainPanel() {
            float op = 0f;
            bool ton = false;
            GetPanelState(ref op,ref ton);
            SS_01_panel.instance.PanelOn = ton;
            SS_01_panel.instance.Opacity = op;
        }
        
        public static void GetPanelState(ref float opacity , ref bool turnedOn) {
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

   



    void Awake() {
        SwitchMachine.Prep();
        StopWatch.LoadData();
    }
    void Start() {
        PanelController.MaintainPanel();
    }

    void Update() {
        StopWatch.UpdateState();
        PanelController.UpdateState();
        PanelController.MaintainPanel();
        readWatch();
        press_btn();
        pressSw();
    }


    public bool btn = false;
    private void press_btn() {
        if (btn)
        {
            btn = false;
            PanelController.StartFading();
            StartCoroutine(WaitTillDo(PanelController.GetFadeTime()/2,SwitchMachine.SwitchScene));
           // var wtd = WaitTillDo(PanelController.GetFadeTime() / 2,SwitchMachine.SwitchScene);
            //StartCoroutine(wtd);
        }
    }

    public bool sw = false;
    private void pressSw() {
        if (sw)
        {
            sw = false;
            SwitchMachine.SwitchScene();
        }
    }

    private void readWatch() {
        if (StopWatch.IsOn())
        {
            Debug.Log("watch-on | currentTime = " + StopWatch.GetReading());
        }
        else
        {
            Debug.Log("watch-NOT-on | display shows : " + StopWatch.GetReading());
        }
    }
}
