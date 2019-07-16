using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public static Fader instance;

    void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    void Start() {
        Image image = GetComponentInChildren<Image>();
        bool b = ReportStatus(image,"theImage");
        if (b)
        {
            GameObject panel = image.gameObject;
            ReportStatus(panel,"thePanel");
        }
    }

    private bool ReportStatus(Object obj, string title) {
        bool res = obj != null;
        if (res) Debug.Log(string.Format("{0} found | name == {1}", title, obj.name));
        else Debug.Log(title + " not-found");
        return res;
    }
    // GIFSMU := Get Info From State Machine Util
    public class GIFSMU {
        public enum Tag { IN , OUT , IDLE };
        private static int state = 0;

        private static int Tag_to_Int(Tag t) {
            switch (t)
            {
                case Tag.IN: return 1;
                case Tag.OUT: return 2;
                case Tag.IDLE: return 4;
                default: return -1;     
            }
        }

        public static void Set(Tag t, bool x)
        {
            int tag_int = Tag_to_Int(t);
            if (x) state = state | tag_int;
            else state = state & (~tag_int);
        }

        public static bool Get(Tag t)
        {
            int tag_int = Tag_to_Int(t);
            return (state & tag_int) != 0;
        }
        public static bool GetFadeIn() { return Get(Tag.IN); }
        public static bool GetFadeOut() { return Get(Tag.OUT); }
        public static bool GetIdle() { return Get(Tag.IDLE); }


 
    }

    public bool[] tester = new bool[3];

    private void updateTesters() {
        tester[0] = GIFSMU.GetFadeIn();
        tester[1] = GIFSMU.GetFadeOut();
        tester[2] = GIFSMU.GetIdle();
    }

    void Update() { updateTesters(); }

}
