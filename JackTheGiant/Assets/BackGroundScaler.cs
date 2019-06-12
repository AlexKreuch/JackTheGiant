using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScaler : MonoBehaviour
{
    private Vector2 saveSize;
    private SpriteRenderer spriteRenderer;
    private int lineCount = 0;
    private void Report(string ms, params object[] objs)
    {
        const int pad = 5;
        string s0 = string.Format("{0} | ",lineCount++).PadLeft(pad);
        string s1 = string.Format(ms,objs);
        Debug.Log(s0 + s1);
    }
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Adjust();
    }

    // Update is called once per frame
    void Update()
    {
      //  if (Screen.width != saveSize.x || Screen.height != saveSize.y)
        //    Adjust();
    }

    private void Adjust() {
        float screenWidth= ( Camera.main.orthographicSize / Screen.height ) * 2 * Screen.width * Camera.main.rect.width;
        float bgWidth = spriteRenderer.bounds.size.x;
        float xfactor = screenWidth / bgWidth;

        Vector3 vector = transform.localScale;
        vector.x = xfactor;

        transform.localScale = vector;
        
    }

    public void asdf() {
        /*
         
         camera.orthSize = y-top
vp.x := horizontal portion of empty-screen to the left
vp.w := horizontal portion screen taken-up

sc.w := x-pixel count (occupied space?)
sc.h := y-pixel count (occupied space)

(y) distance-per-pixel = 
        (c.orth * 2)/sc.h

(c.orth / sc.h) * sc.w

      distance to x-edge ? :  ((c.orth)/sc.h) * sc.w * vp.w
         */
        float o = Camera.main.orthographicSize;
        int sc_h = Screen.height;
        int sc_w = Screen.width;
        float vp_w = Camera.main.rect.width;
        float dte = (o / sc_h) * sc_w * vp_w;
        Report("estimated distance to x-edge : {0}",dte);
    }

    public void Test(string x)
    {
        if (x == "W" || x == "H" || x=="O" || x=="test")
        {
            string s = ""; float v = 0;
            switch (x)
            {
                case "W": s = "Screen.width"; v = Screen.width; break;
                case "H": s = "Screen.height"; v = Screen.height; break;
                case "O": s = "Ortho"; v = Camera.main.orthographicSize; break;
                case "test": asdf(); return;
            }
           
            Report("{0}={1}",s,v);
            return;
        }
        float val = 1;
        bool flag = float.TryParse(x,out float res);
        if (flag) val = res;
        float estimate = ((float)Screen.width / (float)Screen.height) * Camera.main.orthographicSize * val;
        if (val == 1)
        {
            Report("ratio * orth-size = {0}",estimate);
        }
        else
        {
            Report("ratio * orth-size * {0} = {1}",val,estimate);
        }
    }
    

  
}
