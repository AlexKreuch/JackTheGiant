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
    private CameraMover camMover;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private AudioClip getCoin, getLife, dieSound;
    
    public int playerScore = 0;
    public int coinScore = 0;
    public int lifeScore = 0;
    
    


    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = new ScoreKeeper(transform);
        camMover = Camera.main.GetComponent<CameraMover>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        scoreKeeper.Step(transform, ref playerScore);
    }

    
    public void OnTriggerEnter2D(Collider2D other) {
        switch (other.tag) {
            case "cloud_dark": HitDarkCloud(other); break;
            case "Coin": HitCoin(other); break;
            case "Life": HitLife(other); break;
            case "cldCollector": HitBound(other); break;
            case "cldSpawner": HitBound(other); break;
            default: break;
        }
    }
    #region onTrigger-helpers
    private void HitDarkCloud(Collider2D other) {
        AudioSource.PlayClipAtPoint(dieSound,transform.position);
        camMover.enabled = false;
        lifeScore--;
        spriteRenderer.sortingOrder = 0;
        scoreKeeper.IsOn = false;
    }
    // coin-200 ; life-300
    private void HitCoin(Collider2D other) {
        playerScore += 200;
        coinScore++;
        AudioSource.PlayClipAtPoint(getCoin,transform.position);
        other.enabled = false;
    }
    private void HitLife(Collider2D other) {
        playerScore += 300;
        lifeScore++;
        AudioSource.PlayClipAtPoint(getLife, transform.position);
        other.enabled = false;
    }
    private void HitBound(Collider2D other) {
        AudioSource.PlayClipAtPoint(dieSound, transform.position);
        camMover.enabled = false;
        lifeScore--;
        spriteRenderer.sortingOrder = 0;
        scoreKeeper.IsOn = false;
    }
    #endregion
}
