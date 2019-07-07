using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public static GameManager instance;


    #region helper-classes/enums

    private class DataRecord {
        private Dictionary<string, int> intMap = new Dictionary<string, int>();
        private Dictionary<string, string> stringMap = new Dictionary<string, string>();
        private Dictionary<string, bool> boolMap = new Dictionary<string, bool>();
        private Dictionary<string, float> floatMap = new Dictionary<string, float>();

        public int GetInt(string nm) { return GetVal<int>(nm, intMap); }
        public string GetString(string nm) { return GetVal<string>(nm, stringMap); }
        public bool GetBool(string nm) { return GetVal<bool>(nm, boolMap); }
        public float GetFloat(string nm) { return GetVal<float>(nm, floatMap); }

        public void SetInt(string nm, int val) { SetVal<int>(nm, val, intMap); }
        public void SetString(string nm, string val) { SetVal<string>(nm, val, stringMap); }
        public void SetBool(string nm, bool val) { SetVal<bool>(nm, val, boolMap); }
        public void SetFloat(string nm, float val) { SetVal<float>(nm, val, floatMap); }

        public bool HasIntKey(string nm) { return HasKey<int>(nm, intMap); }
        public bool HasStringKey(string nm) { return HasKey<string>(nm, stringMap); }
        public bool HasBoolKey(string nm) { return HasKey<bool>(nm, boolMap); }
        public bool HasFloatKey(string nm) { return HasKey<float>(nm, floatMap); }

        private T GetVal<T>(string nm, Dictionary<string, T> dict) {

            dict.TryGetValue(nm, out T res);
            return res;
        }
        private void SetVal<T>(string nm, T val, Dictionary<string, T> dict)
        {
            dict[nm] = val;
        }
        private bool HasKey<T>(string nm, Dictionary<string, T> dict) { return dict.ContainsKey(nm); }
    }

    private class SituationCode {
        public bool have_scores_recorded;
        public bool received_rsad_headsup; // rsad:= ReStart After Death
        public enum Sit {
            UN_INITIALIZED,
            GAMEPLAY,
            MAIN_MENU,
            OPTIONS_MENU,
            HIGH_SCORE
        };
        public Sit sit;
        public SituationCode() {
            have_scores_recorded = false;
            received_rsad_headsup = false;
            sit = Sit.UN_INITIALIZED;
        }
    };

    private enum DifficultySetting { EASY, MEDIUM, HARD }

    public static class SceneChangeUtils {
        public static class Tags {
            public const string GAMEPLAY_LOADED = "scene00 just loaded";
            public const string GAME_RESTARTED = "game restarted after death";
            public const string EXIT_GAMEPLAY = "now exiting gamePlay";
            public const string HIGHSCORE_SCREEN = "highScore display opened";
            public const string OPTIONS = "options_screen";
            public const string SAVE_OPTION = "save the selected difficulty";
        }

    }

    #endregion

    private int HighScore = 0;
    private int HighCoinScore = 0;
    private SituationCode situationCode = new SituationCode();
    private DifficultySetting difficulty = DifficultySetting.MEDIUM;
    private DataRecord dataRecord = new DataRecord();


    void Awake() {
        MakeInstance();
        DataPreserver.GetInstance().LoadData();
    }

    

    private void MakeInstance() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            GameObject.Destroy(this);

    }

    public void TellManagerSomething(string info, object data) {
        switch (info)
        {
            case SceneChangeUtils.Tags.GAMEPLAY_LOADED: GamePlayStarted(data); break;
            case SceneChangeUtils.Tags.GAME_RESTARTED: AboutToRestartedAfterDeath(data); break;
            case SceneChangeUtils.Tags.EXIT_GAMEPLAY: ExitingGamePlay(data); break;
            case SceneChangeUtils.Tags.HIGHSCORE_SCREEN: HighScoreScreen(data); break;
            case SceneChangeUtils.Tags.OPTIONS: OptionsScreen(data); break;
            case SceneChangeUtils.Tags.SAVE_OPTION: SaveOption(data); break;

        }
    }

    #region scene-change helpers
    private void GamePlayStarted(object data) {
        /**
         
         data is expected to be a function (int,int,int) -> int, 
         which we may use to set the score, lives, and coins of the player respectively.
         
         we only need to set these values if this comes after the 'ready-button' has been pushed.
         */


        // set the situation code;
        situationCode.sit = SituationCode.Sit.GAMEPLAY;

        if (situationCode.received_rsad_headsup)
        {
            situationCode.received_rsad_headsup = false;

            System.Func<int, int, int, int> setter = (System.Func<int, int, int, int>)data;
            setter(dataRecord.GetInt("score"), dataRecord.GetInt("lives"), dataRecord.GetInt("coins"));
        }

    }
    private void AboutToRestartedAfterDeath(object data) {
        /*
         data is expected to be an array of 3 ints containing the score, lives, and coins of the player respectively
         
         */
        situationCode.received_rsad_headsup = true;
        int[] slc = (int[])data;
        int s = slc[0], l = slc[1], c = slc[2];
        if (situationCode.have_scores_recorded)
        {
            if (s > HighScore) HighScore = s;
            if (c > HighCoinScore) HighCoinScore = c;
        }
        else
        {
            HighScore = s;
            HighCoinScore = c;
            situationCode.have_scores_recorded = true;

        }
        dataRecord.SetInt("score", s);
        dataRecord.SetInt("lives", l);
        dataRecord.SetInt("coins", c);

        DataPreserver.GetInstance().SaveData();
    }
    private void ExitingGamePlay(object data) {
        /*
          data is expected to be an array of two integers containing the 
          current player-score, and coin-score respectively
         */
        int[] sc = (int[])data;
        int s = sc[0], c = sc[1];
        if (situationCode.have_scores_recorded)
        {
            if (s > HighScore) HighScore = s;
            if (c > HighCoinScore) HighCoinScore = c;
        }
        else
        {
            HighScore = s;
            HighCoinScore = c;
            situationCode.have_scores_recorded = true;
        }
    }
    private void HighScoreScreen(object data)
    {
        /*
             data is expected to be a deligate (string,string,bool) -> int 
             for settting the scoreText and coinText fields respectively.
             if the final parameter is set to true, then the fontSize of the High-score text
             will be reset to 45 (to fit message)
         */
        situationCode.sit = SituationCode.Sit.HIGH_SCORE;
        System.Func<string, string, bool, int> setter = (System.Func<string, string, bool, int>)data;
        if (situationCode.have_scores_recorded)
        {
            setter(HighScore.ToString(), HighCoinScore.ToString(), false);
        }
        else
        {
            setter("NO-SCORES RECORDED YET", "---", true);
        }
    }
    private void OptionsScreen(object data)
    {
        /*
             data is expected to be a function : int -> int.
             This function is used to set the currently selected options by :
             0:=Easy, 1:=Medium, 2:=Hard
         */
        situationCode.sit = SituationCode.Sit.OPTIONS_MENU;
        System.Func<int, int> setter = (System.Func<int, int>)data;
        switch (difficulty)
        {
            case DifficultySetting.EASY: setter(0); break;
            case DifficultySetting.MEDIUM: setter(1); break;
            case DifficultySetting.HARD: setter(2); break;
        }
    }
    private void SaveOption(object data)
    {
        /*
         data is expected to be an int from 0 to 2 (inclusively).
         */
        int m = (int)data;
        Debug.Assert(m >= 0 && m <= 2);
        switch (m)
        {
            case 0: difficulty = DifficultySetting.EASY; break;
            case 1: difficulty = DifficultySetting.MEDIUM; break;
            case 2: difficulty = DifficultySetting.HARD; break;
        }
    }
    #endregion

    private class DataPreserver{
        private static DataPreserver instance;

        private DataPreserver() { }
        public static DataPreserver GetInstance() {
            if (instance == null)
            {
                instance = new DataPreserver();
                if (!PlayerPrefs.HasKey(isInit)) instance.initial_setup();
            }
            return instance;
        }

        // field-names have the form : <coins/score/HaveSavedScores> + <difficulty-mode>
        
        #region constant-strings
        const string currentMode = "difficulty-setting";
        const string HaveSavedScores = "scoresHaveBeenSaved";
        const string coins = "coins";
        const string score = "score";
        const string easyMode = "easy";
        const string mediMode = "medium";
        const string hardMode = "hard";
        const string isInit = "this has been initialized";
        #endregion

        private void initial_setup(){
            string[] sarr0 = new string[] { coins , score , HaveSavedScores };
            string[] sarr1 = new string[] { easyMode, mediMode, hardMode };
            for (int i = 0; i < 9; i++)
            {
                string s = sarr0[i % 3] + sarr1[i / 3];
                PlayerPrefs.SetInt(s,0);
            }
            PlayerPrefs.SetInt(isInit, 0);
            PlayerPrefs.SetInt(currentMode,1);
        }
        public void SaveData()
        {
            /*
              This method assumes that the 'difficulty-mode' (DM) saved in PlayerPrefs ALREADY agrees with the 
              DM saved in the GameManager, and so this method does NOT change change the current DM saved in PlayerPrefs.
              
             */
            int difficultyMode_int = PlayerPrefs.GetInt(currentMode);
            string difficultyMode_str = "";
            switch (difficultyMode_int)
            {
                case 0: difficultyMode_str = easyMode; break;
                case 1: difficultyMode_str = mediMode; break;
                case 2: difficultyMode_str = hardMode; break;
            }
            PlayerPrefs.SetInt(coins + difficultyMode_str,GameManager.instance.HighCoinScore);
            PlayerPrefs.SetInt(score + difficultyMode_str, GameManager.instance.HighScore);
            PlayerPrefs.SetInt(HaveSavedScores + difficultyMode_str, GameManager.instance.situationCode.have_scores_recorded ? 1 : 0);
        }
        public void LoadData() {
            /*
             Unlike SaveData (above), this method does not assume that the 'difficulty-mode' (DM) saved in PlayerPrefs already agrees with the 
             DM saved in the GameManager, and so this method will update the DM in GameManager if needed.
             */
            int difficultyMode_int = PlayerPrefs.GetInt(currentMode);
            string difficultyMode_str = "";
            switch (difficultyMode_int)
            {
                case 0: difficultyMode_str = easyMode; GameManager.instance.difficulty = DifficultySetting.EASY; break;
                case 1: difficultyMode_str = mediMode; GameManager.instance.difficulty = DifficultySetting.MEDIUM; break;
                case 2: difficultyMode_str = hardMode; GameManager.instance.difficulty = DifficultySetting.HARD; break;
            }
            GameManager.instance.HighCoinScore = PlayerPrefs.GetInt(coins + difficultyMode_str);
            GameManager.instance.HighScore = PlayerPrefs.GetInt(score + difficultyMode_str);
            GameManager.instance.situationCode.have_scores_recorded = PlayerPrefs.GetInt(HaveSavedScores + difficultyMode_str)==1;
        }
        public void SwitchSetting(int setting)
        {
            /*
             WARNING : this method will delete any data not-already saved in the CURRENT difficulty-setting.
             */
            Debug.Assert(setting >= 0 && setting < 2, "INVALID-SETTING");
            PlayerPrefs.SetInt(currentMode,setting);
            string difficultyMode_str = "";
            switch (setting)
            {
                case 0: difficultyMode_str = easyMode; GameManager.instance.difficulty = DifficultySetting.EASY; break;
                case 1: difficultyMode_str = mediMode; GameManager.instance.difficulty = DifficultySetting.MEDIUM; break;
                case 2: difficultyMode_str = hardMode; GameManager.instance.difficulty = DifficultySetting.HARD; break;
            }
            GameManager.instance.HighCoinScore = PlayerPrefs.GetInt(coins + difficultyMode_str);
            GameManager.instance.HighScore = PlayerPrefs.GetInt(score + difficultyMode_str);
            GameManager.instance.situationCode.have_scores_recorded = PlayerPrefs.GetInt(HaveSavedScores + difficultyMode_str) == 1;
        }
    }


}
