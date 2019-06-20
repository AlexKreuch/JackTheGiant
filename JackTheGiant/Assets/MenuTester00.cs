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
    }
    private void push_sudo_button() {
        switch (sudoInput) {
            case "": break;
            case "chkComp": helper0(); break;
            case "chkRect": helper1(); break;
            case "tryReset": helper2();  break;
            case "tryReset-c": helper3(); break;
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
}
