using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tester00 : MonoBehaviour
{
   
    private InputField input;

    [SerializeField]
    private GameObject player;
    
    public void Start() {
        input = (InputField)gameObject.GetComponentInChildren(typeof(InputField));

        
    }
    public void ButtonPress() {
        player.transform.position = Camera.main.transform.position;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
    }
}
