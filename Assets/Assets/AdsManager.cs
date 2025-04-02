using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;
    public static bool isMenu = false;
    void Start()
    {
    
    }

    void Awake()
    {
        Instance = this;
    }

    private void InitializeSdk()
    {
    }


    public void showInterstitial()
    {
        
    }

    public void showRewardedVideo()
    {
        
    }

}

