using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;


public class ss_3_tester_00 : MonoBehaviour
{
    class _button
    {
        public System.Action action { get; set; }
        public Vector4 window { get; set; }
        public string text { get; set; }
        public int fontSize { get; set; }

        public void showButton()
        {
            Rect rect = new Rect
                    (
                       new Vector2(window.x * Screen.width, window.y * Screen.height) , 
                       new Vector2(window.z * Screen.width, window.w * Screen.height) 
                    );
            GUI.skin.button.fontSize = fontSize;
            if (GUI.Button(rect, text)) action();
            //ReportButton(rect, text, action);
        }

    }

    private static void ReportButton(Rect rect, string name, System.Action action)
    {
        string representRect(Rect r)
        {
            string xp = r.position.x.ToString();
            string yp = r.position.y.ToString();
            string xs = r.size.x.ToString();
            string ys = r.size.y.ToString();
            
            return string.Format("( xpos={0} , ypos={1} , width={2} , height={3} )",xp,yp,xs,ys);
        }
        string gp = "\n       ";
        Debug.Log(string.Format("showing button : {0}name : {1}{0}rect : {2}",gp,name,representRect(rect)));
        if (GUI.Button(rect, name)) action();
    }

    class _multiButton
    {
        private System.Action[] actions;
        private string[] names;
        private int fontSize = 10;
        private Vector4 window;

        private _multiButton() { }
        private _multiButton(System.Action[] acts, string[] nms, int fs, Vector4 wind)
        {
            actions = acts;
            names = nms;
            fontSize = fs;
            window = wind;
        }
        public class Builder
        {
            private List<System.Action> actions;
            private List<string> names;
            private Vector4 window;
            private int fontSize = 10;

            public Builder()
            {
                actions = new List<System.Action>();
                names = new List<string>();
                window = new Vector4(1f,1f,1f,1f);
            }

            public Builder AddButton(string name, System.Action action)
            {
                names.Add(name);
                actions.Add(action);
                return this;
            }
            public Builder SetFontSize(int size) { fontSize = size; return this; }
            public Builder SetWindow(float x, float y, float z, float w)
            {
                window = new Vector4(x,y,z,w);
                return this;
            }

            public _multiButton Build() { return new _multiButton(actions.ToArray(),names.ToArray(),fontSize,window); }
        }
        public static Builder MakeBuilder() { return new Builder(); }

        private System.Func<int, Rect> GetRectMaker(Vector4 panel, int count)
        {
            float xpos = panel.x * Screen.width;
            float ypos = panel.y * Screen.height;
            float wval = panel.z * Screen.width;
            float hdel = (panel.w * Screen.height) / count;

            Rect f(int index)
            {
                return new Rect(new Vector2(xpos,ypos + index * hdel), new Vector2(wval,hdel));
            }

            return f;
        }

        public void runTest()
        {
            const int len = 10;
            var f = GetRectMaker(new Vector4(1f, 1f, 1f, 1f),len);
            var sw = Screen.width; var sh = Screen.height;

            string res = "runing-test : ", gp0 = "\n       ", gp1 = "\n             ";

            res += gp0 + "screen-width  : " + sw.ToString();
            res += gp0 + "screen-height : " + sh.ToString();

            for (int i = 0; i < len; i++)
            {
                var rect = f(i);
                res += gp0 + "rect[" + i + "] : ";
                res += gp1 + "xpos : " + rect.position.x.ToString();
                res += gp1 + "ypos : " + rect.position.y.ToString();
                res += gp1 + "widt : " + rect.size.x.ToString();
                res += gp1 + "heig : " + rect.size.y.ToString();

            }

            Debug.Log(res);




        }

        public void ShowButtons()
        {
            int len = names.Length;
            if (len == 0) return;
            var rectMaker = GetRectMaker(window,len);
            GUI.skin.button.fontSize = fontSize;
            for (int i = 0; i < len; i++)
            {
                if (GUI.Button(rectMaker(i), names[i])) actions[i]();
                //ReportButton( rectMaker(i) , names[i] , actions[i] );
            }
        }
    }

    private class REPORTER
    {
        private static string makeBox(string msg)
        {
            string[] lines = msg.Split('\n');
            if (lines.Length == 0) lines = new string[] { "" };

            int maxLen = 0;
            foreach (string x in lines) { if (x.Length > maxLen) maxLen = x.Length; }

            string capstr = "".PadLeft(maxLen + 2, '_');
            string capstr0 = " " + capstr + " ";
            string capstr1 = "|" + capstr + "|";

            IEnumerable<string> boxLines()
            {
                yield return capstr0;
                foreach (string x in lines)
                {
                    string y = x.PadRight(maxLen);
                    y = "| " + y + " |";
                    yield return y;
                }
                yield return capstr1;
            }

            return string.Join("\n" , boxLines());
        }

        public static void report(string msg) { Debug.Log(makeBox(msg)); }
    }

    class MyAdUtils
    {

        private static BannerView bannerView;
        private static InterstitialAd interstitialAd;

        private static string getAppId()
        {
            #region declair and set appId-string
#if UNITY_ANDROID
            string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif
            #endregion
            return appId;
        }
        private static string getAdUnitId_banner()
        {
            #region declair and set adUnitId-string
#if UNITY_EDITOR
            string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
        string adUnitId = "unexpected_platform";
#endif
            #endregion

            return adUnitId;
        }
        private static string getAdUnitId_Interstitial()
        {
            #region declair and set adUnitId-string
#if UNITY_EDITOR
            string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
            #endregion
            return adUnitId;
        }

        private static void RegisterBannerCallBacks(BannerView banner)
        {
            #region declair handlers
            void HAL(object sender, System.EventArgs args)
            {
                //MonoBehaviour.print("HandleAdLoaded event received");
                REPORTER.report("HandleAdLoaded event received");
            }
            void HAFTL(object sender, AdFailedToLoadEventArgs args)
            {
              //  MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
                REPORTER.report("HandleFailedToReceiveAd event received with message: " + args.Message);
            }
            void HAO(object sender, System.EventArgs args)
            {
               // MonoBehaviour.print("HandleAdOpened event received");
                REPORTER.report("HandleAdOpened event received");
            }
            void HAC(object sender, System.EventArgs args)
            {
               // MonoBehaviour.print("HandleAdClosed event received");
                REPORTER.report("HandleAdClosed event received");
            }
            void HALA(object sender, System.EventArgs args)
            {
               // MonoBehaviour.print("HandleAdLeftApplication event received");
                REPORTER.report("HandleAdLeftApplication event received");
            }
            #endregion

            #region register handlers
            banner.OnAdLoaded += HAL;
            banner.OnAdFailedToLoad += HAFTL;
            banner.OnAdOpening += HAO;
            banner.OnAdClosed += HAC;
            banner.OnAdLeavingApplication += HALA;
            #endregion

            
        }
        private static void RegisterInerstitialAdCallBacks(InterstitialAd interstitial)
        {
            // TODO
        }

        public static void setUp()
        {
            // MobileAds.SetiOSAppPauseOnBackground(true);  // <--
            MobileAds.Initialize(getAppId());
        }

        private static AdRequest CreateAdRequest() {

            #region declaire and set DEVICE_ID
            // const string TUTORIAL_DEVICE_ID = "0123456789ABCDEF0123456789ABCDEF";
            const string THIS_DEVICE_ID = "55B8582CB1A5AADB1D756DE362C9E4A2";
            //                             55B8582CB1A5AADB1D756DE362C9E4A2
            const string DEVICE_ID = THIS_DEVICE_ID;
            #endregion

            REPORTER.report("\n\n\nCalling CreateAdRequest with device_id : \n" + DEVICE_ID + "\n\n\n");

            return new AdRequest.Builder()
           .AddTestDevice(AdRequest.TestDeviceSimulator)
           .AddTestDevice(DEVICE_ID)
           .AddKeyword("game")
           .SetGender(Gender.Male)
           .SetBirthday(new System.DateTime(1985, 1, 1))
           .TagForChildDirectedTreatment(false)
           .AddExtra("color_bg", "9B30FF")
           .Build();
        }

        public static void RequestBanner()
        {
            REPORTER.report("REQUESTING BANNER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            if (bannerView != null)
            {
                bannerView.Destroy();
            }

            bannerView = new BannerView(getAdUnitId_banner() , AdSize.SmartBanner , AdPosition.Top);

            RegisterBannerCallBacks(bannerView);

            bannerView.LoadAd(CreateAdRequest());
        }
        public static void RequestInterstitial()
        {
            if (interstitialAd != null) interstitialAd.Destroy();
            interstitialAd = new InterstitialAd( getAdUnitId_Interstitial() );
            RegisterInerstitialAdCallBacks(interstitialAd);
            interstitialAd.LoadAd(CreateAdRequest());
         
        }
        public static void ShowInterstitial() { interstitialAd.Show(); }

        public static void KillBanner()
        {
            if (bannerView != null) bannerView.Destroy();
        }

        private class ShowInterstitialMech : MonoBehaviour
        {
            private InterstitialAd ad;
            private int[] codes = new int[2];

            public ShowInterstitialMech(InterstitialAd theAd) { ad = theAd; }

            private void OnFinish() { codes[0] = 0; }

            private IEnumerator ShowInterstitialWhenReady(InterstitialAd theAd, int[] theCodes, System.Action callback)
            {
                /*
                    'codes'-protocall :
                        -> the 1st element of codes is the INPUT for this Corutine, defined by : 
                              -> 0 := no-input
                              -> 1 := cancel-requested
                        -> the 2nd element of codes is the OUTPUT for this Corutine, defined by : 
                              -> 0 := not-running
                              -> 1 := currently-running
                 */
                theCodes[1] = 1;
                bool running = true;
                while (running)
                {
                    switch (theCodes[0])
                    {
                        case 0:
                            if (theAd.IsLoaded())
                            {
                                theAd.Show();
                                running = false;
                            }
                            else
                            {
                                yield return null;
                            }
                            break;
                        case 1:
                            running = false;
                            break;
                    }
                }
                theCodes[1] = 0;

                callback();

                yield return null;
                
            }

            public void show()
            {
                if (codes[0] != 0) Debug.Log("<this mech is ALREADY-RUNNING>");
             
                StartCoroutine(ShowInterstitialWhenReady(ad,codes,OnFinish));
                
            }
        }
        
        public static void Load_n_show_interstitial()
        {
            RequestInterstitial();
            var x = new ShowInterstitialMech(interstitialAd);
            x.show();
        }

      
        
    }
    
    private void SwitchScene() {
        const string otherSceneName = "MY_ADS_HelloWorld";
        SceneManager.LoadScene(otherSceneName);
    }

    #region makeButtons
    private _button reqBtn_banner = new _button(), killBtn = new _button(), swtBtn = new _button();
    private _multiButton interstitial_btn;
    private void setupButtons() {
        /*
         public System.Action action { get; set; }
        public Vector4 window { get; set; }
        public string text { get; set; }
        public int fontSize { get; set; }

         */
        reqBtn_banner.action = MyAdUtils.RequestBanner;
        reqBtn_banner.window = new Vector4(0f, 0f, .5f, .33333f);
        reqBtn_banner.text = "request-banner";
        reqBtn_banner.fontSize = 50;

        interstitial_btn = _multiButton.MakeBuilder()
            .SetFontSize(50)
            .SetWindow(.5f, 0f, .5f, .33333f)
            //  .AddButton("request-interstitial", MyAdUtils.RequestInterstitial)
            //  .AddButton("show-interstitial", MyAdUtils.ShowInterstitial)
            //  .AddButton("req-and-show\ninterstitial", MyAdUtils.Load_n_show_interstitial)
            //  .AddButton("test~", TestClass.test)
            //  .AddButton("get_int_Ad", InterstitialManager.GetAd)
            .AddButton("int-ad", InterstitialManager.test)
            .Build();

        killBtn.action = MyAdUtils.KillBanner;
        killBtn.window = new Vector4(0f, .33333f, 1f, .33333f);
        killBtn.text = "kill-banner";
        killBtn.fontSize = 50;

        swtBtn.action = SwitchScene;
        swtBtn.window = new Vector4(0f, .66666f, 1f, .33333f);
        swtBtn.text = "switch_scenes";
        swtBtn.fontSize = 50;


       // interstitial_btn.runTest();
    }

    private void showButtons()
    {
        
        reqBtn_banner.showButton();
        interstitial_btn.ShowButtons();
        killBtn.showButton();
        swtBtn.showButton();
        

    }
    #endregion

    void Start() { MyAdUtils.setUp(); setupButtons(); Timer.SetUp(); }
    void OnGUI() { showButtons();  }

    private class POST_OFFICE
    {
        #region helper classes
        public class Post<T>
        {
            public int Addr { get; private set; }
            public T Value { get; private set; }
            private Post() { }
            public Post(int a, T val) { Addr = a; Value = val; }
        }
        public class MailBox<T, U>
        {
            protected MailBox() { }
            public MailBox(System.Func<T, U> proc)
            {
                proccess = proc;
                inBox = new Queue<Post<T>>();
                outBox = new Queue<Post<U>>();
            }

            private System.Func<T, U> proccess;
            private Queue<Post<T>> inBox;
            private Queue<Post<U>> outBox;

            public void Work()
            {
                if (inBox.Count == 0) return;
                Post<T> inPost = inBox.Dequeue();
                Post<U> outPost = new Post<U>(inPost.Addr, proccess(inPost.Value));
                outBox.Enqueue(outPost);
            }

            public int inBox_size() { return inBox.Count; }
            public int outBox_size() { return outBox.Count; }

            public void put(int addr, T val) { inBox.Enqueue(new Post<T>(addr, val)); }
            public void put(Post<T> input) { inBox.Enqueue(input); }
            public bool get(ref Post<U> output)
            {
                if (outBox.Count == 0) return false;
                output = outBox.Dequeue();
                return true;
            }
        }

        public class WrappedBox 
        {
            public System.Type InType { get; private set; }
            public System.Type outType { get; private set; }
            private object box;
            private System.Action<object[]> accessor;

            private static System.Action<object[]> MakeAccessor<T, U>()
            {
                /*
                     key : 
                       -> op:=0 : get-input-size
                       -> op:=1 : Work
                 */
                void f(object[] args)
                {
                    var mb = (MailBox<T, U>)args[1];
                    switch (args[0])
                    {
                        case 0: args[2] = mb.inBox_size(); break;
                        case 1: mb.Work(); break;
                    }
                }
                return f;
            }

            private WrappedBox() { }
            private WrappedBox(System.Type _in, System.Type _out, object bx, System.Action<object[]> acc)
            {
                InType = _in;
                outType = _out;
                box = bx;
                accessor = acc;
            }

            public static WrappedBox Wrap<T, U>(MailBox<T,U> mb)
            {
                return new WrappedBox(typeof(T), typeof(U), mb, MakeAccessor<T,U>());
            }
            public MailBox<T, U> UnWrap<T, U>()
            {
                if (typeof(T) != InType || typeof(U) != outType) return null;
                return ((MailBox<T,U>)box);
            }

            public int inbox_size()
            {
                var arr = new object[] { 0 , box , null };
                accessor(arr);
                return ((int)arr[2]);
            }
            public void work()
            {
                accessor(new object[] { 1 , box });
            }
        }

        

        private class IndexedSet<T>
        {
            private Queue<int> gaps = new Queue<int>();
            private int cap = 0;
            private Dictionary<int, T> entries = new Dictionary<int, T>();

            public int Register(T val)
            {
                int index = -1;
                if (gaps.Count == 0)
                {
                    index = cap++;
                }
                else
                {
                    index = gaps.Dequeue();
                }
                entries.Add(index, val);
                return index;
            }
            private void _unregister(int index)
            {
                entries.Remove(index);
                if (index == cap - 1) cap--;
                else gaps.Enqueue(index);
            }
            public void UnRegister(int index)
            {
                if (!entries.ContainsKey(index)) return;
                _unregister(index);
            }
            public void UnRegister(T val)
            {
                var keys = entries.Keys;
                foreach (var k in keys)
                {
                    if (entries[k].Equals(val)) _unregister(k); 
                }
            }

            public IEnumerable<T> GetVals() {
                return entries.Values;
            }

            public bool TryGetVal(int ind, ref T result)
            {
                return entries.TryGetValue(ind,out result);
            }
        }

        private class WrappedBox_00
        {
            public System.Type InType { get; private set; }
            public System.Type OutType { get; private set; }
            private object box;
            private System.Action<object[]> accessor;

            private WrappedBox_00() { }
            private WrappedBox_00(System.Type _in, System.Type _out, object bx, System.Action<object[]> acc)
            {
                InType = _in;
                OutType = _out;
                box = bx;
                accessor = acc;
            }

            private static System.Action<object[]> MakeAcc<T, U>()
            {
                /*
                   protocal : 
                      * there must be at least two-entries
                      * the first entry must be the 'operation-code' (op)
                      * the second entry must be the 'box'-object
                      * key : 
                      *       op==0 : Work
                      *       op==1 : inbox_size
                      *       op==2 : outbox_size
                      *       op==3 : put(int add, T input)
                      *               -> args := [ op , box , add , input  ]
                      *       op==4 : put(Post<T> input)
                      *               -> args := [ op , box , input  ]
                      *       op==5 : get  
                      *               -> args := [ op , box , output-post<U> , output-bool ]
                      *          
                 */
                void f(object[] args)
                {
                    var mb = (MailBox<T, U>)args[1];
                    switch ((int)args[0])
                    {
                        case 0: mb.Work(); break;
                        case 1: args[2] = mb.inBox_size(); break;
                        case 2: args[2] = mb.outBox_size(); break;
                        case 3: mb.put((int)args[2], (T)args[3]); break;
                        case 4: mb.put((Post<T>)args[2]); break;
                        case 5:
                            var postu = (Post<U>)args[2];
                            args[3] = mb.get(ref postu);
                            args[2] = postu;
                            break;
                    }
                }
                return f;
            }

            public static WrappedBox_00 Wrap<T, U>(MailBox<T, U> mb)
            {
                return new WrappedBox_00(typeof(T), typeof(U), mb, MakeAcc<T, U>());
            }
            public MailBox<T, U> Unwrap<T, U>()
            {
                if (typeof(T) != InType || typeof(U) != OutType) return null;
                return ((MailBox<T, U>)box);
            }

            public void Work()
            {
                accessor(new object[] { 0, box });
            }
            public int inbox_size()
            {
                var arr = new object[] { 1, box, null };
                accessor(arr);
                return ((int)arr[2]);
            }
            public int outbox_size()
            {
                var arr = new object[] { 2, box, null };
                accessor(arr);
                return ((int)arr[2]);
            }
            public void put<T>(int add, T inp)
            {
                if (typeof(T) != InType) return;
                accessor(new object[] { 3, box, add, inp });
            }
            public void put(int add, object inp)
            {
                if (inp.GetType() != InType) return;
                accessor(new object[] { 3, box, add, inp });
            }
            public void put<T>(Post<T> inp)
            {
                if (typeof(T) != InType) return;
                accessor(new object[] { 4, box, inp });
            }
            public bool get<U>(ref Post<U> post)
            {
                if (typeof(U) != OutType) return false;
                bool result = false;
                var arr = new object[] { 5, box, post, result };
                accessor(arr);
                result = (bool)arr[3];
                post = (Post<U>)arr[2];
                return result;
            }

            
            
        }
        #endregion

        private static IndexedSet<WrappedBox> Boxes = new IndexedSet<WrappedBox>();

        public static int RegisterBox<T, U>(MailBox<T, U> mb)
        {
            var wb = WrappedBox.Wrap<T, U>(mb);
            return Boxes.Register(wb);
        }
        public static void UnregisterBox( int index ) { Boxes.UnRegister(index); }
        public static MailBox<T, U> GetBox<T, U>(int Index)
        {
            WrappedBox wrapped = null;
            bool flag = Boxes.TryGetVal(Index, ref wrapped);
            if (flag) return wrapped.UnWrap<T, U>();
            return null;
        }

        public static void CheckMail()
        {
            var wrappedBoxes = Boxes.GetVals();
            foreach (var box in wrappedBoxes)
            {
                int len = box.inbox_size();
                for (int i = 0; i < len; i++)
                {
                    box.work();
                }
            }
        }
    }

    #region expirement-code
    class Timer
    {
        private static POST_OFFICE.MailBox<object,float> mailBox;
        private static bool started = false;
        private static int mailBox_addr = 0;
        private static System.Threading.Thread thread;

        private static int lastTime_int = 0;
        private static float lastTime = 0f;

        public static void SetUp() {
            float f(object x)
            {
                return Time.deltaTime;
            }
            mailBox = new POST_OFFICE.MailBox<object, float>(f);
            mailBox_addr = POST_OFFICE.RegisterBox<object, float>(mailBox);

            thread = new System.Threading.Thread(RUN);

            thread.Start();

            started = true;
        }

        private static void ReportTime()
        {
            var x = (float)(lastTime * .01f);
            Debug.Log(x.ToString());
        }
        private static void CheckTime()
        {
            int x = Mathf.FloorToInt(lastTime);
            if (x != lastTime_int)
            {
                lastTime_int = x;
                ReportTime();
            }
        }

        private static void RUN()
        {
            const int cap = 100;
            while (true)
            {
                if (mailBox.inBox_size() < cap) mailBox.put(0, null);
                if (mailBox.outBox_size() > 0)
                {
                    POST_OFFICE.Post<float> post = null;
                    mailBox.get(ref post);
                    lastTime += post.Value;
                    ReportTime();
                }
            }
        }

    }
    #endregion

    void Update()
    {
        // TestClass.TestObj.UPDATE();
        //InterstitialManager.UPDATE();
        POST_OFFICE.CheckMail();
    }

    private class TestClass0
    {
        private class timeBox
        {
            private static float time = 0f;
            private static bool firstUpdateCalled = false;

            public static float GetTime() { return time; }
            public static void update() { time = Time.realtimeSinceStartup; firstUpdateCalled = true; }
            public static bool ready() { return firstUpdateCalled; }
        }

        private class testBox
        {
            public static void foo()
            {
                const float durration = 2f;
                while (!timeBox.ready()) ;
                //  Debug.Log("TEST-STARTED");
                REPORTER.report("TEST-STARTED");
                float endtime = timeBox.GetTime() + durration;
                while (timeBox.GetTime() < endtime) { REPORTER.report("time=="+timeBox.GetTime()); }
                REPORTER.report("TEST-FINISHED");
            }
        }

        public static void RunTest0()
        {
            var x = new System.Threading.Thread(testBox.foo);
            x.Start();
        }
        public static void UpdateState() { timeBox.update(); }

       


        #region ad_Utils
        private static AdRequest CreateAdRequest()
        {

            #region declaire and set DEVICE_ID
            // const string TUTORIAL_DEVICE_ID = "0123456789ABCDEF0123456789ABCDEF";
            const string THIS_DEVICE_ID = "55B8582CB1A5AADB1D756DE362C9E4A2";
            //                             55B8582CB1A5AADB1D756DE362C9E4A2
            const string DEVICE_ID = THIS_DEVICE_ID;
            #endregion

            REPORTER.report("\n\n\nCalling CreateAdRequest with device_id : \n" + DEVICE_ID + "\n\n\n");

            return new AdRequest.Builder()
           .AddTestDevice(AdRequest.TestDeviceSimulator)
           .AddTestDevice(DEVICE_ID)
           .AddKeyword("game")
           .SetGender(Gender.Male)
           .SetBirthday(new System.DateTime(1985, 1, 1))
           .TagForChildDirectedTreatment(false)
           .AddExtra("color_bg", "9B30FF")
           .Build();
        }
        private static string getAdUnitId_Interstitial()
        {
            #region declair and set adUnitId-string
#if UNITY_EDITOR
            string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
            #endregion
            return adUnitId;
        }
        public static InterstitialAd RequestInterstitial()
        {

            InterstitialAd interstitialAd = new InterstitialAd(getAdUnitId_Interstitial());

            return interstitialAd;

        }
        private class TestBox
        {
            private InterstitialAd interstitial;
            private AdRequest adRequest;
            private void TestRoutine(InterstitialAd ad, AdRequest request)
            {
                int count = 0;
                Debug.Log("STARTING-TEST");
                ad.LoadAd(request);
                while (!ad.IsLoaded()) Debug.Log("   -> the ad is loading : " + count++);
                Debug.Log("the ad has loaded");
                ad.Destroy();
                Debug.Log("FINIISHED-TEST");
            }
            public void RunTest() { TestRoutine(interstitial, adRequest); }
            private TestBox(InterstitialAd x, AdRequest y) { interstitial = x; adRequest = y; }
            private TestBox() { }
            public static TestBox mkTest(InterstitialAd x, AdRequest y) { return new TestBox(x, y); }
        }
        
        public static void RunTest1()
        {
            var ad = RequestInterstitial();
            var req = CreateAdRequest();
            var thread = new System.Threading.Thread(TestBox.mkTest(ad,req).RunTest);
            thread.Start();
        }

        private class TestMaker0
        {
            private class Test_container
            {
                private bool testDone = false;
                private InterstitialAd ad;
                private AdRequest request;
                public Test_container(InterstitialAd x, AdRequest y) { ad = x; request = y; }
                public void run()
                {
                    REPORTER.report("first line of test");
                    if (testDone)
                    {
                        REPORTER.report("test-already-run");
                        return;
                    }

                    testDone = true;
                    string res = "TEST-STARTED : \n--------------\n";

                    ad.LoadAd(request);

                    REPORTER.report("ran 'LoadAd'");
                    int count = 0;
                    while (!ad.IsLoaded())
                    {
                        REPORTER.report("loop : " + count);
                        res += "loop#" + count++ + "\n";
                    }

                    REPORTER.report("out of loop");

                    ad.Destroy();

                    REPORTER.report("ad-destroyed");

                    res += "\n--------------\nTEST-FINISHED";

                    REPORTER.report(res);

                    REPORTER.report("done with test");
                }
            }
            public static System.Threading.Thread MakeTest(InterstitialAd ad, AdRequest request)
            {
                var tc = new Test_container(ad, request);

                return new System.Threading.Thread(tc.run);
            }
        }
        public static void RunTest()
        {
            REPORTER.report("runtest-called");
            InterstitialAd ad = RequestInterstitial();
            REPORTER.report("made-ad");
            AdRequest request = CreateAdRequest();
            REPORTER.report("made-request");
            System.Threading.Thread thread = TestMaker0.MakeTest(ad,request);
            REPORTER.report("made-thread");
            thread.Start();
            
            
            REPORTER.report("started-thread");
        }

        public class TestManager
        {
            public class DexBox<T>
            {
                private Dictionary<int, T> map = new Dictionary<int, T>();
                private Queue<int> holes = new Queue<int>();
                private int upper = 0;

                public int put(T val)
                {
                    int index = holes.Count == 0 ? upper++ : holes.Dequeue();
                    map.Add(index, val);
                    return index;
                }
                public T get(int index, T _default)
                {
                    bool b = map.TryGetValue(index, out T v);
                    return b ? v : _default;
                }
                public void remove(int index)
                {
                    if (!map.ContainsKey(index)) return;
                    map.Remove(index);
                    if (index == upper - 1)
                        upper--;
                    else
                        holes.Enqueue(index);
                }
                public bool hasKey(int index) { return map.ContainsKey(index); }
            }
            private class Test_container
            {
                private bool testDone = false;
                private InterstitialAd ad;
                private AdRequest request;
                public Test_container(InterstitialAd x, AdRequest y) { ad = x; request = y; }
                public void run()
                {
                    REPORTER.report("first line of test");
                    if (testDone)
                    {
                        REPORTER.report("test-already-run");
                        return;
                    }

                    testDone = true;
                    string res = "TEST-STARTED : \n--------------\n";

                    ad.LoadAd(request);

                    REPORTER.report("ran 'LoadAd'");
                    int count = 0;
                    while (!ad.IsLoaded())
                    {
                        REPORTER.report("loop : " + count);
                        res += "loop#" + count++ + "\n";
                    }

                    REPORTER.report("out of loop");

                    ad.Destroy();

                    REPORTER.report("ad-destroyed");

                    res += "\n--------------\nTEST-FINISHED";

                    REPORTER.report(res);

                    REPORTER.report("done with test");
                }
            }
            private static DexBox<Test_container> TestTable = new DexBox<Test_container>();

            public static void test(InterstitialAd ad, AdRequest request)
            {
                Test_container tc = new Test_container(ad,request);
                TestTable.put(tc);
                var thread = new System.Threading.Thread(tc.run);
                thread.Start();
            }
            public static void runTest()
            {
                InterstitialAd ad = new InterstitialAd(getAdUnitId_Interstitial());
                AdRequest request = CreateAdRequest();
                test(ad,request);
            }
        }

       

        #endregion
    }

    private class TestClass
    {
        private const string className = "java.lang.String";
        private const string lengthName = "length";
        public static void test0()
        {


            REPORTER.report("\nRUNNING-TEST\n");
            AndroidJavaObject obj = new AndroidJavaObject(className, "asdf");
            int len = obj.Call<int>("length");
            REPORTER.report("str-len == " + len);
        }
        private class TestObj1
        {
            public static AndroidJavaObject obj = null;
            public static void TestMethod()
            {
                int res = obj.Call<int>(lengthName);
                REPORTER.report("\nlength==" + res);
            }
        }
        private static System.Threading.Thread makeTestThread()
        {
            return new System.Threading.Thread(TestObj1.TestMethod);
        }
        public static void test1()
        {
            const string TestStr = "-012345";
            REPORTER.report("\nRUNNING-TEST : \nTestStr==\"" + TestStr + "\"\n");

            TestObj1.obj = new AndroidJavaObject(className, TestStr);

            var thread = makeTestThread();

            thread.Start();

            REPORTER.report("test-ran");
        }

        public static void test2()
        {
            REPORTER.report("ALTERNATE-TEST");
            void func()
            {
                REPORTER.report("(a)");
                var obj = new AndroidJavaObject(className, "asdf");
                REPORTER.report("(b)");
                int res = obj.Call<int>(lengthName);
                REPORTER.report("(c)");
                REPORTER.report("length==" + res);
                REPORTER.report("(d)");
            }
            var thread = new System.Threading.Thread(func);
            thread.Start();
            REPORTER.report("ran-test ");
        }

        private class TestObj3
        {
            public static AndroidJavaObject obj = null;
        }

        public static void test3()
        {
            REPORTER.report("\nTEST : \nStatic-vars\nno-threads\n\n\n");
            TestObj3.obj = new AndroidJavaObject(className, "asdf");
            int res = TestObj3.obj.Call<int>(lengthName);
            REPORTER.report("length==" + res);
            REPORTER.report("test-done");
        }

        public class TestObj
        {
            /*
             Prototcall : 
                -> A 'program' would be an IEnumerable<COMMAND>,
                along with a [bool] for a return-flag, and shared-data object,
                and finally an object which handles things to be done on the main-thread.
                This would be executed as follows  :
                     while( prog.HAS_NEXT )
                     {
                        var x = prog.next
                        resFlag[0] = false;
                        WORKER.consume(x);
                        if(!prog.HAS_NEXT) break;
                        else
                        {
                            while( !resFlag[0] ) ;
                        }
                     }
                      
             
             */
            public enum COMMAND { GET_LEN, GET_ISNULL, SET_VAL, DEL_VAL, NO_COMMAND };
            public static bool[] resultFlag = new bool[] { false };
            public class DATA
            {
                public static int intVal = 0;
                public static bool boolVal = false;
            }
            private static COMMAND recentCommand = COMMAND.NO_COMMAND;
            private static string recentString = "";
            public class Token
            {
                public readonly COMMAND command;
                public readonly string val;
                private Token() { command = COMMAND.NO_COMMAND; val = ""; }
                private Token(COMMAND c, string v) { command = c; val = v; }
                public static Token SetVal(string v) { return new Token(COMMAND.SET_VAL, v); }
                public static Token GetLen() { return new Token(COMMAND.GET_LEN, null); }
                public static Token IsNull() { return new Token(COMMAND.GET_ISNULL, null); }
                public static Token DelVal() { return new Token(COMMAND.DEL_VAL, null); }

            }

            private static AndroidJavaObject TheString = null;

            public static void Consume(Token token)
            {
                recentCommand = token.command;
                if (token.command == COMMAND.SET_VAL) recentString = token.val;
            }

            public static void UPDATE()
            {
                switch (recentCommand)
                {
                    case COMMAND.DEL_VAL: TheString = null; resultFlag[0] = true; break;
                    case COMMAND.GET_ISNULL: DATA.boolVal = TheString == null; resultFlag[0] = true; break;
                    case COMMAND.GET_LEN: DATA.intVal = TheString == null ? -1 : TheString.Call<int>(lengthName); resultFlag[0] = true; break;
                    case COMMAND.NO_COMMAND: break;
                    case COMMAND.SET_VAL:
                        if (recentString != null)
                        {
                            TheString = new AndroidJavaObject(className, recentString);

                        }
                        resultFlag[0] = true;
                        break;
                }
            }
        }
        class TestSystem
        {
         
            private class Unit
            {
                private IEnumerable<TestObj.Token> program;
                public Unit() { program = new TestObj.Token[0]; }
                public Unit(IEnumerable<TestObj.Token> p) { program = p; }
                public void RunMethod()
                {
                    var tokenEnum = program.GetEnumerator();
                    TestObj.Token cur = null;

                    bool notDone = tokenEnum.MoveNext();

                    while (notDone)
                    {
                        cur = tokenEnum.Current;
                        TestObj.resultFlag[0] = false;
                        TestObj.Consume(cur);
                        while (!TestObj.resultFlag[0]) ;
                        notDone = tokenEnum.MoveNext();
                    }
                    tokenEnum.Dispose();

                }
            }

            public static System.Threading.Thread MakeTestThread(IEnumerable<TestObj.Token> prog)
            {
                var unit = new Unit(prog);

                return new System.Threading.Thread(unit.RunMethod);
            }

        }
        public static IEnumerable<TestObj.Token> TokenProgram()
        {
            const string strVal = "asdfasdf";
            REPORTER.report("begin-test\ntest-val : " + strVal);

            yield return TestObj.Token.SetVal(strVal);

            yield return TestObj.Token.GetLen();

            int result = TestObj.DATA.intVal;

            REPORTER.report("length == " + result);

            REPORTER.report("test-done");
        }
        private static bool testRan = false;
        public static void test()
        {
            if (testRan)
            {
                REPORTER.report("this testAlready ran");
            }
            else
            {
                REPORTER.report("running-test");
                testRan = true;
                var testThread = TestSystem.MakeTestThread(TokenProgram());
                testThread.Start();
                REPORTER.report("test-thread started");
            }
        }
    }

    class InterstitialManager
    {
        #region adUtils
        private static string getAppId()
        {
            #region declair and set appId-string
#if UNITY_ANDROID
            string appId = "ca-app-pub-3940256099942544~3347511713";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif
            #endregion
            return appId;
        }
        private static string getAdUnitId_Interstitial()
        {
            #region declair and set adUnitId-string
#if UNITY_EDITOR
            string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif
            #endregion
            return adUnitId;
        }
        private static AdRequest CreateAdRequest()
        {

            #region declaire and set DEVICE_ID
            // const string TUTORIAL_DEVICE_ID = "0123456789ABCDEF0123456789ABCDEF";
            const string THIS_DEVICE_ID = "55B8582CB1A5AADB1D756DE362C9E4A2";
            //                             55B8582CB1A5AADB1D756DE362C9E4A2
            const string DEVICE_ID = THIS_DEVICE_ID;
            #endregion

            REPORTER.report("\n\n\nCalling CreateAdRequest with device_id : \n" + DEVICE_ID + "\n\n\n");

            return new AdRequest.Builder()
           .AddTestDevice(AdRequest.TestDeviceSimulator)
           .AddTestDevice(DEVICE_ID)
           .AddKeyword("game")
           .SetGender(Gender.Male)
           .SetBirthday(new System.DateTime(1985, 1, 1))
           .TagForChildDirectedTreatment(false)
           .AddExtra("color_bg", "9B30FF")
           .Build();
        }
        public static InterstitialAd MakeInterstitial()
        {

            return new InterstitialAd(getAdUnitId_Interstitial());

        }
        #endregion

        private class AdBox
        {
            /*
                flag-key : 
                   0 := ad:=null
                   1 := 'Show' not-yet called
                   2 := 'Show' has been called
                   3 := 'Destroy' has been called
                 
                 */
            private InterstitialAd ad;
            private int flag = 0;
            public AdBox() { ad = null; flag = 0; }
            public AdBox(InterstitialAd interstitial) { ad = interstitial; flag = ad == null ? 0 : 1; }

            public bool Dead() { return flag == 0 || flag == 3; }

            public void Kill()
            {
                switch (flag)
                {
                    case 0: return;
                    case 1: ad.Destroy(); flag = 3; return;
                    case 2: ad.Destroy(); flag = 3; return;
                    case 3: return;
                }
            }

            public void Update()
            {
                switch (flag)
                {
                    case 0: return;
                    case 1: if (ad.IsLoaded()) { ad.Show(); flag = 2; } return;
                    case 2: return;
                    case 3: return;
                }
            }
            public int GetFlag() { return flag; }
        }

        private static AdBox adBox = null;

        public static void UPDATE()
        {
            if (adBox != null) adBox.Update();
            if (adBox == null)
                REPORTER.report("box was null");
            else
            {
                REPORTER.report("box flag-state was " + adBox.GetFlag());
            }
        }
        public static void GetAd()
        {
            

            REPORTER.report(" GetAd::A ");

            if (adBox!=null && !adBox.Dead()) adBox.Kill();

            REPORTER.report(" GetAd::B ");

            var ad = MakeInterstitial();

            REPORTER.report(" GetAd::C ");

            ad.LoadAd(CreateAdRequest());

            REPORTER.report(" GetAd::D ");

            adBox = new AdBox(ad);

            REPORTER.report(" GetAd::E ");
        }

        public static void test()
        {
            void oal(object sender , System.EventArgs args)
            {
                var x = (InterstitialAd)sender;
                var argTypeStr = args.GetType().ToString();
                REPORTER.report("\n\n\n\nloading-ad\narg-type=="+argTypeStr+"\n\n\n");
                x.Show();
            }
            void oac(object sender, System.EventArgs args)
            {
                var x = (InterstitialAd)sender;
                var argTypeStr = args.GetType().ToString();
                REPORTER.report("\n\n\n\nclosing-ad\narg-type==" + argTypeStr + "\n\n\n");
                x.Destroy();
                REPORTER.report("\n\n\n\ndestroyed-ad\n\n\n\n");
            }
            InterstitialAd ad = new InterstitialAd(getAdUnitId_Interstitial());
            ad.OnAdClosed += oac;
            ad.OnAdLoaded += oal;
            ad.LoadAd(CreateAdRequest());
        }
    }

}
