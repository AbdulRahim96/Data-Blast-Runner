using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;
    public bool isTesting;
    private Action rewardedAction;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(this);
    }

    public void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            print("Init sucess");
            LoadRewardedAd();
            LoadInterstitialAd();
        });
        GameManager.OnGameOver += ShowInterstitialAd;
    }


    // ca-app-pub-3753275009199310/5397594770
    // These ad units are configured to always serve test ads.
#if UNITY_ANDROID
    public string _adUnitId = "ca-app-pub-3753275009199310/5397594770";
    public string _adUnitIdInterstitial = "ca-app-pub-3940256099942544/1033173712";
    // real ID ca-app-pub-3753275009199310/2707002197
    //public string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
#elif UNITY_IPHONE
  public string _adUnitId = "ca-app-pub-3753275009199310/4922086086";
  public string _adUnitIdInterstitial = "ca-app-pub-3753275009199310/8726449789";
 // private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
  private string _adUnitId = "unused";
#endif

    private void OnValidate()
    {
        if(isTesting)
        {
            _adUnitId = "ca-app-pub-3940256099942544/5224354917";
            _adUnitIdInterstitial = "ca-app-pub-3940256099942544/1033173712";
        }
        else
        {
            _adUnitId = "ca-app-pub-3753275009199310/5397594770";
            _adUnitIdInterstitial = "ca-app-pub-3753275009199310/2707002197";
        }
    }
    private RewardedAd _rewardedAd;

    /// <summary>
    /// Loads the rewarded ad.
    /// </summary>
    public void LoadRewardedAd()
    {
        // Clean up the old ad before loading a new one.
        if (_rewardedAd != null)
        {
            _rewardedAd.Destroy();
            _rewardedAd = null;
        }

        Debug.Log("Loading the rewarded ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        RewardedAd.Load(_adUnitId, adRequest,
            (RewardedAd ad, LoadAdError error) =>
            {

                Debug.Log("Rewarded ad loaded with response : "
                          + ad.GetResponseInfo());

                _rewardedAd = ad;
            });
    }

    public void ShowRewardedAd(Action function)
    {
        const string rewardMsg =
            "Rewarded ad rewarded the user. Type: {0}, amount: {1}.";

        if (_rewardedAd != null && _rewardedAd.CanShowAd())
        {
            _rewardedAd.Show((Reward reward) =>
            {
                // TODO: Reward the user.
                print("user rewarded");
                function?.Invoke();
            });
        }

        LoadRewardedAd();
    }

    private InterstitialAd _interstitialAd;

    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (_interstitialAd != null)
        {
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(_adUnitIdInterstitial, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                _interstitialAd = ad;
            });
    }

    public void ShowInterstitialAd()
    {
        if (_interstitialAd.CanShowAd())
        {
            Debug.Log("Showing interstitial ad.");
            _interstitialAd.Show();
        }
        else
        {
            Debug.LogError("Interstitial ad is not ready yet.");
        }

        LoadInterstitialAd();
    }
}




















#region YODOMAS
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using Yodo1.MAS;

//public class AdsManager : MonoBehaviour
//{
//    public static AdsManager Instance { set; get; }

//    private Yodo1U3dBannerAdView bannerAdView;

//    bool isBannerShown = false;

//    void Start()
//    {
//        SetDelegates();
//        InitializeSdk();
//  //      ShowBanner();
//        ShowInterstitial();
//    }

//    void Awake()
//    {
//        Instance = this;
//    }

//    private void InitializeSdk()
//    {
//        Yodo1U3dMas.InitializeSdk();
//    }

//    public void ShowBanner()
//    {
//        if (PlayerPrefs.HasKey("subscribed") == false)
//        {
//            // no need to check if banner is loaded just show directly.
//            //if (Yodo1U3dMas.IsBannerAdLoaded())
//            //{
//                int align = Yodo1U3dBannerAlign.BannerRight | Yodo1U3dBannerAlign.BannerHorizontalCenter;
//                Yodo1U3dMas.ShowBannerAd(align);
//            //}
//           // else
//          //  {
//              //  Debug.Log("[Yodo1 Mas] Banner ad has not been cached.");
//         //   }
//        }
//    }

//    public void HideBanner()
//    {
//        Yodo1U3dMas.DismissBannerAd();
//    }

//    public void ShowInterstitial()
//    {
//        if (PlayerPrefs.HasKey("subscribed") == false)
//        {
//            Yodo1U3dMas.ShowInterstitialAd();
//            if (Yodo1U3dMas.IsInterstitialAdLoaded())
//            {

//            }
//            else
//            {
//                Debug.Log("[Yodo1 Mas] Interstitial ad has not been cached.");
//            }
//        }
//    }

//    public void ShowRewarded()
//    {
//        Yodo1U3dMas.ShowRewardedAd();
//        if (Yodo1U3dMas.IsRewardedAdLoaded())
//        {

//        }
//        else
//        {
//            Debug.Log("[Yodo1 Mas] Reward video ad has not been cached.");
//        }
//    }



//    private void SetDelegates()
//    {


//        // Initialize the MAS SDK.
//        Yodo1U3dMas.SetInitializeDelegate((bool success, Yodo1U3dAdError error) => { });
//        Yodo1U3dMas.InitializeSdk();

//        this.RequestBanner();
//    }

//    private void RequestBanner()
//    {
//        // Clean up banner before reusing
//        if (bannerAdView != null)
//        {
//            bannerAdView.Destroy();
//        }

//        // Create a 320x50 banner at top of the screen
//        bannerAdView = new Yodo1U3dBannerAdView(Yodo1U3dBannerAdSize.Banner, Yodo1U3dBannerAdPosition.BannerTop | Yodo1U3dBannerAdPosition.BannerHorizontalCenter);
//    }

//    void InitializeInterstitialAds()
//        {
//            Yodo1U3dMasCallback.Interstitial.OnAdOpenedEvent +=
//            OnInterstitialAdOpenedEvent;
//            Yodo1U3dMasCallback.Interstitial.OnAdClosedEvent +=
//            OnInterstitialAdClosedEvent;
//            Yodo1U3dMasCallback.Interstitial.OnAdErrorEvent +=
//            OnInterstitialAdErorEvent;
//        }

//    void OnInterstitialAdOpenedEvent()
//        {
//            Debug.Log("[Yodo1 Mas] Interstitial ad opened");
//        }

//    void OnInterstitialAdClosedEvent()
//        {
//            Debug.Log("[Yodo1 Mas] Interstitial ad closed");
//        }

//    void OnInterstitialAdErorEvent(Yodo1U3dAdError adError)
//        {
//            Debug.Log("[Yodo1 Mas] Interstitial ad error - " + adError.ToString());
//        }

//    private void InitializeRewardedAds()
//    {
//        // Add Events
//        Yodo1U3dMasCallback.Rewarded.OnAdOpenedEvent += OnRewardedAdOpenedEvent;
//        Yodo1U3dMasCallback.Rewarded.OnAdClosedEvent += OnRewardedAdClosedEvent;
//        Yodo1U3dMasCallback.Rewarded.OnAdReceivedRewardEvent += OnAdReceivedRewardEvent;
//        Yodo1U3dMasCallback.Rewarded.OnAdErrorEvent += OnRewardedAdErorEvent;
//    }

//    private void OnRewardedAdOpenedEvent()
//    {
//        Debug.Log("[Yodo1 Mas] Rewarded ad opened");
//    }

//    private void OnRewardedAdClosedEvent()
//    {
//        Debug.Log("[Yodo1 Mas] Rewarded ad closed");
//    }

//    private void OnAdReceivedRewardEvent()
//    {
//        Debug.Log("[Yodo1 Mas] Rewarded ad received reward");
//        FindObjectOfType<Questions>().hint();
//    }

//    private void OnRewardedAdErorEvent(Yodo1U3dAdError adError)
//    {
//        Debug.Log("[Yodo1 Mas] Rewarded ad error - " + adError.ToString());
//    }
//}

#endregion