using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float speedUpFactor = 1f;
    private float distanceTracker = 0f;
    private float timeTracker = 0f;
    
    private void moveCam() {
        /*
         pos(x) = x arctan(x) - (1/2)log(x^2+1) + C
vel(t) = c0 * arctan(c2*x+c3)

\int arctan(x) dx = x arctan(x) - (1/2)log(x^2+1) + C

let F(t) := x arctan(x) - (1/2)log(x^2+1) 
 ( note then : F'(t) = arctan(x) )
now let G[a,b](t) := a*F(b*t)
 ( note then : G'(t) = ab*F'(bt) = ab*arctan(bt) )
note that G'(t) approches ab*(\pi/2)

so : set a=(max/b)/(pi/2)
         */
        float b = speedUpFactor!=0 ? speedUpFactor : 1f;
        float a = (maxSpeed / b) * .5f / Mathf.PI;
        float t = timeTracker + Time.deltaTime;
        float cur_d = t * Mathf.Atan(t) - .5f * Mathf.Log(t*t+ 1);
        float delta_d = cur_d - distanceTracker;
        distanceTracker = cur_d;
        timeTracker = t;

        Vector2 vector = transform.position;
        vector.y -= delta_d;
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
