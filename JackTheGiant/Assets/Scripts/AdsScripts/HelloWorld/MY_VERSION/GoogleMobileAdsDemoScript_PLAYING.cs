
//using System;
using UnityEngine;
using GoogleMobileAds.Api;
//using GoogleMobileAds;
using UnityEditor;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.SceneManagement;


// Example script showing how to invoke the Google Mobile Ads Unity plugin.
public class GoogleMobileAdsDemoScript_PLAYING : MonoBehaviour
{
    #region place test-button
    public float v0 = .56f, v1 = .78f, v2 = .3f, v3 = .1f;
    private void _access(int code, int index, float val, int[] outint, float[] outfloat) {
        /*
           key : 
             code==0 := getLength
             code==1 := get ith-element
             code==2 := set ith-el
          note : outint and outfloat should both be non-null and have length >= 1.
         */
        switch (code)
        {
            case 0: outint[0] = 4; return;
            case 1:
                switch (index)
                {
                    case 0: outfloat[0] = v0; break;
                    case 1: outfloat[0] = v1; break;
                    case 2: outfloat[0] = v2; break;
                    case 3: outfloat[0] = v3; break;
                }
                break;
            case 2:
                switch (index)
                {
                    case 0: v0 = val; outfloat[0] = val; break;
                    case 1: v1 = val; outfloat[0] = val; break;
                    case 2: v2 = val; outfloat[0] = val; break;
                    case 3: v3 = val; outfloat[0] = val; break;
                }
                break;
        }
    }
    private class ButtonBox
    {
        private const string otherSceneName = "ss_3";

        private class gt
        {
            private static System.Action<int, int, float, int[], float[]> action;
            private static int[] ibox = new int[1];
            private static float[] fbox = new float[1];
            private static bool started = false;

            public static bool Started() { return started; }
            public static void Start(System.Action<int, int, float, int[], float[]> f)
            {
                action = f;
                started = true;
            }

            public static float get(int i) { action(1, i, 0f, ibox, fbox); return fbox[0]; }
            public static float set(int i, float v) { action(2, i, v, ibox, fbox); return fbox[0]; }
            public static int length() { action(0,0,0f,ibox,fbox); return ibox[0]; }

        }

        private static Vector2 MakeVec(int i, int j)
        {
            return new Vector2( gt.get(i) * Screen.width , gt.get(j) * Screen.height );
        }
        private static Rect MakeRect()
        {
            return new Rect(MakeVec(0, 1), MakeVec(2, 3));
        }

        private static void SwitchScenes()
        {
            SceneManager.LoadScene(otherSceneName);
        }

        public static void RenderButton(System.Action<int, int, float, int[], float[]> action) {
            gt.Start(action);
            Rect rect = MakeRect();

            if (GUI.Button(rect, "test-button")) { SwitchScenes(); }
        }
    }
    private void ShowTestButton() { ButtonBox.RenderButton(_access); }
    #endregion

    private class REPORTER {
        // I wrote this class for debuging

        private static int INDEX = 0;
        private const string TAG = "XYLVBAXMMTVPTIMLOHVJ";

        public static void report(string msg="", int index = -1 ,[CallerLineNumber] int ln = 0, [CallerMemberName] string nm="")
        {
            string tag = index < 0 ? TAG : TAG + '[' + index + ']';
            string gp = "\n        ";
            Debug.Log(string.Format("{0} : {1}message : {2}{1}caller : {3}{1}line : {4}",tag,gp,msg,nm,ln));

        }
        public static int clicker() { return INDEX++; }

    }

    #region declair fields/properties
    private BannerView bannerView;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;
    private float deltaTime = 0.0f;
    private static string outputMessage = string.Empty;

    public static string OutputMessage
    {
        set { outputMessage = value; }
    }
    #endregion

    #region lifeCycle-methods
    public void Start()
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

        MobileAds.SetiOSAppPauseOnBackground(true);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        this.CreateAndLoadRewardedAd();

        REPORTER.report("starting");
       
    }

    public void Update()
    {
        // Calculate simple moving average for time to render screen. 0.1 factor used as smoothing
        // value.
        this.deltaTime += (Time.deltaTime - this.deltaTime) * 0.1f;
        
    }

    public void OnGUI()
    {
        ShowTestButton();

        #region compute rect-dimentions
        GUI.skin.button.fontSize = (int)(0.035f * Screen.width);
        float buttonWidth = 0.35f * Screen.width;
        float buttonHeight = 0.15f * Screen.height;
        float columnOnePosition = 0.1f * Screen.width;
        float columnTwoPosition = 0.55f * Screen.width;
        #endregion

        #region compute and show fps

        GUIStyle style = new GUIStyle();
        
        Rect rect = new Rect(0, 0, Screen.width, Screen.height);
        style.alignment = TextAnchor.LowerRight;
        style.fontSize = (int)(Screen.height * 0.06);
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        float fps = 1.0f / this.deltaTime;
        string text = string.Format("{0:0.} fps", fps);
        GUI.Label(rect, text, style);

        #endregion
        
        #region Put some basic buttons onto the screen.


        #region add requestBanner button
        Rect requestBannerRect = new Rect(
            columnOnePosition,
            0.05f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestBannerRect, "Request\nBanner"))
        {
            this.RequestBanner();
        }
        #endregion

        #region add destroyBanner button
        Rect destroyBannerRect = new Rect(
            columnOnePosition,
            0.225f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(destroyBannerRect, "Destroy\nBanner"))
        {
            this.bannerView.Destroy();
        }
        #endregion

        #region add requestInterstitial button
        Rect requestInterstitialRect = new Rect(
            columnOnePosition,
            0.4f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestInterstitialRect, "Request\nInterstitial"))
        {
            this.RequestInterstitial();
        }
        #endregion

        #region add showInterstitial button
        Rect showInterstitialRect = new Rect(
            columnOnePosition,
            0.575f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(showInterstitialRect, "Show\nInterstitial"))
        {
            this.ShowInterstitial();
        }
        #endregion

        #region add destroyInterstitial button
        Rect destroyInterstitialRect = new Rect(
            columnOnePosition,
            0.75f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(destroyInterstitialRect, "Destroy\nInterstitial"))
        {
            this.interstitial.Destroy();
        }
        #endregion

        #region add requestRewarded button
        Rect requestRewardedRect = new Rect(
            columnTwoPosition,
            0.05f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(requestRewardedRect, "Request\nRewarded Ad"))
        {
            this.CreateAndLoadRewardedAd();
        }
        #endregion

        #region add showRewarded button
        Rect showRewardedRect = new Rect(
            columnTwoPosition,
            0.225f * Screen.height,
            buttonWidth,
            buttonHeight);
        if (GUI.Button(showRewardedRect, "Show\nRewarded Ad"))
        {
            this.ShowRewardedAd();
        }
        #endregion

        #endregion

        #region show outputMessage
        Rect textOutputRect = new Rect(
            columnTwoPosition,
            0.925f * Screen.height,
            buttonWidth,
            0.05f * Screen.height);
        GUI.Label(textOutputRect, outputMessage);
        #endregion
      
    }
    #endregion

    #region helper-methods
    // Returns an ad request with custom ad targeting.
    private AdRequest CreateAdRequest()
    {
        int index = REPORTER.clicker();
        REPORTER.report("method-called",index);


        #region debuging-version (includes the 'return'-statement)
        /*
        AdRequest.Builder builder = new AdRequest.Builder();

        REPORTER.report("made-builder", index);

        builder = builder.AddTestDevice(AdRequest.TestDeviceSimulator);

        REPORTER.report("~AddTestDevice", index);

        builder = builder.AddTestDevice("0123456789ABCDEF0123456789ABCDEF");

        REPORTER.report("~AddTestDevice (alph-code)", index);

        builder = builder.AddKeyword("game");

        REPORTER.report("~AddKeyword", index);

        builder = builder.SetGender(Gender.Male);

        REPORTER.report("~SetGender", index);

        builder = builder.SetBirthday(new System.DateTime(1985, 1, 1));

        REPORTER.report("~SetBirthday", index);

        builder = builder.TagForChildDirectedTreatment(false);

        REPORTER.report("~TagForChildDirectedTreatment");

        builder = builder.AddExtra("color_bg", "9B30FF");

        REPORTER.report("~AddExtra", index);

        AdRequest request = builder.Build();

        REPORTER.report("made-request", index);

        REPORTER.report("finishing-method",index);

        return request;
        */
        #endregion
        
        
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

    private void RequestBanner()
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of method",index);

        // These ad units are configured to always serve test ads.

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

        #region Clean up banner ad before creating a new one.
        if (this.bannerView != null)
        {
            this.bannerView.Destroy();
        }
        #endregion

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Top);
        
        #region Register for ad events.
        this.bannerView.OnAdLoaded += this.HandleAdLoaded;
        this.bannerView.OnAdFailedToLoad += this.HandleAdFailedToLoad;
        this.bannerView.OnAdOpening += this.HandleAdOpened;
        this.bannerView.OnAdClosed += this.HandleAdClosed;
        this.bannerView.OnAdLeavingApplication += this.HandleAdLeftApplication;
        #endregion

        // Load a banner ad.
        this.bannerView.LoadAd(this.CreateAdRequest());
        REPORTER.report("end of method",index);
    }

    private void RequestInterstitial()
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of method",index);
        // These ad units are configured to always serve test ads.

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


        #region Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }
        #endregion

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        #region Register for ad events.
        this.interstitial.OnAdLoaded += this.HandleInterstitialLoaded;
        this.interstitial.OnAdFailedToLoad += this.HandleInterstitialFailedToLoad;
        this.interstitial.OnAdOpening += this.HandleInterstitialOpened;
        this.interstitial.OnAdClosed += this.HandleInterstitialClosed;
        this.interstitial.OnAdLeavingApplication += this.HandleInterstitialLeftApplication;
        #endregion

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());

        REPORTER.report("end of method",index);
    }

    public void CreateAndLoadRewardedAd()
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of method",index);
        #region declair and set adUnitId-string
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
        string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
        string adUnitId = "unexpected_platform";
#endif
        #endregion

        // Create new rewarded ad instance.
        this.rewardedAd = new RewardedAd(adUnitId);

        #region add handlers to this.rewardedAd
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        #endregion

        // Create an empty ad request.
        AdRequest request = this.CreateAdRequest();

        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
        REPORTER.report("end of method",index);
    }

    private void ShowInterstitial()
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of method",index);
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            MonoBehaviour.print("Interstitial is not ready yet");
        }
        REPORTER.report("end of method",index);
    }

    private void ShowRewardedAd()
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of method",index);
        if (this.rewardedAd.IsLoaded())
        {
            this.rewardedAd.Show();
        }
        else
        {
            MonoBehaviour.print("Rewarded ad is not ready yet");
        }
        REPORTER.report("end of method",index);
    }
    #endregion

    #region Banner callback handlers

    public void HandleAdLoaded(object sender, System.EventArgs args)
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of callback (Banner)",index);
        MonoBehaviour.print("HandleAdLoaded event received");
        REPORTER.report("end of callback (Banner)",index);
    }

    public void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of callback (Banner)",index);
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
        REPORTER.report("end of callback (Banner)",index);
    }

    public void HandleAdOpened(object sender, System.EventArgs args)
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of callback (Banner)",index);
        MonoBehaviour.print("HandleAdOpened event received");
        REPORTER.report("end of callback (Banner)",index);
    }

    public void HandleAdClosed(object sender, System.EventArgs args)
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of callback (Banner)",index);
        MonoBehaviour.print("HandleAdClosed event received");
        REPORTER.report("end of callback (Banner)",index);
    }

    public void HandleAdLeftApplication(object sender, System.EventArgs args)
    {
        int index = REPORTER.clicker();
        REPORTER.report("start of callback (Banner)",index);
        MonoBehaviour.print("HandleAdLeftApplication event received");
        REPORTER.report("end of callback (Banner)",index);
    }

    #endregion

    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLoaded event received");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialOpened event received");
    }

    public void HandleInterstitialClosed(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleInterstitialLeftApplication event received");
    }

    #endregion

    #region RewardedAd callback handlers

    public void HandleRewardedAdLoaded(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: " + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
    }

    #endregion
}
