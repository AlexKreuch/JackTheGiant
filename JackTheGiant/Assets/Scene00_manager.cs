using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene00_manager : MonoBehaviour
{
    public static Scene00_manager instance;

    public bool CanPauseWithPKey = true;

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

    private class DifficultySettingUtil {
        private static DifficultySettingUtil instance;
        private DifficultySettingUtil() { }
        public static DifficultySettingUtil GetInstance() {
            if (instance == null) instance = new DifficultySettingUtil();
            return instance;
        }

        /*
           Difficulty-setting adjustment plans : 
             -> max-Camera speed
             -> Max lives given
             -> probability of spawning a life
             -> probability of spawning a dark-cloud
         
          
           Current default vals : 
             -> max-Camera speed                      : 7
             -> Max lives given                       : 2
             -> probability of spawning a life        :  .5
             -> probability of spawning a dark-cloud  :  .5
             
             
             */

        #region Settings values

        #region easy-mode settings
        private const float EASY_MaxCamSpeed = 7f;
        private const int EASY_MaxLivesAllowed = 2;
        private const float EASY_LiveSpawnProbability = .5f;
        private const float EASY_DarkCloudSpawnProbability = .5f;
        #endregion

        #region medium-mode settings
        private const float MEDI_MaxCamSpeed = 7f;
        private const int MEDI_MaxLivesAllowed = 2;
        private const float MEDI_LiveSpawnProbability = .5f;
        private const float MEDI_DarkCloudSpawnProbability = .5f;
        #endregion

        #region hard-mode settings
        private const float HARD_MaxCamSpeed = 7f;
        private const int HARD_MaxLivesAllowed = 2;
        private const float HARD_LiveSpawnProbability = .5f;
        private const float HARD_DarkCloudSpawnProbability = .5f;
        #endregion

        #endregion

        #region SetDifficulty helpers
        private void SetMaxCameraSpeed(float maxSpeed) { CameraMover.instance.maxSpeed = maxSpeed; }
        private void SetMaxLives(int maxLives) {
            Collectibles.instance.DifficultyAdjustMent(0,maxLives);
        }
        private void SetlifeProb(float prob) {
            Collectibles.instance.DifficultyAdjustMent(1,prob);
        }
        private void SetDarkCloudProb(float prob) {
            CloudSpawner.instance.DifficultyAdjustMent(0,prob);
        }
        #endregion

        public void SetDifficulty(int difficultyLevel) {
            /*
             difficultyLevel must be from 0 to 2 inclusively, with : 0:=Easy , 1:=Medium , 2:=Hard
             */
            Debug.Assert(difficultyLevel>=0 && difficultyLevel<=2, "INVALID DIFFICULTY_LEVEL");
            // TODO : add implementation
            Debug.Log("difficulty-set : " + difficultyLevel);

            #region adjust settings 
            switch (difficultyLevel)
            {
                case 0:
                    SetMaxCameraSpeed(EASY_MaxCamSpeed);
                    SetMaxLives(EASY_MaxLivesAllowed);
                    SetlifeProb(EASY_LiveSpawnProbability);
                    SetDarkCloudProb(EASY_DarkCloudSpawnProbability);
                    break;
                case 1:
                    SetMaxCameraSpeed(MEDI_MaxCamSpeed);
                    SetMaxLives(MEDI_MaxLivesAllowed);
                    SetlifeProb(MEDI_LiveSpawnProbability);
                    SetDarkCloudProb(MEDI_DarkCloudSpawnProbability);
                    break;
                case 2:
                    SetMaxCameraSpeed(HARD_MaxCamSpeed);
                    SetMaxLives(HARD_MaxLivesAllowed);
                    SetlifeProb(HARD_LiveSpawnProbability);
                    SetDarkCloudProb(HARD_DarkCloudSpawnProbability);
                    break;
            }
            #endregion
        }
    }
    
    private const string MainMenu_sceneName = "MainMenu00";
    public const string SceneName = "Scene00";

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

    private int StateReseter(int scoreVal, int livesVAl, int coinsVal, int difficultyLevel) {
        /*
         * Note : negative values will be ignored
         */
        Debug.Assert(difficultyLevel < 3, "INVALID DIFFICULTY_LEVEL");
        if (scoreVal >= 0) player_Score.playerScore = scoreVal;
        if (livesVAl >= 0) player_Score.lifeScore = livesVAl;
        if (coinsVal >= 0) player_Score.coinScore = coinsVal;
        if (difficultyLevel >= 0) DifficultySettingUtil.GetInstance().SetDifficulty(difficultyLevel);
        return 0;
    }

    private void TellManagerSceneStarted() {
        System.Func<int, int, int, int,int> f = StateReseter;
        string s = GameManager.SceneChangeUtils.Tags.GAMEPLAY_LOADED;
        GameManager.instance.TellManagerSomething(s, f);
    }

    public void ExitToMainMenu()
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

        ReadyButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanPauseWithPKey && Input.GetKeyDown(KeyCode.P))
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
        SetPauseButtonOn(false);
    }
    public void UnPauseGame() {
        currentlyPaused = false;

        // unfreeze game (but only if the ready-button is inactive)
        if(!ReadyButton.IsActive()) Time.timeScale = 1f;

        // turn off PausePanel
        pausePanel.SetActive(false);
        SetPauseButtonOn(true);
    }

    public void PressQuit() {

        ExitToMainMenu();
    }

    public void PressReadyButton() {
        ReadyButton.gameObject.SetActive(false);
        Time.timeScale = 1f;


    }

    public void SetReadyButtonActive(bool x) {
        ReadyButton.gameObject.SetActive(x);
    }

    public void SetPauseButtonOn(bool x) {
        pauseButton.enabled = x;
        pauseButtonImage.enabled = x;
    }
    
   
}
