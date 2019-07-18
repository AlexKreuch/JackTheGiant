using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreMenuScript : MonoBehaviour
{
    [SerializeField]
    UnityEngine.UI.Text scoreText, coinText;

    private int StateSetter(string x, string y, bool shrinkText) {
        scoreText.text = x;
        coinText.text = y;
        if (shrinkText)
        {
            scoreText.fontSize = 45;
        }
        return 0;
    }
    private void TellManagerSceneStarted() {
        string s = GameManager.SceneChangeUtils.Tags.HIGHSCORE_SCREEN;
        System.Func<string, string,bool, int> f = StateSetter;
        GameManager.instance.TellManagerSomething(s,f);
    }

    void Start() {
        TellManagerSceneStarted();
    }

    public void BackToMain() {
        Fader.instance.FadeToNextScene("MainMenu00");
    }
}
