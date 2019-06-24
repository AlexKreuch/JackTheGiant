using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  [ExecuteAlways]
public class Scene00_tester : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    private float x_to_y = 84 / 27;
    private float safeDiv(float x, float y) { if (y == 0) y = .01f; return x/y; }

    public void Update() { Adjust(); }

    private void Adjust() {
        if (image == null) return;
        Vector2 vector = image.rectTransform.sizeDelta;
        if (safeDiv(vector.x, vector.y) != x_to_y)
        {
            Debug.Log("this");
            vector.y = safeDiv(vector.x,x_to_y);
            image.rectTransform.sizeDelta = vector;
        }
    }
    
}
