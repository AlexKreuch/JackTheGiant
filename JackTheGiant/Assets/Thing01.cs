using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class Thing01 : MonoBehaviour
{
    private Image image;


    public bool direction = true;
    public float v0 = 0f;
    public float v1 = 0f;

    void Awake() {
        image = GetComponent<Image>();
    }

    private Image GetImage() {
        if (image == null) image = GetComponent<Image>();
        return image;
    }

    void Update() {
        MaintainOp();
    }

    private void MaintainOp() {
        float v = direction ? v1 : v0;
        Image im = GetImage();
        var c = im.color;
        c.a = v;
        im.color = c;
    }
}
