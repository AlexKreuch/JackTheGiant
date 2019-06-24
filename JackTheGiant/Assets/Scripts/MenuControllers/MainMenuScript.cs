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

    public void StartGame() { Debug.Log("start-button pushed"); }
    public void Options() { Debug.Log("options-button pushed"); }
    public void HighScore() { Debug.Log("highScore-button pushed"); }
    public void Quit() { Debug.Log("quit-button pushed"); }
    public void Music() { Debug.Log("music-button pushed"); }

    #endregion
   
}
