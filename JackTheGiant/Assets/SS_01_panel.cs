using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SS_01_panel : MonoBehaviour
{
    public static SS_01_panel instance;
    private GameObject panel;
    private Image image;
    void Awake() {
        if (instance == null)
        {
            instance = this;
            image = GetComponent<Image>();
            panel = image.gameObject;
        }

    }

    public bool PanelOn {
        get { return panel.activeSelf; }
        set { panel.SetActive(value); }
    }
    public float Opacity {
        get { return image.color.a; }
        set {
            var c = image.color;
            c.a = value;
            image.color = c;
        }
    }
}
