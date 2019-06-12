using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tester00 : MonoBehaviour
{
   
    private InputField input;
    public void Start() {
        input = (InputField)gameObject.GetComponentInChildren(typeof(InputField));
    }
    public void ButtonPress() {
        Debug.Log("button-pressed");
    }
}
