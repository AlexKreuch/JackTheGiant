using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HighScoreTester00 : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public UnityEngine.UI.CanvasScaler canvasScaler;
    private bool csNotPrepped = true;
    private float x_to_y = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START-CALLED");
    }

    // Update is called once per frame
    void Update()
    {
        Adjust();
    }
    public void Adjust() {
        if (canvasScaler == null) return;
        if (csNotPrepped)
        {
            float tmpy = canvasScaler.referenceResolution.y;
            if (tmpy == 0) tmpy = .001f;
            x_to_y = canvasScaler.referenceResolution.x / tmpy;
            if (x_to_y == 0) x_to_y = .001f;
            csNotPrepped = false;
        }
        Vector2 vector = canvasScaler.referenceResolution;
        if (vector.y == 0) vector.y = .001f;
        if (vector.x / vector.y != x_to_y)
        {
            vector.y = vector.x / x_to_y;
            canvasScaler.referenceResolution = vector;
        }
    }
  
}
