using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thing_02 : MonoBehaviour
{

    // OnCollisionEnter2D(Collision2D)
    public void OnCollisionEnter2D(Collision2D collision) {
        var t = ftos(Time.time);

        pushStr(string.Format(" me : {0} | you : {1} | time : {2} ",name,collision.collider.name,t));
    }

    private string ftos(float input, int n = 10) {
        void split(float x, ref int y, ref float z) {
            y = Mathf.FloorToInt(x);
            z = x - y;
        }
        char itoc(int x) { return ((char)(x+((int)'0'))); }
        if (input == 0) return "0";
        bool isNegative = input < 0;
        if (isNegative) input *= -1;
        int i0 = 0; float f0 = 0f;
        split(input, ref i0, ref f0);
        string res = i0.ToString();
        if (isNegative) res = '-' + res;
        if (f0 == 0) return res;
        res = res + '.';
        for (int i = 0; i < n; i++)
        {
            if (f0 == 0) break;
            f0 *= 10;
            split(f0, ref i0, ref f0);
            res += itoc(i0);
        }
        return res;
    }

    private static Queue<string> nms = new Queue<string>();

    private static int line = 0;
    private static void report(string s) {
        Debug.Log(line++ + " | " + s);
    }

    private static void pushStr(string msg) {
        if (nms.Count == 0) nms.Enqueue("collisions : ");
        nms.Enqueue(msg);
        report("count == " + nms.Count);
        if (nms.Count > 4) {
        var s = string.Join("\n      ",nms);
            Debug.Log(s);
        }
    }
}
