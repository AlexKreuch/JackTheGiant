using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tester00 : MonoBehaviour
{
   
    private InputField input;

    
    
    public void Start() {
        input = (InputField)gameObject.GetComponentInChildren(typeof(InputField));

        
    }
    public void ButtonPress() {
        string x = input.text;
        string y = Compute(x);
        Debug.Log(y);
    }

    struct GenType {
       public readonly char tcode;
       public readonly object data;
       private bool hasMess;
       private string mess;
       public GenType(char t, object d) { tcode = t; data = d; hasMess = false; mess = ""; }
        public GenType(char t, object d, string m)
        {
            tcode = t; data = d; hasMess = true; mess = m;
        }
       public string Q(string q) {
            switch (q)
            {
                case "has_mess": return hasMess ? "yes" : "no";
                case "get_mess": return mess;
                default: return "";
            }
        }
    }
    GenType MyTryParse(string inp)
    {
        if (inp.Length == 0) return new GenType('_',null);
        char tp = inp[0];
        inp = inp.Substring(1);
        bool flg = false; int i0 = 0; float f0 = 0f;
        object obj = null;
        switch (tp)
        {
            case 'i':
                flg = int.TryParse(inp,out i0);
                if (flg) obj = i0;
                break;
            case 'f':
                flg = float.TryParse(inp,out f0);
                if (flg) obj = f0;
                break;
        }
        char code = flg ? tp : '_';
        return new GenType(code,obj);
    }
    GenType TryRandRange(char tp, GenType g1, GenType g2) {
        int senarioCode(char a, GenType b, GenType c) {
            char[] co = new char[] { a, b.tcode, c.tcode};
            int r = 0, p = 1;
            for (int i = 0; i < 3; i++)
            {
                switch (co[i])
                {
                    case 'i': break;
                    case 'f': r += p; break;
                    default: return -1;
                }
                p *= 2;
            }
            return r;
        }
        string makeMessage(object a, GenType b, GenType c, string d)
        {
            if (d.Length != 3) return "<ERROR>";
            return string.Format("{0}{3}~=RR({1}{4}, {2}{5})",a,b.data,c.data,d[0],d[1],d[2]);
        }
        int sc = senarioCode(tp,g1,g2);
        int i0 = 0; float f0 = 0f;
        char t0 = '_'; object obj = null;
        string m0 = "";
        switch (sc)
        {
            case -1: return new GenType('_',null,"invalid input");
            case 0:
                i0 = Random.Range((int)g1.data,(int)g2.data);
                obj = i0; t0 = 'i'; m0 = makeMessage(obj,g1,g2,"iii");
                break;
            case 1:
                f0 = Random.Range((int)g1.data, (int)g2.data);
                obj = f0; t0 = 'f'; m0 = makeMessage(obj, g1, g2, "fii");
                break;
            case 2: return new GenType(t0,obj,"i=RR(f,i) ==> invalid");
            case 3: 
                f0 = Random.Range((float)g1.data, (int)g2.data);
                obj = f0; t0 = 'f'; m0 = makeMessage(obj, g1, g2, "ffi");
                break;
            case 4: return new GenType(t0, obj, "i=RR(i,f) ==> invalid");
            case 5:
                f0 = Random.Range((int)g1.data, (float)g2.data);
                obj = f0; t0 = 'f'; m0 = makeMessage(obj, g1, g2, "fif");
                break;
            case 6: return new GenType(t0, obj, "i=RR(f,f) ==> invalid");
            case 7:
                f0 = Random.Range((float)g1.data, (float)g2.data);
                obj = f0; t0 = 'f'; m0 = makeMessage(obj, g1, g2, "fff");
                break;
            default: return new GenType(t0, obj, "invalid senario-code");
        }

        return new GenType(t0,obj,m0);
    }
    string Compute(string inp)
    {
        string[] tokens = inp.Split('|');
        if (tokens.Length != 3) return "<INVALID>-[bad-length]";
        if(tokens[0]!="i" && tokens[0]!="f") return "<INVALID>-[bad-start]";
        GenType g1 = MyTryParse(tokens[1]);
        if(g1.tcode=='_') return "<INVALID>-[1st-term]";
        GenType g2 = MyTryParse(tokens[2]);
        if (g2.tcode == '_') return "<INVALID>-[2nd-term]";
        GenType g3 = TryRandRange(tokens[0][0],g1,g2);
        if (g3.tcode == '_') return "oops | " + g3.Q("get_mess");
        return "success | " + g3.Q("get_mess");
    }
}
 