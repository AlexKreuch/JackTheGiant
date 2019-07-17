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

  
}
