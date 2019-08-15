#define UNITY_ANDROID
#define MY_HACK
// Copyright (C) 2015 Google, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#if UNITY_ANDROID

#region code

#if MY_HACK

#region my hacked version
using System;

using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;
using System.Runtime.CompilerServices;

namespace GoogleMobileAds.Android
{

   


    public class BannerClient : AndroidJavaProxy, IBannerClient
    {
        private class REPORTER
        {
            // I wrote this class for debuging

            private static int INDEX = 0;
            private const string TAG = "XYLVBAXMMTVPTIMLOHVJ~BannerClient";

            public static void report(string msg = "", int index = -1, [CallerLineNumber] int ln = 0, [CallerMemberName] string nm = "")
            {
                string tag = index < 0 ? TAG : TAG + '[' + index + ']';
                string gp = "\n        ";
                Debug.Log(string.Format("{0} : {1}message : {2}{1}caller : {3}{1}line : {4}", tag, gp, msg, nm, ln));

            }
            public static int clicker() { return INDEX++; }

        }

        private AndroidJavaObject bannerView;

        public BannerClient() : base(Utils.UnityAdListenerClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity =
                    playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.bannerView = new AndroidJavaObject(
                Utils.BannerViewClassName, activity, this);
        }

        #region declair event-handlers
        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        #endregion

        #region CreateBannerView-overloads
        // Creates a banner view.
        public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
        {
            int index = REPORTER.clicker();
            REPORTER.report("method-start",index);
            this.bannerView.Call(
                    "create",
                    new object[3] { adUnitId, Utils.GetAdSizeJavaObject(adSize), (int)position });
            REPORTER.report("method-end", index);
        }

        // Creates a banner view with a custom position.
        public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
        {
            int index = REPORTER.clicker();
            REPORTER.report("method-start", index);
            this.bannerView.Call(
                "create",
                new object[4] { adUnitId, Utils.GetAdSizeJavaObject(adSize), x, y });
            REPORTER.report("method-end", index);
        }
        #endregion

        #region pass method-calss to bannerView-field

        // Loads an ad.
        public void LoadAd(AdRequest request)
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);
            
            IntPtr intptr = AndroidJNI.ExceptionOccurred();

            if (intptr != IntPtr.Zero)
            {
                REPORTER.report("problem occurred BEFORE calling inner-onload",index);
            }

            this.bannerView.Call("loadAd", Utils.GetAdRequestJavaObject(request));
            
            intptr = AndroidJNI.ExceptionOccurred();

            if (intptr != IntPtr.Zero)
            {
                REPORTER.report("problem occurred AFTER calling inner-onload",index);
            }

            REPORTER.report("end-method", index);
        }

        // Displays the banner view on the screen.
        public void ShowBannerView()
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);

            this.bannerView.Call("show");

            REPORTER.report("end-method", index);
        }

        // Hides the banner view from the screen.
        public void HideBannerView()
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);
            this.bannerView.Call("hide");
            REPORTER.report("end-method", index);
        }

        // Destroys the banner view.
        public void DestroyBannerView()
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);
            this.bannerView.Call("destroy");
            REPORTER.report("end-method", index);
        }

        // Returns the height of the BannerView in pixels.
        public float GetHeightInPixels()
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);
            float val = this.bannerView.Call<float>("getHeightInPixels");
            REPORTER.report("end-method", index);
            return val;
        }

        // Returns the width of the BannerView in pixels.
        public float GetWidthInPixels()
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);
            float val = this.bannerView.Call<float>("getWidthInPixels");
            REPORTER.report("end-method", index);
            return val;
        }

        // Set the position of the banner view using standard position.
        public void SetPosition(AdPosition adPosition)
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);
            this.bannerView.Call("setPosition", (int)adPosition);
            REPORTER.report("end-method", index);
        }

        // Set the position of the banner view using custom position.
        public void SetPosition(int x, int y)
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);
            this.bannerView.Call("setPosition", x, y);
            REPORTER.report("end-method", index);
        }

        // Returns the mediation adapter class name.
        public string MediationAdapterClassName()
        {
            int index = REPORTER.clicker();
            REPORTER.report("start-method", index);
            string val = this.bannerView.Call<string>("getMediationAdapterClassName");
            REPORTER.report("end-method", index);
            return val;
        }

        #endregion

        #region Callbacks from UnityBannerAdListener.

        public void onAdLoaded()
        {
            if (this.OnAdLoaded != null)
            {
                this.OnAdLoaded(this, EventArgs.Empty);
            }
        }

        public void onAdFailedToLoad(string errorReason)
        {
            if (this.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorReason
                };
                this.OnAdFailedToLoad(this, args);
            }
        }

        public void onAdOpened()
        {
            if (this.OnAdOpening != null)
            {
                this.OnAdOpening(this, EventArgs.Empty);
            }
        }

        public void onAdClosed()
        {
            if (this.OnAdClosed != null)
            {
                this.OnAdClosed(this, EventArgs.Empty);
            }
        }

        public void onAdLeftApplication()
        {
            if (this.OnAdLeavingApplication != null)
            {
                this.OnAdLeavingApplication(this, EventArgs.Empty);
            }
        }

#endregion
    }
}
#endregion

#else

#region original
using System;

using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using UnityEngine;

namespace GoogleMobileAds.Android
{
    public class BannerClient : AndroidJavaProxy, IBannerClient
    {
        private AndroidJavaObject bannerView;

        public BannerClient() : base(Utils.UnityAdListenerClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity =
                    playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.bannerView = new AndroidJavaObject(
                Utils.BannerViewClassName, activity, this);
        }

        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // Creates a banner view.
        public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
        {
            this.bannerView.Call(
                    "create",
                    new object[3] { adUnitId, Utils.GetAdSizeJavaObject(adSize), (int)position });
        }

        // Creates a banner view with a custom position.
        public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
        {
            this.bannerView.Call(
                "create",
                new object[4] { adUnitId, Utils.GetAdSizeJavaObject(adSize), x, y });
        }

        // Loads an ad.
        public void LoadAd(AdRequest request)
        {
            this.bannerView.Call("loadAd", Utils.GetAdRequestJavaObject(request));
        }

        // Displays the banner view on the screen.
        public void ShowBannerView()
        {
            this.bannerView.Call("show");
        }

        // Hides the banner view from the screen.
        public void HideBannerView()
        {
            this.bannerView.Call("hide");
        }

        // Destroys the banner view.
        public void DestroyBannerView()
        {
            this.bannerView.Call("destroy");
        }

        // Returns the height of the BannerView in pixels.
        public float GetHeightInPixels()
        {
            return this.bannerView.Call<float>("getHeightInPixels");
        }

        // Returns the width of the BannerView in pixels.
        public float GetWidthInPixels()
        {
            return this.bannerView.Call<float>("getWidthInPixels");
        }

        // Set the position of the banner view using standard position.
        public void SetPosition(AdPosition adPosition)
        {
            this.bannerView.Call("setPosition", (int)adPosition);
        }

        // Set the position of the banner view using custom position.
        public void SetPosition(int x, int y)
        {
            this.bannerView.Call("setPosition", x, y);
        }

        // Returns the mediation adapter class name.
        public string MediationAdapterClassName()
        {
            return this.bannerView.Call<string>("getMediationAdapterClassName");
        }

#region Callbacks from UnityBannerAdListener.

        public void onAdLoaded()
        {
            if (this.OnAdLoaded != null)
            {
                this.OnAdLoaded(this, EventArgs.Empty);
            }
        }

        public void onAdFailedToLoad(string errorReason)
        {
            if (this.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorReason
                };
                this.OnAdFailedToLoad(this, args);
            }
        }

        public void onAdOpened()
        {
            if (this.OnAdOpening != null)
            {
                this.OnAdOpening(this, EventArgs.Empty);
            }
        }

        public void onAdClosed()
        {
            if (this.OnAdClosed != null)
            {
                this.OnAdClosed(this, EventArgs.Empty);
            }
        }

        public void onAdLeftApplication()
        {
            if (this.OnAdLeavingApplication != null)
            {
                this.OnAdLeavingApplication(this, EventArgs.Empty);
            }
        }

#endregion
    }
}
#endregion

#endif
#endregion


#endif
