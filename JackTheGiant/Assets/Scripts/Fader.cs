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
        Image image = GetComponentInChildren<Image>();
        bool b = ReportStatus(image,"theImage");
        if (b)
        {
            GameObject panel = image.gameObject;
            ReportStatus(panel,"thePanel");
        }
    }

    private bool ReportStatus(Object obj, string title) {
        bool res = obj != null;
        if (res) Debug.Log(string.Format("{0} found | name == {1}", title, obj.name));
        else Debug.Log(title + " not-found");
        return res;
    }
  

}
