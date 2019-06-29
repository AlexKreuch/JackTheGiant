using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Scene00_tester : MonoBehaviour
{
    private bool flyMode = false;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float flySpd = 10f;

    private Rigidbody2D playerBody;

    private RigidbodyConstraints2D noMoving, moving;

   

    void Start() {

      

        playerBody = player.GetComponent<Rigidbody2D>();
        noMoving = RigidbodyConstraints2D.FreezeAll;
        moving = RigidbodyConstraints2D.FreezeRotation;
    }
    void Update() {

        if (Input.GetKeyDown(KeyCode.O)) ToggleFlyMode();
        if (flyMode) Mover();
    }

    private void ToggleFlyMode() {
        flyMode = !flyMode;
        playerBody.constraints = flyMode ? noMoving : moving;
    }

    private void Mover() {
        const KeyCode down = KeyCode.K, up = KeyCode.I, left=KeyCode.J, right = KeyCode.L;

        Vector3 vector = player.transform.position;

        vector.x += flySpd * Time.deltaTime * getDir(left,right);
        vector.y += flySpd * Time.deltaTime * getDir(down, up);

        player.transform.position = vector;
    }
    private int getDir(KeyCode kc0, KeyCode kc1) {
        int i0 = Input.GetKey(kc0) ? -1 : 0;
        int i1 = Input.GetKey(kc1) ?  1 : 0;
        return i0+i1;
    }

}