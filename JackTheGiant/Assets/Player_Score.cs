using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Score : MonoBehaviour
{
    private class ScoreKeeper {
        private Vector2 previousPos;
        private bool keeperOn;

        public ScoreKeeper() { previousPos = new Vector2(); keeperOn = false;  }
        public ScoreKeeper(Transform tran) { previousPos = tran.position; keeperOn = true; }

        public void Step(Transform tran, ref int score) {
            if (keeperOn && (tran.position.y < previousPos.y)) score++;
            previousPos = tran.position;
        }
        public bool IsOn { get { return keeperOn; } set { keeperOn = value; } }
        public void ToggleOnOff() { keeperOn = !keeperOn; }
    }
    private ScoreKeeper scoreKeeper;
    [SerializeField]
    private AudioClip getCoin, getLife, dieSound;
    
    public int playerScore = 0;
    public int coinScore = 0;
    public int lifeScore = 0;
    
    


    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = new ScoreKeeper(transform);
    }

    void FixedUpdate()
    {
        scoreKeeper.Step(transform, ref playerScore);
    }
   
    

    public void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "cloud_dark": HitDarkCloud(); break;
            case "Coin": HitCoin(); break;
            case "Life": HitLife(); break;
            case "Bound": HitBound(); break;
            default: break;
        }
    }
    #region onTrigger-helpers
    private void HitDarkCloud() { }
    private void HitCoin() { }
    private void HitLife() { }
    private void HitBound() { }
    #endregion
}
