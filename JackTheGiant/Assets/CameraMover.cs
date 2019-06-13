using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float speed = .1f;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vector = transform.position;
        vector.y -= speed;
        transform.position = vector;
    }
}
