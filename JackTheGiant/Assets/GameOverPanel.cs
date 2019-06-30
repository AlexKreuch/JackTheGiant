using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text scoreText, coinsText;

   

  

    public void SetVals(int score, int coins) {
        scoreText.text = score.ToString();
        coinsText.text = coins.ToString();
    }
}
