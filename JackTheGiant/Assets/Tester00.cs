using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tester00 : MonoBehaviour
{

    private InputField input;
    private GameObject player;
    private Rigidbody2D rigidbody;
    private Vector2 init_pos;
    public bool firstUpdate = true;
    public float scale = 1f;
    public void Start() {
        input = (InputField)gameObject.GetComponentInChildren(typeof(InputField));

        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = player.GetComponent<Rigidbody2D>();
        init_pos = player.transform.position;
    }
    public void Update() {
        if (firstUpdate)
        {
            init_pos = player.transform.position;
            firstUpdate = false;
        }
        if (player.transform.localScale.x != scale)
        {
            Vector2 vector = player.transform.localScale;
            vector.x = scale;
            vector.y = scale;
            player.transform.localScale = vector;
        }
    }
    public void ButtonPress() {
        string inp = input.text;
        if (inp == "reset")
        {
            player.transform.position = init_pos;
            rigidbody.velocity = new Vector2(0f,0f);
            return;
        }
        
    }

    
    
}
 