using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SS_01_tester : MonoBehaviour
{
    private class EntryParser {
        public static string ParseEscapeChars(string input) {

           
            string s = "";
            bool readingSpecialChar = false;
            foreach (char c in input)
            {
                if (readingSpecialChar)
                {
                    switch (c)
                    {
                        case 's': s += " "; break;
                        case 't': s += "~"; break;
                    }
                    readingSpecialChar = false;
                }
                else
                {
                    if (c == '~')
                        readingSpecialChar = true;
                    else
                        s += c;
                }
            }
            return s;
            
      
        }
        private static void ParseUtil(string input, ref int resultCode, string[] outStrings) {
            /*
             * outStrings must have length >=2
                resultCode-key :
                    0:=invalid input 
                    1:=SET-command
                    2:=GET-command
                    3:=CHANGE-command
                    4:=CLEAR_ALL-command
                    5:=SWITCH-command
                    6:=GET_INT-command
             */
            float f0 = 0f;
            bool b0 = false;
            resultCode = 0;
            string[] tokens = input.Split(' ');
            switch (tokens.Length)
            {
                case 0: return;
                case 1:
                    switch (input)
                    {
                        case "CHANGE": resultCode = 3; return;
                        case "CLEAR": resultCode = 4; return;
                        default: return;
                    }
                default: //tokens.Length >= 2
                    switch (tokens[0])
                    {
                        case "SET":
                            if (tokens.Length < 3) return;
                            resultCode = 1;
                            outStrings[0] = ParseEscapeChars(tokens[1]);
                            outStrings[1] = ParseEscapeChars(tokens[2]);
                            break;
                        case "GET":
                            resultCode = 2;
                            outStrings[0] = ParseEscapeChars(tokens[1]);
                            break;
                        case "SWITCH":
                            b0 = float.TryParse(tokens[1], out f0);
                            if (!b0 || f0<=0) return;
                            resultCode = 5;
                            outStrings[0] = tokens[1];
                            break;
                        case "GET_INT":
                            resultCode = 6;
                            outStrings[0] = ParseEscapeChars(tokens[1]);
                            break;
                    }
                    break;
            }
            
        }
        public enum ResultType { INVALID, SET, GET, CHANGE, CLEAR_ALL , SWITCH , GET_INT};
        public class Command
        {
            public ResultType resultType { get; private set; }
            public string key { get; private set; }
            public string val { get; private set; }
            public float time { get; private set; }
            private Command() { resultType = ResultType.INVALID; key = ""; val = ""; time = 0f; }
            private Command(ResultType rt, string k, string v) {
                resultType = rt;
                key = k;
                val = v;
                time = 0f;
            }
            private Command(ResultType rt, float t)
            {
                resultType = rt;
                key = "";
                val = "";
                time = t;
            }
            public static Command Create(string input)
            {
                float f0 = 0f;
                bool b0 = false;
                string[] strs = new string[] { "" , "" };
                int rc = -1;
                ParseUtil(input,ref rc, strs);
                ResultType rt = ResultType.GET;
                switch (rc)
                {
                    case 0: rt = ResultType.INVALID; break;
                    case 1: rt = ResultType.SET; break;
                    case 2: rt = ResultType.GET; break;
                    case 3: rt = ResultType.CHANGE; break;
                    case 4: rt = ResultType.CLEAR_ALL; break;
                    case 5:
                        rt = ResultType.SWITCH;
                        b0 = float.TryParse(strs[0],out f0);
                        return new Command(rt,f0);
                    case 6: rt = ResultType.GET_INT; break;
                }

                return new Command(rt,strs[0],strs[1]);
            }
        }
        public static Command ParseEntry(string input) { return Command.Create(input); }
    }
    
    private const string INIT_STR = "player-prefs initialized";
    void Start() {
        if (PlayerPrefs.HasKey(INIT_STR))
        {
            Debug.Log("STARTING OUT");
            PlayerPrefs.SetInt(INIT_STR,0);
        }
        else
        {
            Debug.Log("WELCOME BACK");
        }
    }

    public string command = "";
    public string display = "";
    public bool btn = false;

    private void Go() {
        if (btn)
        {
            btn = false;
            EntryParser.Command cmd = EntryParser.ParseEntry(command);
            switch (cmd.resultType)
            {
                case EntryParser.ResultType.INVALID: 
                    display = "!!!";
                    break;
                case EntryParser.ResultType.GET:
                    if (PlayerPrefs.HasKey(cmd.key))
                        display = PlayerPrefs.GetString(cmd.key);
                    else
                        display = "<~ NOT-FOUND ~>";
                    break;
                case EntryParser.ResultType.SET:
                    PlayerPrefs.SetString(cmd.key,cmd.val);
                    display = "<~ item-set ~>";
                    break;
                case EntryParser.ResultType.CHANGE:
                    SceneSwitcher.GetInstance().SwitchScenes();
                    break;
                case EntryParser.ResultType.CLEAR_ALL:
                    PlayerPrefs.DeleteAll();
                    display = "playerPrefs cleared";
                    break;
                case EntryParser.ResultType.SWITCH:
                    SceneSwitcher.GetInstance().SwitchScenes();
                    break;
                case EntryParser.ResultType.GET_INT:
                    if (PlayerPrefs.HasKey(cmd.key))
                        display = PlayerPrefs.GetInt(cmd.key).ToString();
                    else
                        display = "<~ INT-NOT-FOUND ~>";
                    break;
            }
        }
    }

    void ASDF(float t) {
        int changeTheScene() {
            SceneSwitcher.GetInstance().SwitchScenes();
            return 0;
        }
        int REPORT_OPACITY(float x) {
            display = x.ToString();
            return 0;
        }

        thing00.FADE_METHOD(t,changeTheScene,REPORT_OPACITY);
    }

    private string test0(string x) {
        string s = "";
        bool specialChar = false;
        foreach (char c in x)
        {
            if (specialChar)
            {
                switch (c)
                {
                    case 's': s += ' '; break;
                    case 't': s += '~'; break;
                }
                specialChar = false;
            }
            else
            {
                if (c == '~') specialChar = true;
                else s += c;
            }
        }
        return s;
    }
    private void test() {
        if (btn)
        {
            btn = false;
            display = test0(command) + '|' + EntryParser.ParseEscapeChars(command); // test0(command);
        }
    }

    private class SceneSwitcher {
        private static SceneSwitcher instance;
        public static SceneSwitcher GetInstance() {
            if (instance == null) instance = new SceneSwitcher();
            return instance;
        }

        private string otherSceneName = "";
        private bool SetUpDone = false;

        private SceneSwitcher() { }

        public void SetUp() {
            if (SetUpDone)
            {
                Debug.Log("ALREADY SETUP!");
            }
            else
            {
                void func(Scene scene, LoadSceneMode loadSceneMode) {
                    string s = "SampleScene_0";
                    string nm = scene.name;
                    Debug.Assert(nm.Length>0);
                    char c = nm[nm.Length - 1];
                    c = (c == '1') ? '2' : '1';
                    otherSceneName = s + c;
                }
                SceneManager.sceneLoaded += func;
                SetUpDone = true;
            }
        }

        public void SwitchScenes() {
            if (SetUpDone)
                SceneManager.LoadScene(otherSceneName);
            else
                Debug.Log("NOT SET UP!");
        }
    }

    void Awake() {
        SceneSwitcher.GetInstance().SetUp();
    }

  

    void Update() {
          Go();
    }

    
}
