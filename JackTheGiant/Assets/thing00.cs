using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thing00 : MonoBehaviour
{
    public static thing00 instance;

    private GameObject ThePanel;
    private UnityEngine.UI.Image image;

    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

   

    private void SetOpacity(float alpha) {
        var color = image.color;
        color.a = alpha;
        image.color = color;
    }



    private IEnumerator Fade_erator(float time, System.Func<int> switchScene = null, System.Func<float,int> func = null) {
        Debug.Assert(time > 0);
        
        float halfTime = time / 2;
        float startTime = Time.realtimeSinceStartup;
        float a = -2 / time;
        float b = -.5f * time - startTime;
        float endTime = startTime + halfTime;
        void f() {
            var x = a * Mathf.Abs(Time.realtimeSinceStartup + b) + 1;
            SetOpacity(x );
            if (func != null) func(x);
        }
        
        ThePanel.SetActive(true);
        Debug.Log("START");
        SetOpacity(0);
        while (Time.realtimeSinceStartup < endTime)
        {
            f();
            yield return null;
        }
        if (switchScene != null) switchScene();
        endTime += halfTime;
        while (Time.realtimeSinceStartup < endTime)
        {
            f();
            yield return null;
        }
        Debug.Log("STOP");
        ThePanel.SetActive(false);
    }


    private void doSomething(float time, System.Func<int> switchScene = null, System.Func<float, int> func = null) {
        StartCoroutine(Fade_erator(time,switchScene,func));
    }

    public static void FADE_METHOD(float time, System.Func<int> switchScene = null, System.Func<float, int> func = null) {
        instance.doSomething(time, switchScene,func);
    }
}
