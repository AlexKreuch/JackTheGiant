using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tester00 : MonoBehaviour
{
   
    private InputField input;
    public BackGroundScaler scaler;
    public void Start() {
        input = (InputField)gameObject.GetComponentInChildren(typeof(InputField));
    }
    public void ButtonPress() {
        if (scaler == null) return;
        scaler.Test(input.text);
    }
}
