using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[ExecuteAlways]
public class Scene00_tester00 : MonoBehaviour
{

    public Vector3 buttonPos = new Vector3();
    private class GetButton {
        private const string btnName = "Left_button";
        private static Button lftButton = null;
        private static RectTransform rectTransform = null;
        public static Button Get() {
            if (lftButton == null)
            {
                var obs = FindObjectsOfType<Button>();
                foreach (Button x in obs) if (x.tag == btnName)
                    {
                        lftButton = x;
                        break;
                    }

            }
            return lftButton;
        }
        public static RectTransform GetRT() {
            if (rectTransform == null)
            {
                var button = Get();
                rectTransform = button.GetComponent<RectTransform>();
            }
            return rectTransform;
        }
    }
    private class GetCanvas{
        private static Canvas canvas = null;
        public static Canvas Get() {
            if (canvas == null)
            {
                var js = FindObjectOfType<JoyStick>();
                canvas = js.GetComponentInChildren<Canvas>();
            }
            return canvas;
        }

    }

    public bool btn = false;
    private void pressButton() {
        float hh = Camera.main.orthographicSize / GetCanvas.Get().transform.localScale.x;
        Debug.Log("scaled-val == " + hh);
    }

    private string ftos(float input, int n = 10) {
        void split(float x, out int y, out float z)
        {
            y = Mathf.FloorToInt(x);
            z = x - y;
        }
        char compDigit(int x) {
            return ((char)(((int)('0')) + x));
        }
        if (input == 0) return "0";
        bool isNegative = input < 0;
        if (isNegative) input *= -1;
        split(input, out int intPart, out float dec);
        string res = intPart.ToString();
        if (isNegative) res = '-' + res;
        if (dec == 0f) return res;
        res += '.';
        for (int i = 0; i < n; i++)
        {
            if (dec == 0f) break;
            dec *= 10;
            split(dec, out int dig, out dec);
            res += compDigit(dig);
        }

        return res;
    }
    private string vtos(Vector3 vector, int n = 10)
    {
        string sx = ftos(vector.x, n);
        string sy = ftos(vector.y, n);
        string sz = ftos(vector.z, n);
        return string.Format("( {0}, {1}, {2} )", sx, sy, sz);
    }

    void Update() {
        CheckButton(ref btn, pressButton);
     //   MainTainPos();
     //   PressChange();
    }

    private void MainTainPos() {
        var rt = GetButton.GetRT();
        if (rt.localPosition != buttonPos)
        {
            rt.localPosition = buttonPos;
        }
    }

    public bool chng = false;
    public Vector3 inputVec = new Vector3();
    private void PressChange() {
        if (chng)
        {
            chng = false;
            Vector3 vector = Camera.main.ScreenToWorldPoint(inputVec, Camera.MonoOrStereoscopicEye.Mono);
            var rt = GetButton.GetRT();
            rt.position = vector;
            buttonPos = rt.localPosition;
        }

    }



    private void CheckButton(ref bool b, System.Action action)
    {
        if (b)
        {
            b = false;
            action();
        }
    }

    

}
