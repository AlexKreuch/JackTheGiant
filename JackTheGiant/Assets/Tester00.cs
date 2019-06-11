using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tester00 : MonoBehaviour
{
    public GameObject someObject;
    public string methodName;
    public string error_message = "could not send-message";
    private InputField input;
    public void Start() {
        input = (InputField)gameObject.GetComponentInChildren(typeof(InputField));
    }
    public void ButtonPress() {
        try
        {
            string inp = input.text;
            someObject.SendMessage(methodName,inp);
        }
        catch
        {
            Debug.Log(error_message);
        }
    }
}
