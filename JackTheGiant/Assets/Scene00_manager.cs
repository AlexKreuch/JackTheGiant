using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene00_manager : MonoBehaviour
{
    public static Scene00_manager instance;

    private class ScoreDisplayPanelController {
        private UnityEngine.UI.Text text;
        private System.Func<int, string> toDisplayString;
        private System.Func<int> getValue;

        private int currentValue;

        public bool TurnedOn { get; set; }

        public ScoreDisplayPanelController(System.Func<int, string> tds, System.Func<int> gv, UnityEngine.UI.Text txt) {
            text = txt;
            toDisplayString = tds;
            getValue = gv;

            currentValue = getValue();

            TurnedOn = true;

            text.text = toDisplayString(currentValue);
        }

        public void Update() {
            if (TurnedOn)
            {
                var x = getValue();
                if (currentValue != x)
                {
                    currentValue = x;
                    text.text = toDisplayString(currentValue);
                }
            }
        }
    }

    private const string MainMenu_sceneName = "MainMenu00";
    private const string this_sceneName = "Scene00";

    [SerializeField]
    private GameObject pausePanel, player;

    [SerializeField]
    private UnityEngine.UI.Button pauseButton, ReadyButton;

    private Player_Score player_Score;
    private UnityEngine.UI.Image pauseButtonImage;

    private bool currentlyPaused = false;

    #region ScoreDisplayPanelController fields

    #region outer text-fields
    [SerializeField]
    private UnityEngine.UI.Text scoreText_SDPC, lifeText_SDPC, coinText_SDPC;
    #endregion

    #region declare panel-controllers
    private ScoreDisplayPanelController scorePanelController, coinPanelController, lifePanelController;
    #endregion

    #region delegates for the panels

    private int getLife_SDPC() { return player_Score.lifeScore; }
    private int getCoin_SDPC() { return player_Score.coinScore; }
    private int getScore_SDPC() { return player_Score.playerScore; }

    private string displayLifexCoin_SDPC(int x) { return string.Format("x{0}", x); }

    private string displayScore_SDPC(int x) { return string.Format("{0}", x); }
    #endregion

    ScoreDisplayPanelController[] panelControllers;

    #endregion

    #region SceneChange helpers

    private int StateReseter(int scoreVal, int livesVAl, int coinsVal) {
        player_Score.playerScore = scoreVal;
        player_Score.lifeScore = livesVAl;
        player_Score.coinScore = coinsVal;
        return 0;
    }

    private void TellManagerSceneStarted() {
        System.Func<int, int, int, int> f = StateReseter;
        string s = GameManager.SceneChangeUtils.Tags.GAMEPLAY_LOADED;
        GameManager.instance.TellManagerSomething(s, f);
    }

    private void ExitToMainMenu()
    {
        GameManager.instance.TellManagerSomething
           (
               GameManager.SceneChangeUtils.Tags.EXIT_GAMEPLAY,
               new int[] { player_Score.playerScore, player_Score.coinScore }
           );
        SceneManager.LoadScene(MainMenu_sceneName);
        Time.timeScale = 1f;
    }

    #endregion

    void Awake() {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);

        player_Score = player.GetComponent<Player_Score>();
        pauseButtonImage = pauseButton.GetComponent<UnityEngine.UI.Image>();

        #region  initialize panelControllers
        lifePanelController = new ScoreDisplayPanelController(displayLifexCoin_SDPC, getLife_SDPC, lifeText_SDPC);
        coinPanelController = new ScoreDisplayPanelController(displayLifexCoin_SDPC, getCoin_SDPC, coinText_SDPC);
        scorePanelController = new ScoreDisplayPanelController(displayScore_SDPC, getScore_SDPC, scoreText_SDPC);

        panelControllers = new ScoreDisplayPanelController[] { lifePanelController, coinPanelController, scorePanelController };
        #endregion

        TellManagerSceneStarted();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (currentlyPaused) UnPauseGame(); else PauseGame();
        }
        foreach (var x in panelControllers) { x.Update(); }
    }

    public void PauseGame() {
        currentlyPaused = true;

        // freeze the game
        Time.timeScale = 0f;

        // turn on PausePanel
        pausePanel.SetActive(true);
        pauseButton.enabled = false;
        pauseButtonImage.enabled = false;
    }
    public void UnPauseGame() {
        currentlyPaused = false;

        // unfreeze game
        Time.timeScale = 1f;

        // turn off PausePanel
        pausePanel.SetActive(false);
        pauseButton.enabled = true;
        pauseButtonImage.enabled = true;
    }

    public void PressQuit() {

        ExitToMainMenu();
    }

    public void PressReadyButton() {
        GameManager.instance.TellManagerSomething
            (
            GameManager.SceneChangeUtils.Tags.READYBUTTON_PUSHED,
            new int[] { player_Score.playerScore, player_Score.lifeScore, player_Score.coinScore }
            );
        SceneManager.LoadScene(this_sceneName);
    }

    public void SetReadyButtonActive(bool x) {
        ReadyButton.gameObject.SetActive(x);
    }

    
   
}
