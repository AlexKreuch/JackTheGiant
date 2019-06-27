using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene00_manager : MonoBehaviour
{
    private class ScoreDisplayPanelController {
        private UnityEngine.UI.Text text;
        private System.Func<int,string> toDisplayString;
        private System.Func<int> getValue;

        private int currentValue;

        public bool TurnedOn { get; set; }

        public ScoreDisplayPanelController(System.Func<int,string> tds, System.Func<int> gv, UnityEngine.UI.Text txt) {
            text = txt;
            toDisplayString = tds;
            getValue = gv;

            currentValue = getValue();

            TurnedOn = true;

            text.text = toDisplayString( currentValue );
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

    
    [SerializeField]
    private GameObject pausePanel, player;

    [SerializeField]
    private UnityEngine.UI.Button pauseButton;

    private Rigidbody2D playerBody;
    private Animator playerAnimator;
    private Player_Score player_Score;
    private CameraMover cameraMover;
    private player00_script playerController;
    private UnityEngine.UI.Image pauseButtonImage;

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

    private string displayLifexCoin_SDPC(int x) { return string.Format("x{0}",x); }

    private string displayScore_SDPC(int x) { return string.Format("{0}",x); }
    #endregion

    ScoreDisplayPanelController[] panelControllers;

    #endregion

    

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);

        playerController = player.GetComponent<player00_script>();
        playerBody = player.GetComponent<Rigidbody2D>();
        playerAnimator = player.GetComponent<Animator>();
        player_Score = player.GetComponent<Player_Score>();
        cameraMover = Camera.main.GetComponent<CameraMover>();
        pauseButtonImage = pauseButton.GetComponent<UnityEngine.UI.Image>();

        #region  initialize panelControllers
        lifePanelController = new ScoreDisplayPanelController(displayLifexCoin_SDPC, getLife_SDPC, lifeText_SDPC);
        coinPanelController = new ScoreDisplayPanelController(displayLifexCoin_SDPC, getCoin_SDPC, coinText_SDPC);
        scorePanelController = new ScoreDisplayPanelController(displayScore_SDPC, getScore_SDPC, scoreText_SDPC);

        panelControllers = new ScoreDisplayPanelController[] { lifePanelController, coinPanelController, scorePanelController };
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var x in panelControllers) { x.Update(); }
    }

    private void PauseGame() {
        // freeze the game
        foreach(var x in panelControllers) { x.TurnedOn = false; }
        cameraMover.enabled = false;
        playerBody.constraints = RigidbodyConstraints2D.FreezeAll;
        playerAnimator.enabled = false;
        playerController.UpdateDirection = false;

        // turn on PausePanel
        pausePanel.SetActive(true);
        pauseButton.enabled = false;
        pauseButtonImage.enabled = false;
    }
    private void UnPauseGame() {
        // unfreeze game
        foreach (var x in panelControllers) { x.TurnedOn = true; }
        cameraMover.enabled = true;
        playerBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        playerAnimator.enabled = true;
        playerController.UpdateDirection = true;

        // turn off PausePanel
        pausePanel.SetActive(false);
        pauseButton.enabled = true;
        pauseButtonImage.enabled = true;
    }
}
