﻿using System.Collections;
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

        private T GetVal<T>( string nm , Dictionary<string,T> dict) {

            dict.TryGetValue(nm, out T res);
            return res;
        }
        private void SetVal<T>(string nm , T val , Dictionary<string,T> dict)
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
            public const string READYBUTTON_PUSHED = "ready-button pushed";
            public const string EXIT_GAMEPLAY = "now exiting gamePlay";
            public const string HIGHSCORE_SCREEN = "highScore display opened";
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

    public void TellManagerSomething(string info , object data) {
        switch (info)
        {
            case SceneChangeUtils.Tags.GAMEPLAY_LOADED: GamePlayStarted(data); break;
            case SceneChangeUtils.Tags.READYBUTTON_PUSHED:ReadyButtonPushed(data); break;
            case SceneChangeUtils.Tags.EXIT_GAMEPLAY: ExitingGamePlay(data); break;
            case SceneChangeUtils.Tags.HIGHSCORE_SCREEN:HighScoreScreen(data); break;
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
    private void ReadyButtonPushed(object data) {
        /*
         data is expected to be an array of 3 ints containing the score, lives, and coins of the player respectively
         
         */
        Debug.Log("ready-button reported");
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
        System.Func<string, string, bool,int> setter = (System.Func<string, string,bool, int>)data;
        if (situationCode.have_scores_recorded)
        {
            setter(HighScore.ToString(), HighCoinScore.ToString(),false);
        }
        else
        {
            setter("NO-SCORES RECORDED YET" , "---", true);
        }
    }
    #endregion


}
