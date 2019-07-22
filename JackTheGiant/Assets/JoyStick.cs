using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour
{
    private const string Rtag = "Right_button";
    private const string Ltag = "Left_button";

    private UnityEngine.UI.Button Lbtn, Rbtn;

    private void GetButtons() {
        Button[] buttons = GetComponentsInChildren<Button>();
        int i = buttons[0].tag == Ltag ? 0 : 1;
        Lbtn = buttons[i];
        Rbtn = buttons[(i + 1) % 2];
    }

    
   

    void Awake() {
        GetButtons();
       
      
    }

  
}
