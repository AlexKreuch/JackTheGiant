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
    private void ScaleButtons() {
      
        Sprite sprite = Lbtn.GetComponent<Image>().sprite;
        

        float camH = Camera.main.orthographicSize * 2;
        float camW = camH * (Screen.width / Screen.height) * Camera.main.rect.width;

        float btnH = sprite.bounds.size.y;
        float btnW = sprite.bounds.size.x;

        float xfactor = (camW / btnW) / 2;
        float yfactor = camH / btnH;

        float GET_x_pos(int asdf_0)
        {
            float asdf_1 = camW / 4;
            if (asdf_0 == 0) asdf_1 *= -1;
            return asdf_1;
        }

        for (int i = 0; i < 2; i++)
        {
            Button button = i == 0 ? Lbtn : Rbtn;
            Vector2 pos = button.transform.localPosition;
            Vector2 sca = button.transform.localScale;

            pos.x = GET_x_pos(i);
            sca.x = xfactor;
            sca.y = yfactor;

            button.transform.localPosition = pos;
            button.transform.localScale = sca;
        }


    }

    void Awake() {
        GetButtons();
        ScaleButtons();
    }
}
