using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tester00 : MonoBehaviour
{
   
    private InputField input;
    public GameObject cloud;
    private Stack<GameObject> stack;
    public void Start() {
        input = (InputField)gameObject.GetComponentInChildren(typeof(InputField));

        stack = new Stack<GameObject>();
    }
    public void ButtonPress() {
        Debug.Log("button-pressed");
        GameObject obj0;
        switch (input.text)
        {
            case "del":
                if (stack.Count != 0)
                {
                    obj0 = stack.Pop();
                    Destroy(obj0);
                }
                break;
            default:
                obj0 = Instantiate(cloud);
                obj0.transform.position = new Vector2(0,0);
                stack.Push(obj0);
                break;
        }
    }
}
