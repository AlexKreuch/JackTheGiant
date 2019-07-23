using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour
{
    private const string Rtag = "Right_button";
    private const string Ltag = "Left_button";

    private UnityEngine.UI.Button Lbtn, Rbtn;
    private Canvas canvas;

    private void GetButtons() {
        Button[] buttons = GetComponentsInChildren<Button>();
        int i = buttons[0].tag == Ltag ? 0 : 1;
        Lbtn = buttons[i];
        Rbtn = buttons[(i + 1) % 2];
    }

    private void ScaleButtons() {
        float camH = Camera.main.orthographicSize * 2;
        float camW = camH * (Screen.width / ((float)Screen.height)) * Camera.main.rect.width;
        float canvasScale = canvas.transform.localScale.x;
        Vector2 canvalPos = canvas.transform.position;
        Vector2 Rpos = new Vector2(camW / 4, 0) + canvalPos;
        Vector2 Lpos = new Vector2(-camW / 4, 0) + canvalPos;
        Vector2 scale = new Vector2(camW / 2, camH) / canvasScale;
        for (int i = 0; i < 2; i++)
        {
            Button button = i == 0 ? Lbtn : Rbtn;
            Vector2 pos = i == 0 ? Lpos : Rpos;
            RectTransform rt = button.GetComponent<RectTransform>();
            rt.transform.position = pos;
            rt.sizeDelta = scale;
        }
    }
   

    void Awake() {
        GetButtons();
        canvas = GetComponentInChildren<Canvas>();
    }

    void Start() { ScaleButtons(); }

  
  
}
