﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameOverPanel gameOverPanel;
    
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

    IEnumerator DieRoutine() {
       
        camMover.enabled = false;
        lifeScore--;
        spriteRenderer.enabled = false;
        scoreKeeper.IsOn = false;

        AudioSource.PlayClipAtPoint(dieSound, transform.position);

        yield return new WaitForSeconds(dieSound.length);

        if (lifeScore > 0)
        {
            GameManager.instance.TellManagerSomething
            (
                GameManager.SceneChangeUtils.Tags.GAME_RESTARTED,
                new int[] { playerScore, lifeScore, coinScore }
            );
            Fader.instance.FadeToNextScene(Scene00_manager.SceneName);
           // SceneManager.LoadScene(Scene00_manager.SceneName);
        }
        else
        {
            gameOverPanel.gameObject.SetActive(true);
            gameOverPanel.SetVals(playerScore, coinScore);
            Scene00_manager.instance.SetPauseButtonOn(false);
            Scene00_manager.instance.CanPauseWithPKey = false;
            Scene00_manager.instance.Invoke("ExitToMainMenu", 5f);
        }
    }

    private void Die() {
        /*
          GameManager.instance.TellManagerSomething
            (
            GameManager.SceneChangeUtils.Tags.GAME_RESTARTED,
            new int[] { player_Score.playerScore, player_Score.lifeScore, player_Score.coinScore }
            );
         
         */
        StartCoroutine(DieRoutine());
    }
    private string currentCol = ""; 
    public void OnTriggerEnter2D(Collider2D other) {
        currentCol = other.gameObject.name + " | " + other.tag; 
        Debug.Log("trigger-hit : " + other.name);               
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
    private void HitDarkCloud(Collider2D other)
    {
        Die();
    }

    private void HitCoin(Collider2D other) {
        playerScore += 200;
        coinScore++;
        AudioSource.PlayClipAtPoint(getCoin,transform.position);
        other.gameObject.SetActive(false);
    }
    private void HitLife(Collider2D other) {
        playerScore += 300;
        lifeScore++;
        AudioSource.PlayClipAtPoint(getLife, transform.position);
        other.gameObject.SetActive(false);
    }
    private void HitBound(Collider2D other) {
        Die();
    }

    
    #endregion
}
