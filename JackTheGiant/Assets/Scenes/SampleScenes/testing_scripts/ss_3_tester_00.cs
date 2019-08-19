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
        }

    }

    class MyAdUtils
    {

        private static BannerView bannerView;
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
        private static string getAdUnitId()
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

        public static void setUp()
        {
            MobileAds.Initialize(getAppId());
        }

        private static AdRequest CreateAdRequest() {
            return new AdRequest.Builder()
           .AddTestDevice(AdRequest.TestDeviceSimulator)
           .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
           .AddKeyword("game")
           .SetGender(Gender.Male)
           .SetBirthday(new System.DateTime(1985, 1, 1))
           .TagForChildDirectedTreatment(false)
           .AddExtra("color_bg", "9B30FF")
           .Build();
        }

        public static void RequestBanner()
        {
            Debug.Log("REQUESTING BANNER!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            if (bannerView != null)
            {
                bannerView.Destroy();
            }

            bannerView = new BannerView(getAdUnitId() , AdSize.SmartBanner , AdPosition.Top);

            bannerView.LoadAd(CreateAdRequest());
        }

        public static void KillBanner()
        {
            if (bannerView != null) bannerView.Destroy();
        }
    }
    
    private void SwitchScene() {
        const string otherSceneName = "MY_ADS_HelloWorld";
        SceneManager.LoadScene(otherSceneName);
    }

    #region makeButtons
    private _button reqBtn = new _button(), killBtn = new _button(), swtBtn = new _button();
    private void setupButtons() {
        /*
         public System.Action action { get; set; }
        public Vector4 window { get; set; }
        public string text { get; set; }
        public int fontSize { get; set; }

         */
        reqBtn.action = MyAdUtils.RequestBanner;
        reqBtn.window = new Vector4(0f,0f,1f,.33333f);
        reqBtn.text = "request-banner";
        reqBtn.fontSize = 50;

        killBtn.action = MyAdUtils.KillBanner;
        killBtn.window = new Vector4(0f, .33333f, 1f, .33333f);
        killBtn.text = "kill-banner";
        killBtn.fontSize = 50;

        swtBtn.action = SwitchScene;
        swtBtn.window = new Vector4(0f, .66666f, 1f, .33333f);
        swtBtn.text = "switch_scenes";
        swtBtn.fontSize = 50;

    }

    private void showButtons()
    {
        reqBtn.showButton();
        killBtn.showButton();
        swtBtn.showButton();
    }
    #endregion

    void Start() { MyAdUtils.setUp(); setupButtons(); }
    void OnGUI() { showButtons(); }

    private void asdf() {
        Debug.Log(SceneSwitcher00.asdf);
    }
}
