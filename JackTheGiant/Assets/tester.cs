using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tester : MonoBehaviour
{
    public Sprite sprite;
    public GameObject thePlayer;
    public InputField input;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = (Animator)thePlayer.GetComponent(typeof(Animator));

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PushButton() {
        ToggleWalk();
    }
    private void CheckForComponent() {
        string name = input.text;
        try
        {
            var x = thePlayer.GetComponent(name);
            string message = x == null ? "null-returned" : name + " found";
            Debug.Log(message);
        }
        catch
        {
            Debug.Log("exception thrown on " + name);
        }
    }
    private void ToggleWalk() {
        const string name = "walking";
        var x = animator.GetBool(name);
        animator.SetBool(name, !x);
    }
    private void SpriteTest() {
       
       }
    
}
