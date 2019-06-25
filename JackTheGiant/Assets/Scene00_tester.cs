using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  [ExecuteAlways]
public class Scene00_tester : MonoBehaviour
{
    public GameObject player;
    public bool btn = false;
    public int setToThis = 0;
    public string dsp;
    private SpriteRenderer spriteRenderer;
    public void Update() {
        if (btn)
        {
            Push_btn();
            btn = false;
        }
    }

    private bool HaveRenderer() {
        if (spriteRenderer != null) return true;
        if (player == null) return false;
        var sr = player.GetComponent<SpriteRenderer>();
        if (sr == null) return false;
        else
        {
            spriteRenderer = sr;
            return true;
        }
    }

    private void Push_btn() {
        if (!HaveRenderer())
        {
            dsp = "!!!";
            return;
        }
        if (dsp == "chk") { dsp = string.Format("SR.sl_id = {0}",spriteRenderer.sortingOrder); return; }
        spriteRenderer.sortingOrder = setToThis;
    }
    
}
