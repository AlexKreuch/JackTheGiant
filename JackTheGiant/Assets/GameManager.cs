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

    #endregion

    private int HighScore = 0;
    private SituationCode situationCode = new SituationCode();
    private DifficultySetting difficulty = DifficultySetting.MEDIUM;
    private DataRecord dataRecord = new DataRecord();
   

    void Awake() {
        MakeInstance();
    }

    private void MakeInstance() {
        if (instance == null)
            instance = this;
        else
            GameObject.Destroy(this);
    }



    public void HitReadyButton() {
        
    }

   
}
