using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester_00 : MonoBehaviour
{
    #region access
    public float r = 0f, g = 0f, b = 0f, a = 0f;
    public int wid = 1, hei = 1;
    private Texture2D access_texture()
    {
        var col = new Color(r, g, b, a);
        int w = wid < 1 ? 1 : wid;
        int h = hei < 1 ? 1 : hei;
        int pixCount = w * h;

        var cols = new Color[pixCount];
        for (int i = 0; i < pixCount; i++) cols[i] = col;

        var txt = new Texture2D(w, h);

        int mc = txt.mipmapCount;

        for (int i = 0; i < mc; i++) txt.SetPixels(0,0,w,h,cols,i);

        txt.Apply(true,true);
        
        return txt;
    }
    #endregion


    private const string TAG = "BEEMDITGBW";
    private class _button
    {
        private System.Func<Texture2D> _accessTexture = null;
        private Texture2D GetTexture() { return _accessTexture == null ? new Texture2D(100,100) : _accessTexture(); }
        public void SetAccessor(System.Func<Texture2D> f) { _accessTexture = f; }

        private System.Action action;
        private Vector4 window = new Vector4(0f, 0f, 1f, 1f);
        public _button()
        {
            void f() { }
            action = f;
        }
        public _button(System.Action act, Vector4 wind)
        {
            action = act;
            window = wind;
        }
        public void place()
        {
            Rect rect = new Rect
                (
                    new Vector2( window.x * Screen.width , window.y * Screen.height ),
                    new Vector2( window.z * Screen.width, window.w * Screen.height )
                );

            var texture = GetTexture();

               if (GUI.Button(rect, texture)) action();
          //  if (GUI.Button(rect, "asdf")) action();
        }
    }

    private class _button_0
    {
        private Color tint = new Color();
        private Vector4 window = new Vector4(0f, 0f, 1f, 1f);
        private void MakeTextureAndRect(ref Texture2D texture2D, ref Rect rect)
        {
            float xpos = window.x * Screen.width;
            float ypos = window.y * Screen.height;
            float width = window.z * Screen.width;
            float height = window.w * Screen.height;

            rect = new Rect(new Vector2(xpos, ypos), new Vector2(width, height));

            int w = Mathf.FloorToInt(width), h = Mathf.FloorToInt(height);
            int size = w * h;
            var cols = new Color[size];
            for (int i = 0; i < size; i++) cols[i] = tint;

            texture2D = new Texture2D(w, h);

            texture2D.SetPixels(0, 0, w, h, cols);

            texture2D.Apply(true, true);
        }
        private System.Action action = null;

        private _button_0() { }
        private _button_0(Color col, Vector4 vec, System.Action act)
        {
            tint = col;
            window = vec;
            action = act;
        }

        public class Builder
        {
            private static void default_action() { }
            private Color tint = new Color();
            private Vector4 window = new Vector4(0f, 0f, 1f, 1f);
            private System.Action action = default_action;

            public Builder SetTint(float r, float g, float b, float a) { tint = new Color(r,g,b,a); return this; }
            public Builder SetWindow(float xpos, float ypos, float width, float height)
            {
                window = new Vector4(xpos,ypos,width,height);
                return this;
            }
            public Builder SetAction(System.Action action)
            {
                this.action = action;
                return this;
            }

            public _button_0 Build() { return new _button_0(tint, window, action); }
        }
        public static Builder MakeBuilder() { return new Builder(); }

        public void Place()
        {
            Texture2D txt = null;
            Rect rect = new Rect();
            MakeTextureAndRect(ref txt, ref rect);
            if (GUI.Button(rect, txt)) action();
        }
    }

    private _button btn;
    private int count = 0;
    private void setup()
    {
        void f()
        {

            Debug.Log(TAG + "  <-- btn-pushed -->[" + count++ + "]");
        }
        
        var w = new Vector4(0f,0f,1f,1f);
        btn = new _button(f, w);
        btn.SetAccessor(access_texture);
    }

    private class btn_manager
    {
        private static _button_0[] btns = null;
        private static bool started = false;

        public static void setup()
        {
            // button-count : 2

            if (started) return;

            #region actions
            void act0()
            {
                string s = "b0-pressed";
                Debug.Log(TAG + " : " + s);
            }
            void act1()
            {
                string s = "b1-pressed";
                Debug.Log(TAG + " : " + s);
            }
            #endregion

            #region buttons
            var b0 = _button_0.MakeBuilder()
                .SetAction(act0)
                .SetTint(1f, 0f, 0f, .5f)
                .SetWindow(0f, 0f, .5f, 1f)
                .Build();

            var b1 = _button_0.MakeBuilder()
                .SetAction(act1)
                .SetTint(0f, 1f, 0f, .5f)
                .SetWindow(.5f, 0f, .5f, 1f)
                .Build();
            #endregion

            btns = new _button_0[] { b0, b1 };

            started = true;
        }
        public static void Run()
        {
            if (!started) return;
            foreach (var x in btns) x.Place();
        }
    }

    void Start()
    {
       // setup();
        btn_manager.setup();
    }
    void OnGUI()
    {
       // btn.place();
        btn_manager.Run();
    }


   
}
