using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[ExecuteAlways]
public class Scene00_tester00 : MonoBehaviour
{

    private class GetButton
    {
        private const string leftButtonTag = "Left_button";
        private const string rightButtonTag = "Right_button";
        private static Button LeftButton = null;
        private static Button RightButton = null;
        private static RectTransform leftButtonRectTransform = null;
        private static RectTransform rightButtonRectTransform = null;
        public static Button Get()
        {
            if (LeftButton == null)
            {
                var obs = FindObjectsOfType<Button>();
                foreach (Button x in obs) if (x.tag == leftButtonTag) { LeftButton = x; break; }
            }
            return LeftButton;
        }
        public static RectTransform GetRT()
        {
            if (leftButtonRectTransform == null)
            {
                leftButtonRectTransform = Get().GetComponent<RectTransform>();
            }
            return leftButtonRectTransform;
        }
        public static Button GetRight()
        {
            if (RightButton == null)
            {
                var obs = FindObjectsOfType<Button>();
                foreach (Button x in obs) if (x.tag == rightButtonTag) { RightButton = x; break; }
            }
            return RightButton;
        }
        public static RectTransform GetRightRT()
        {
            if (rightButtonRectTransform == null)
            {
                rightButtonRectTransform = GetRight().GetComponent<RectTransform>();
            }
            return rightButtonRectTransform;
        }
    }
    private class GetCanvas {
        private static Canvas canvas = null;

        public static Canvas Get() {
            if (canvas == null)
            {
                canvas = FindObjectOfType<JoyStick>().GetComponentInChildren<Canvas>();
            }
            return canvas;
        }

        public static float GetScale() {
            return Get().transform.localScale.x;
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

    public bool btn = false;
    private void pressBtn() {
        var image = GetButton.Get().image;
        var w = image.rectTransform.rect.width;
        var h = image.rectTransform.rect.height;
        Debug.Log(string.Format("(w,h) == ({0},{1})",w,h));
    }
    public bool reset_y = false;

    private class Scale {
        private static int count = 0;
        private static void Report(string s) {
            Debug.Log(count++ + " | " + s);
        }
        private static float CamH() {
            float h = Camera.main.orthographicSize * 2;
            float sca = GetCanvas.GetScale();
            return h / sca;
        }
        private static float CamW() {
            float h = CamH();
            float w = h * (Screen.width / ((float)(Screen.height))) * Camera.main.rect.width;
            return w;
        }
        private static void Press0(ref bool btn) {
            if (btn)
            {
                btn = false;
                Debug.Log(count++ + " | camSize == " + CamH());
            }
        }

        public static void Press(ref bool btn) {
            if (btn)
            {
                btn = false;
                doThis();
            }
        }
        
        private static float GetScale( bool getH ) {
            Vector3 Dimentions = getH ?
                         new Vector3(GetButton.GetRT().rect.height, GetButton.Get().transform.localScale.y,CamH())
                         :
                         new Vector3(GetButton.GetRT().rect.width, GetButton.Get().transform.localScale.x,CamW()/2);
            float button_dimention = Dimentions.x;
            float cameraDimention = Dimentions.z;
            float old_val = Dimentions.y;
            float new_val = old_val * (cameraDimention/button_dimention);
            return new_val;
        }
        private static float GetYscale() { return GetScale( true ); }
        private static float GetXscale() { return GetScale( false ); }
        private static void doThis() {
            Vector2 sca = new Vector2( GetXscale() , GetYscale() );
            Vector2 pos = new Vector2(CamW() / 4, 0f);
            var R = GetButton.GetRight();
            var L = GetButton.Get();
            R.transform.localScale = sca; L.transform.localScale = sca;
            R.transform.position = pos;
            pos.x *= -1;
            L.transform.position = pos;
        }

        public static void Reset_y(ref bool rbtn) {
            if (rbtn)
            {
                rbtn = false;
                var button = GetButton.Get();
                var vec = button.transform.localScale;
                vec.y = 1f;
                button.transform.localScale = vec;
            }
        }
    }


    private class SupToString {
        public static string FloatToString(float input, int n=10) {
            void split(float x, ref int y, ref float z) {
                y = Mathf.FloorToInt(x);
                z = x - y;
            }
            char toChar(int x)
            {
                return ((char)(x+((int)('0'))));
            }
            if (input == 0f) return "0";
            bool isNegative = input < 0;
            if (isNegative) input *= -1;
            int i0 = -1; float f0 = -1f;
            split(input, ref i0, ref f0);
            string result = i0.ToString();
            if (isNegative) result = '-' + result;
            if (f0 == 0f) return result;
            result += '.';
            for (int i = 0; i < n; i++)
            {
                f0 *= 10;
                split(f0, ref i0, ref f0);
                result += toChar(i0);
                if (f0 == 0f) break;
            }
            return result;
        }
        public static string Vec3ToString(Vector3 input, int n = 10)
        {
            string sx = FloatToString(input.x,n);
            string sy = FloatToString(input.y, n);
            string sz = FloatToString(input.z, n);

            return string.Format("( {0} , {1} , {2} )",sx,sy,sz);
        }
    }

    void Update() {
        //  CheckButton(ref btn , pressBtn);
        Scale.Press(ref btn);
        Scale.Reset_y(ref reset_y);
    }
}
