using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class thing_02 : MonoBehaviour
{
    private Image image;
    private Image GetImage() {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
        return image;
    }

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer GetSpriteRenderer() {
        if (spriteRenderer == null)
        {
            const string name = "New Sprite";
            var canv = GetComponentInParent<Canvas>();
            var sr_arr = canv.transform.gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer x in sr_arr) if (x.name == name) { spriteRenderer = x; break; }
        }
        return spriteRenderer;
    }
    

    public string display0 = "";
    public string display1 = "";

    private void ShowPos() {
        var tran = GetImage().transform;
        display0 = "pos == " + tran.position.ToString();
        display1 = "sca == " + tran.localScale.ToString();
    }

    private void AdjustScale() {
        var sr = GetSpriteRenderer();
        var vec = sr.transform.localScale;
        if (vec.x != vec.y)
        {
            vec.y = vec.x;
            sr.transform.localScale = vec;
        }
    }

    void Update() {
        ShowPos();
        AdjustScale();
    }

    
}
