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
        string y = "<   >" + Comp1(x);
        Debug.Log(y);
    }
    private int[] Comp0(string inp) {
        int[] res = new int[] { 0 , 0 , 0 , 0 };
        string[] tokens = inp.Split(',');
        if (tokens.Length != 3) { return res; }
        for (int i = 0; i < 3; i++)
        {
            bool flg = int.TryParse(tokens[i].Trim() , out res[i+1]);
            if (!flg) return res;
        }
        res[0] = 1;
        return res;
    }
    private string Comp1(string inp)
    {
        int[] data = Comp0(inp);
        if (data[0] == 0) return "INVALID";
        int x = Mathf.Clamp(data[1], data[2], data[3]);

        return string.Format("Mathf.Clamp({0},{1},{2}) = {3}" , data[1] , data[2] , data[3] , x);
    }
}
 