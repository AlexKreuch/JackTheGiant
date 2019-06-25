using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Score : MonoBehaviour
{
    [SerializeField]
    private AudioClip getCoin, getLife, dieSound;

    private Vector2 previousPosition;
    public int playerScore = 0;
    public int coinScore = 0;
    public int lifeScore = 0;

    private bool trackPlayerScore = true;

    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerScore();
    }

    private void UpdatePlayerScore() {
        if (!trackPlayerScore) return;
        if (transform.position.y < previousPosition.y) playerScore++;
        previousPosition = transform.position;
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
