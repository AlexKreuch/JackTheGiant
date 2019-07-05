using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SS_01_tester : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Button button;
    [SerializeField]
    Sprite sprite0, sprite1;

    void OnEnable() {
        button.onClick.AddListener(PressButton);
    }

    private void CheckPsudoButton(Func<int> func, ref bool buttonBool) {
        if (buttonBool)
        {
            func();
            buttonBool = false;
        }
    }

    bool ons1 = false;
    private void PressButton() {
        ons1 = !ons1;
        Sprite sprite = ons1 ? sprite1 : sprite0;
        button.image.sprite = sprite;
        MusicController.instance.SetPlay(ons1);
    }
}
