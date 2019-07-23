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
        public static Vector2 GetPos() {
            return Get().transform.position;
        }
    }

    private class CameraDimensions {
        // 1st-space = camH ; 2nd-space = camW
        private static float[] data = new float[2];
        private static int flags = 0;
        private static System.Func<float>[] Computations = new System.Func<float>[] { ComputeH , ComputeW };
        private static float ComputeH()
        {
            return Camera.main.orthographicSize * 2 / GetCanvas.GetScale();
        }
        private static float ComputeW()
        {
            var h = GetH();
            var sh = (float)Screen.height;
            var sw = (float)Screen.width;
            var res = h * (sw / sh) * Camera.main.rect.width;
            return res;
        }
        private static float GetVal(int index, int flg) {
            if ((flags / flg) % 2 == 0)
            {
                data[index] = Computations[index]();
                flags += flg;
            }
            return data[index];
        }
        public static float GetH() { return GetVal(0, 2); }
        public static float GetW() { return GetVal(1, 1); }
        public static void ExtraTest(ref bool btn) {
            if (btn)
            {
                btn = false;
                var h = ComputeH();
                Debug.Log("testing : h == " + h);
            }
        }
    }
 

    public bool btn = false;
    public bool resetPos = false;

    private void RESET_POS() {
        if (resetPos)
        {
            resetPos = false;
            Vector2 pos = new Vector2(0f,0f);
            var arr = new RectTransform[] { GetButton.GetRT(), GetButton.GetRightRT() };
            for (int i = 0; i < arr.Length; i++) arr[i].transform.position = pos;
        }
    }

    private class TestEQSizeAndPos {
        private static int count = 0;
        private static void Report(string s) {
            Debug.Log(count++ + " | " + s);
        }
        private static void DATA(bool left, out Vector2 pos, out Vector2 sca) {
            RectTransform rt = left ? GetButton.GetRT() : GetButton.GetRightRT();
            pos = rt.position;
            sca = rt.localScale;
        }
        private static bool vecEq(Vector2 v0, Vector2 v1) {
            return ((v0.x == v1.x) && (v0.y == v1.y));
        }
        private static bool RUN_TEST() {
            Vector2[] list = new Vector2[4];
            DATA(true, out list[0], out list[1]);
            DATA(false, out list[2], out list[3]);
           
            return vecEq(list[0], list[2]) && vecEq(list[1], list[3]);
        
        }
        public static void TEST(ref bool btn) {
            if (btn)
            {
                btn = false;
                bool res = RUN_TEST();
                Report("test-result == " + res);
            }
        }
    }
    public bool test = false;
    private void press() {
        if (btn)
        {
            btn = false;
            var h = CameraDimensions.GetH();
            var w = CameraDimensions.GetW();
            var size = new Vector2(w/2,h);
            var pos = new Vector2( (w/4f) , 0f  ); pos = (pos * GetCanvas.GetScale()) + GetCanvas.GetPos();
            var L = GetButton.GetRT();
            var R = GetButton.GetRightRT();

            L.sizeDelta = size; R.sizeDelta = size;
            
            R.position = pos;
            pos.x *= -1;
            L.position = pos;
            Debug.Log("pressed");
        }
    }

    void Update() {
        press();
        RESET_POS();
        TestEQSizeAndPos.TEST(ref test);
        runTest0();

        MaintainPLP();
    }

    public bool test0 = false;
    private void runTest0() {
        void ff(RectTransform rt)
        {
            Debug.Log(string.Format("{0} | pos=={1} | sca=={2} | localPos={3}",rt.name,rt.position,rt.localScale,rt.localPosition));
        }
        if (test0)
        {
            test0 = false;

            var L = GetButton.GetRT();
            var R = GetButton.GetRightRT();
            ff(L); ff(R);
        }
    }

    public string Pos = "";
    public string localPos = "";
    private void MaintainPLP() {
        var L = GetButton.Get();
        var rt = GetButton.GetRT();
        var lp = supToStr.vec3_to_str(L.transform.localPosition);
        var p = supToStr.vec3_to_str(rt.position);
        Pos = p;
        localPos = lp;
    }

    private class supToStr {
        public static string float_to_str(float input, int n=10) { 
            void split(float x, ref int y, ref float z) {
                y = Mathf.FloorToInt(x);
                z = x - y;
            }
            char toChar(int x) { return ((char)(x+((int)'0'))); }
            string getDigits(float y, int k)
            {
                string s = "";
                int x = 0;
                for(int i=0; i<k; i++)
                {
                    if (y == 0) break;
                    y *= 10;
                    split(y, ref x, ref y);
                    s += toChar(x);
                }
                return s;
            }
            if (input == 0) return "0";
            bool isNegative = input < 0;
            if (isNegative) input *= -1;
            int intPart = 0; float floatPart = 0f;
            split(input, ref intPart, ref floatPart);
            string result = intPart.ToString();
            if (isNegative) result = '-' + result;
            string digits = getDigits(floatPart,n);
            if (digits != "") result = result + '.' + digits;
            return result;
        }
        public static string vec3_to_str(Vector3 input, int n = 10) {
            string sx = float_to_str(input.x, n);
            string sy = float_to_str(input.y, n);
            string sz = float_to_str(input.z, n);
            return string.Format("( {0} , {1} , {2} )",sx,sy,sz);
        }
    }
}
