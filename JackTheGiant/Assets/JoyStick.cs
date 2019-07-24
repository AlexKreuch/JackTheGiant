using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    private const string Rtag = "Right_button";
    private const string Ltag = "Left_button";

    private UnityEngine.UI.Button Lbtn, Rbtn;

    #region Prepare Buttons
    private class Handler : MonoBehaviour , IPointerDownHandler , IPointerUpHandler
    {
        private SharedInt SignalValue;
        private int flagVal = 0;
        void Awake() {
            var js = GetComponentInParent<JoyStick>();
            SignalValue = js.signalSource;
            flagVal = gameObject.tag == Ltag ? 2 : 1;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            SignalValue.val += flagVal;

            Debug.Log(SignalValue.val + " | DOWN | " + gameObject.name);
        }
        public void OnPointerUp(PointerEventData eventData) {
            SignalValue.val -= flagVal;

            Debug.Log( SignalValue.val + " | UP | " + gameObject.name);
        }
    }

    #region signal classes/methods
    /*
        signal is encoded as follows :      
           if val:=value of the signal, then : 
             * the right-button is pressed iff : val%2==1
             * the left-button is pressed iff : (val//2)%2==1   
    */
    public class SharedInt {
        public int val = 0;
    }
    public class Signal {
        private SharedInt val;
        public Signal(SharedInt sharedInt) { val = sharedInt; }
        public int GetVal() { return val.val; }
    }
    private Signal signal;
    private SharedInt signalSource;
    private void SetUpSignal() {
        signalSource = new SharedInt();
        signal = new Signal(signalSource);
    }
    public Signal GetSignal() { return signal; }
    #endregion

    private void GetButtons() {
        Button[] buttons = GetComponentsInChildren<Button>();
        int i = buttons[0].tag == Ltag ? 0 : 1;
        Lbtn = buttons[i];
        Rbtn = buttons[(i + 1) % 2];
    }
    private void ScaleButtons() {
        Canvas canvas = GetComponentInChildren<Canvas>();
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
    private void AddHandlersToButtons() {
        Lbtn.gameObject.AddComponent<Handler>();
        Rbtn.gameObject.AddComponent<Handler>();
    }
    private void MakeButtonsInvisible() {
        for (int i = 0; i < 2; i++)
        {
            Button button = i == 0 ? Lbtn : Rbtn;
            var color = button.image.color;
            color.a = 0;
            button.image.color = color;
        }
    }
    #endregion


    
    void Awake() {
        SetUpSignal();
        GetButtons();
        MakeButtonsInvisible();
        AddHandlersToButtons();
    }

    void Start() { ScaleButtons(); }

  
  
}
