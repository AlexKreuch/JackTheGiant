using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float grav = .1f;
    public float drag = .5f;
    private float timeTracker = 0f;
    private float computePath(float t) {
        /*
p(t) = -a*log(b*cos(cx))
p'(t) = ( -a/b*cos(cx) ) * ( -b*sin(cx) * c )
      = ( ac/cos(cx) ) * ( sin(cx) )
      = (ac) * tan(cx)
p''(t) = (ac) * ( 1 + tan^2(cx) ) * c
       =  ac^2 + ac^2tan^2(cx) 
       =  ac^2 + a^2c^2tan^2(cx) / a
       =  ac^2 + (ac*tan(cx))^2 / a
       =  ac^2 + (1/a)*( p'(t) )^2
A = ac^2 ; B = 1/a
a = 1/B ; c = \sqrt{AB}
*/
        float a = drag == 0 ? (float)1E10 : 1 / drag;
        float c = Mathf.Sqrt(Mathf.Abs(drag*grav));
        var intermed = Mathf.Cos(c * t);
        Debug.Log("Mathf.Cos(c * t) = " + intermed);
        var res = -1 * a * Mathf.Log(Mathf.Cos(c * t));
        return res;
    }
    private void moveCam() {
        float y0 = computePath(timeTracker);
        timeTracker += Time.deltaTime;
        float y1 = computePath(timeTracker);
        Debug.Log("aa | " + y1);
        float deltay = y0 - y1;
        Vector2 vector = transform.position;
        vector.y += deltay;
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
