using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    #region scene-names
    private const string HighScore_sceneName = "HighScore00";
    private const string MainMenu_sceneName = "MainMenu00";
    private const string OptionsMenu_sceneName = "OptionsMenu";
    private const string GamePlay_sceneName = "Scene00";  
    #endregion

    #region button-methods

    public void StartGame() {SceneManager.LoadScene(GamePlay_sceneName);}
    public void Options() { SceneManager.LoadScene(OptionsMenu_sceneName); }
    public void HighScore() { SceneManager.LoadScene(HighScore_sceneName); }
    public void Quit() {Debug.Log("quit-button pushed");}
    public void Music() { Debug.Log("music-button pushed"); }

    #endregion
   
}
