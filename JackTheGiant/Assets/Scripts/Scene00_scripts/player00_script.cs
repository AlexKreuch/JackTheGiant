using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player00_script : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float maxVelocity = 100;

    private Rigidbody2D rigidbody;
    private Sprite sprite;
    private Animator animator;

  

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<Sprite>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }
    void Update() {
        FaceRightWay();
        WalkingAnimation();
    }

    #region Movement helper-methods
   
    private int TryingToMove() {
        /*

        if i:=result%3, then :
           i==0 := not trying to move
           i==1 := trying to move left
           i==2 := trying to move right
        */
        float v = Input.GetAxis("Horizontal");
        if (v == 0) return 0;
        int i = v < 0 ? 1 : 2;
        return i;
    }
    private void FaceRightWay() {
        /*
         Ensures the sprite is facing the right direction
         */
        const int RIGHTWARD_SIGN = 1;
        int ttm = TryingToMove();
        ttm = ((4 - (ttm % 3)) % 3) - 1; // now ttm==-1 if trying-to-move (TTM) left, ttm==0 if not TTM, and ttm==1 if TTM right
        int target = ttm * RIGHTWARD_SIGN;
        if (target == 0) return;
        if (target < 0 != rigidbody.transform.localScale.x < 0)
        {
            Vector2 vector = rigidbody.transform.localScale;
            vector.x *= -1;
            rigidbody.transform.localScale = vector;
        }

    

    }
    private void Move() {
        int ttm = TryingToMove();
        ttm = ((4 - (ttm % 3)) % 3) - 1;
        if (ttm == 0) return;
        float xvel = rigidbody.velocity.x;
        if (xvel * ttm < maxVelocity)
        {
            rigidbody.AddForce(new Vector2(speed*ttm,0));
        }
    }
    private void WalkingAnimation() {
        /*
         ensure that the sprite has the walk-cycle turned on if and only if 
         it is walking
         */
        const string fieldName = "walking";
        bool isWalking = animator.GetBool(fieldName);

        if (isWalking != (TryingToMove() != 0))
            animator.SetBool(fieldName,!isWalking);

    }

    
    #endregion
}
