using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class OptionsTester00 : MonoBehaviour
{
    public bool reset_btn = false;
    private void reset_chkFn() {
        if (reset_btn)
        {
            image = null;
            notStarted = true;
            reset_btn = false;
        }
    }
    private UnityEngine.UI.Image image;
    public GameObject button;
    private bool notStarted = true;
    private float x_to_y = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
        reset_chkFn();
        Adjust();
    }

    private void Adjust() {
        float safeDiv(float x, float y) { if (y == 0) y = .001f; return x / y; }
        if (!CheckForImage()) return;
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

    private bool CheckForImage() {
        if (image != null) return true;

        if (button == null) return false;

        UnityEngine.UI.Image im = button.GetComponent<UnityEngine.UI.Image>();
        if (im == null) {Debug.Log("no image found");  return false; }
        image = im;
        return true;
    }
    
}
