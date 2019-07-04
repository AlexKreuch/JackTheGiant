using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SS_01_tester : MonoBehaviour
{
 
    private string nxtSceneName = "SampleScene_0";

    private void SetterUpper()
    {
        void func(Scene scene ,  LoadSceneMode mode) {
            var nm = scene.name;
            if (nm.Length == 0) return;
            var c = nm[nm.Length - 1];
            c = c == '1' ? '2' : '1';
            nxtSceneName += c;
        }
        SceneManager.sceneLoaded += func;
        
    }

    void OnEnable() { SetterUpper(); }

    [SerializeField]
    UnityEngine.AudioClip audio;

    public bool btn_0 = false;

    public bool Paused = false;
    private void Pause_erator() {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1 - Time.timeScale;
        }
        Paused = Time.timeScale == 0f;
    }


    IEnumerator YellAndGO()
    {
        float t = audio.length;
        AudioSource.PlayClipAtPoint(audio,new Vector3());
        yield return new WaitForSeconds(t);
        SceneManager.LoadScene(nxtSceneName);
    }

    private int nxtLevel()
    {
        StartCoroutine(YellAndGO());
        return 0;
    } 

    void Update()
    {
        CheckPsudoButton(nxtLevel, ref btn_0);
        Pause_erator();
        if (Input.GetKeyDown(KeyCode.O) && !btn_0) btn_0 = true;
    }

   

    private void CheckPsudoButton(Func<int> func, ref bool buttonBool) {
        if (buttonBool)
        {
            func();
            buttonBool = false;
        }
    }
}
