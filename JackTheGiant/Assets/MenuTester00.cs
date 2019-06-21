using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTester00 : MonoBehaviour
{
    public bool sudoButton = false;
    public string sudoInput = "";

    private float camH = 0f;
    private float camW = 0f;
    private void Compute_camD() {
        camH = 2f * Camera.main.orthographicSize;
        camW = (camH / Screen.height) * Screen.width * Camera.main.rect.width;
    }
    private RectTransform ResetScale() {
        var rt = GetComponent<RectTransform>();
        rt.rect.Set(rt.rect.x,rt.rect.y,camW,camH);
        return rt;
    }
    // Start is called before the first frame update
    void Start()
    {
        Compute_camD();
    }

    // Update is called once per frame
    void Update()
    {
        if (sudoButton)
        {
            sudoButton = false;
            push_sudo_button();
        }
        maintain_scale();
    }
    private RectTransform RT;
    private void maintain_scale() {
        if (RT == null)
        {
            RT = GetComponent<RectTransform>();
        }
        Vector2 vector = RT.localScale;
        if (vector.x != vector.y)
        {
            vector.x = vector.y;
            RT.localScale = vector;
        }
    }
    private void push_sudo_button() {
        string[] tokens = Custom_helper0(sudoInput,'_');

        switch (tokens[0]) {
            case "": break;
            case "chkComp": helper0(); break;
            case "chkRect": helper1(); break;
            case "tryReset": helper2();  break;
            case "tryReset-c": helper3(); break;
            case "custom": Custom(tokens[1]); break;
            default: Debug.Log("not-recognized"); break;
        }
    }
    private void helper0() {
        Debug.Log(string.Format("camW={0} | camH={1}",camW,camH));
    }
    private void helper1() {
        var rct = GetComponent<RectTransform>().rect;
        Debug.Log("rect = " + rct);
    }
    private void helper2() {
        ResetScale();
        Debug.Log("ran ResetScale()");
    }
    private void helper3() {
        var rt = ResetScale();
        Debug.Log("ran ResetScale ; new rect should be : " + rt.rect);
    }

    private void Custom(string inp) {
        void tool(string code, out bool itWorked, out RectTransform.Axis ax, out float v) {
            ax = RectTransform.Axis.Horizontal;
            v = 0f;
            itWorked = false;
            if (code.Length < 2) return;
            switch (code[0])
            {
                case 'h': break;
                case 'v': ax = RectTransform.Axis.Vertical; break;
                default: return;
            }
            itWorked = float.TryParse(code.Substring(1),out v);

        }
        var r = GetComponent<RectTransform>();
        tool(inp, out bool flg, out RectTransform.Axis axis, out float val);
        if (!flg) { Debug.Log("oops"); return; }
        r.SetSizeWithCurrentAnchors(axis,val);
        Debug.Log("did-thing");
    }
    private string[] Custom_helper0(string inp, char div) {
        string[] tokens = inp.Split(div);
        if (tokens.Length == 0) return new string[] { "", "" };
        if (tokens.Length == 1) return new string[] { tokens[0], "" };
        string s = tokens[1];
        for (int i = 2; i < tokens.Length; i++) s += div + tokens[i];
        return new string[] { tokens[0] , s };
    }
}
