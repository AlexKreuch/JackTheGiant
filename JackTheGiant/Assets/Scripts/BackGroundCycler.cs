using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCycler : MonoBehaviour
{
    private float deltaY = 40;

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "b_gnd")
        {
            Vector2 vector = other.transform.position;
            vector.y -= deltaY;
            other.transform.position = vector;
        }
    }

  

}
