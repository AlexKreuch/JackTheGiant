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
             */
            resultCode = 0;
            string[] tokens = input.Split(' ');
            if (tokens.Length < 2) return;
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
            }
        }
        public enum ResultType { INVALID, SET, GET };
        public class Command
        {
            public ResultType resultType { get; private set; }
            public string key { get; private set; }
            public string val { get; private set; }
            private Command() { resultType = ResultType.INVALID; key = ""; val = ""; }
            private Command(ResultType rt, string k, string v) {
                resultType = rt;
                key = k;
                val = v;
            }
            public static Command Create(string input)
            {
                string[] strs = new string[] { "" , "" };
                int rc = -1;
                ParseUtil(input,ref rc, strs);
                ResultType rt = ResultType.GET;
                switch (rc)
                {
                    case 0: rt = ResultType.INVALID; break;
                    case 1: rt = ResultType.SET; break;
                    case 2: rt = ResultType.GET; break;
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
            }
        }
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

    void Update() {
          Go();
      //  test();
    }
}
