using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public static CameraMover instance;
    void Awake() { instance = this; }
    public float currentSpeed = 0f;
    public float maxSpeed = 5f;
    public float speedUpFactor = 1f;
    
    private void moveCam() {
        float delta_y = currentSpeed * Time.deltaTime;
        currentSpeed += speedUpFactor * Time.deltaTime;
        if (currentSpeed > maxSpeed) currentSpeed = maxSpeed;

        Vector2 vector = transform.position;
        vector.y -= delta_y;
        transform.position = vector;
    }
    void Update() { moveCam(); }
    /*
    // OLD :

    public float speed = .1f;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vector = transform.position;
        vector.y -= speed;
        transform.position = vector;
    }
    */
}
