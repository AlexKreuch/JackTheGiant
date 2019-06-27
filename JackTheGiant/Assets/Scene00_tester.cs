using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scene00_tester : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;

    private bool stopped = false;

    private RigidbodyConstraints2D holdVal;
    private RigidbodyConstraints2D moveVal;

    void Start() {
        holdVal = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
        moveVal = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I))
        {
            body.constraints = stopped ? moveVal : holdVal;
            stopped = !stopped;
        }
    }
}
