using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
public class Scene00_tester00 : MonoBehaviour
{
    [SerializeField]
    public RectTransform rt;

    public bool btn0 = false;
    public bool btn1 = false;

    private void scale(float x) {
        Vector2 vector = rt.sizeDelta;
        vector *= x;

        rt.sizeDelta = vector;

    }

    private void Check(float x, ref bool btn)
    {
        if (btn)
        {
            scale(x);
            btn = false;
        }

    }
    

    void Update() {
        Check(2f, ref btn0);
        Check(.5f, ref btn1);
    }
}
