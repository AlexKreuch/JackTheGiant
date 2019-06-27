using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Scene00_tester : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    public bool Pauser = false;
    public bool addV = false;
    public bool chkV = false;
    

    public string inp = "";
    public string dsp = "";

    void Update() {
        CheckForPush(Push_pause,ref Pauser);
        CheckForPush(Push_addV, ref addV);
        CheckForPush(Push_chkV, ref chkV);
    }

    private int Push_pause() {
        Time.timeScale = 1 - Time.timeScale;
        return 0;
    }
    private int Push_addV() {

        object[] data = ParseTheInput();

        if (!((bool)(data[0])))
        {
            inp = inp + "!";
            return 0;
        }

        inp = inp + "$";

        Vector2 VtoAdd = new Vector2( (float)data[1] , (float)data[2] );

        body.velocity += VtoAdd;

        return 1;
    }
    private int Push_chkV() {
        dsp = string.Format("{0}",body.velocity);
        return 0;
    }

    private void CheckForPush( System.Func<int> push_method , ref bool push_flag ) {
        if (push_flag)
        {
            push_method();
            push_flag = false;
        }
    }

    private object[] ParseTheInput() {
        const char good_c = '$';
        const char bad_c = '!';
        
        string[] tok0 = inp.Split(',');
        int i0  = 0;
        float fl0 = 0f, fl1 = 0f;
        bool b0 = false;
        if (tok0.Length != 2) return new object[] { false };

        b0 = float.TryParse(tok0[0].Trim(), out fl0);

        if(!b0) return new object[] { false };

        tok0[1] = tok0[1].Trim();

        i0 = tok0[1].Length;
        while (--i0 >= 0) if (tok0[1][i0] != good_c && tok0[1][i0] != bad_c) break;
        if(i0==-1) return new object[] { false };

        tok0[1] = tok0[1].Substring(0, i0 + 1).Trim();

        b0 = float.TryParse(tok0[1],out fl1);

        if (!b0) return new object[] { false };

        return new object[] { true , fl0, fl1 };
    }
}