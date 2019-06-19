using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tester00 : MonoBehaviour
{

    private InputField input;

    private Vector2[] campos;
    private int cur = 0;
    private float dt = 1f;
    private void setup_vals() {
        campos = new Vector2[2];
        campos[0] = Camera.main.transform.position;
        campos[1] = Camera.main.transform.position;
    }
    private void update_vals() {
        campos[cur] = Camera.main.transform.position;
        cur = (cur + 1) % 2;
        dt = Time.deltaTime;
    }
    private float computeSpeed() {
        Vector2 vector = campos[0] - campos[1];
        float distance = vector.magnitude;
        return distance/dt;
    }
    public void Start() {
        input = (InputField)gameObject.GetComponentInChildren(typeof(InputField));

        setup_vals();
    }
    public void Update() { update_vals(); }
    public void ButtonPress() {
        var v = computeSpeed();
        Debug.Log("speed = " + v);
    }
    
}
 