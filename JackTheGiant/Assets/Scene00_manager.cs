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

        public ScoreDisplayPanelController(System.Func<int,string> tds, System.Func<int> gv, UnityEngine.UI.Text txt) {
            text = txt;
            toDisplayString = tds;
            getValue = gv;

            currentValue = getValue();

            text.text = toDisplayString( currentValue );
        }

        public void update() {
            var x = getValue();
            if (currentValue != x)
            {
                currentValue = x;
                text.text = toDisplayString(currentValue);
            }
        }
    }

    
    [SerializeField]
    private Player_Score player_Score;

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
        foreach(var x in panelControllers) { x.update(); }
    }
}
