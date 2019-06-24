using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    #region scene-names
    private const string HighScore_sceneName = "HighScore00";
    private const string MainMenu_sceneName = "MainMenu00";
    private const string OptionsMenu_sceneName = "OptionsMenu";
    private const string GamePlay_sceneName = "Scene00";
    #endregion

    #region button-methods

    public void StartGame() {
        
    }
    public void Options() { }
    public void HighScore() { }
    public void Quit() { }
    public void Music() { }

    #endregion
    /**
buttons : 
start-game
options
high-score
quit
toggle-music
**/
}
