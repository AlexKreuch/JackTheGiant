using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class OptionsTester00 : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    private bool notStarted = true;
    private float x_to_y = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Adjust();
    }

    private void Adjust() {
        float safeDiv(float x, float y) { if (y == 0) y = .001f; return x / y; }
        if (image == null) return;
        if (notStarted)
        {
            x_to_y = safeDiv(image.rectTransform.sizeDelta.x , image.rectTransform.sizeDelta.y);
            notStarted = false;
        }
        Vector2 vector = image.rectTransform.sizeDelta;
        if (safeDiv(vector.x, vector.y) != x_to_y)
        {
            vector.y = safeDiv(vector.x,x_to_y);
            image.rectTransform.sizeDelta = vector;
        }
    }
    
}
