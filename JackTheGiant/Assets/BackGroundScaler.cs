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
     
    }

    private void Adjust() {
        
        float screenWidth= ( Camera.main.orthographicSize / Screen.height ) * 2 * Screen.width * Camera.main.rect.width;
        float bgWidth = spriteRenderer.bounds.size.x;
        float xfactor = screenWidth / bgWidth;

        Vector3 vector = transform.localScale;
        vector.x = xfactor;

        transform.localScale = vector;
        
    }

   
 
    

  
}
