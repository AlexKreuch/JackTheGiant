using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public static Fader instance;

    public float Opacity = 0f;

    private const string triggerName = "StartFadeCycle";
    private Animator animator;
    private GameObject panel;
    private Image image;
    private enum PAS { FADEIN , FADEOUT , IDLE , STARTING }; // PAS := Predicted Animator State
    private PAS pas = PAS.STARTING;


    private void MaintainOpacity() {
        if (panel.activeSelf)
        {
            var c = image.color;
            c.a = Opacity;
            image.color = c;
        }
    }
    
    void Awake() {
        if (instance == null)
        {
            instance = this;
            animator = GetComponent<Animator>();
            image = GetComponentInChildren<Image>();
            panel = image.gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

   

    void Update() {
        MaintainOpacity();
        btn_test();
    }

    public void FadeToNextScene(string nextScene) {
        Debug.Assert(pas==PAS.IDLE,"tried to fade scenes durring fade");
        QuedScene = nextScene;
        StartFading();
    }

    public void FadingEvent(int x) {
        int c = -1;
        switch (pas)
        {
            case PAS.FADEIN: c = 0; break;
            case PAS.FADEOUT: c = 1; break;
            case PAS.IDLE: c = 2; break;
            case PAS.STARTING: c = 3; break;
        }
        c = (2 * c) + x;
        switch (c)
        {
            case 6: // pas==STARTING, x==0
                pas = PAS.FADEIN;
                break;
            case 1: // pas==FADEIN, x==1
                pas = PAS.IDLE;
                panel.SetActive(false);
                break;
            case 5: // pas==IDLE, x==1
                animator.speed = 1f;
                pas = PAS.FADEOUT;
                panel.SetActive(true);
                break;
            case 2: // pas==FADEOUT, x==0
                pas = PAS.FADEIN;
                gotoNextScene();
                break;
            case 0: // pas==FADEIN, x==0
                break;
            default:
                Debug.Assert(false,"INVALID FADER-STATE : c==" + c);
                return;
        }
    }

    private void StartFading() {
        if (pas != PAS.IDLE) return;
        animator.speed = 100f;
        animator.SetTrigger(triggerName);
    }


    private string QuedScene = "";

    private void gotoNextScene() {
        if (QuedScene == "") return;
        SceneManager.LoadScene(QuedScene);
    }

    public bool btn = false;
    private void btn_test() {
        if (btn)
        {
            btn = false;
            string nm = "MainMenu00";
            FadeToNextScene(nm);
        }
    }
    
    
}
