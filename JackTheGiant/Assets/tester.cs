using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tester : MonoBehaviour
{
    
    public class PlayerRemote
    {
        private GameObject player;
        private Rigidbody2D rigidbody2D;
        private Vector2 init_pos;
        public float speed = 5;
        public float jumpPower = 5;
        public PlayerRemote() { player = null; rigidbody2D = null; init_pos = new Vector2(); }
        public PlayerRemote(GameObject x)
        {
            player = x;
            rigidbody2D = (Rigidbody2D)player.GetComponent(typeof(Rigidbody2D));
            init_pos = x.transform.position;
        }

        public void ResetPosition()
        {
            player.transform.position = init_pos;
        }
        public void Mover()
        {
            MoverHelperWalk(KeyCode.A, -1);
            MoverHelperWalk (KeyCode.D, 1);
            MoverHelperJump(KeyCode.W);
        }
        private void MoverHelperWalk(KeyCode kc, int sign)
        {
            if (Input.GetKey(kc))
            {
                float delta = Time.deltaTime * speed * sign;
                Vector2 pos = player.transform.position;
                pos.x += delta;
                player.transform.position = pos;
            }
        }
        private void MoverHelperJump(KeyCode kc) {
            if(Input.GetKeyDown(kc))
               rigidbody2D.AddForce(new Vector2(0,jumpPower));
        }
    }
    public PlayerRemote playerRemote;
    public Sprite sprite;
    public GameObject thePlayer;
    public InputField input;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = (Animator)thePlayer.GetComponent(typeof(Animator));
        playerRemote = new PlayerRemote(thePlayer);
    }

    // Update is called once per frame
    void Update()
    {
        playerRemote.Mover();
    }

    public void PushButton() {
        Adjuster();
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
    private void Adjuster() {
        string data = input.text;
        if (data == "") return;
        if (data == "reset")
        {
            playerRemote.ResetPosition();
            return;
        }
        string[] tokens = data.Split('=');
        if (tokens.Length > 2) { Debug.Log("too many \'=\''s"); return; }
        bool speedOption = false;
        switch (tokens[0])
        {
            case "speed": speedOption = true; break;
            case "jumpPower": break;
            default: Debug.Log("not-recognized"); return;
        }
        if (tokens.Length == 1)
        {
            var value = speedOption ? playerRemote.speed : playerRemote.jumpPower;
            Debug.Log(string.Format("{0} has value : {1}", tokens[0], value));
        }
        else
        {
            bool b = float.TryParse(tokens[1],out float value);
            if (b)
            {
                if (speedOption) playerRemote.speed = value; else playerRemote.jumpPower = value;
                Debug.Log(string.Format("{0} has been set to : {1}", tokens[0], value));
            }
            else Debug.Log("invalid number");
        }
    }
    
}
