using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class UnityAdsTools : MonoBehaviour, IAdsShower, IUnityAdsListener
{
    private const string _gameIdAndroid = "4220891";
    private const string _revardPlacementId = "revardedVideo";
    private const string _bannerPlacementId = "banner";
    private const string _interstitialPlacementId = "interstitial";



    private Action _callbackSuccessShowVideo;
    private void Start()
    {
        Advertisement.Initialize(_gameIdAndroid, true);
    }
    public void ShowBanner()
    {
        Advertisement.Show(_bannerPlacementId);
    }

    public void ShowRewardedVideo()
    {
        Advertisement.Show(_revardPlacementId);
    }


    public void OnUnityAdsDidError(string message)
    {
        //throw new System.NotImplementedException();
    }

   

    public void OnUnityAdsDidStart(string placementId)
    {
       // throw new System.NotImplementedException();
    }

    public void OnUnityAdsReady(string placementId)
    {
        //throw new System.NotImplementedException();
    }

    

   

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Skipped)
            Debug.Log("Skipped");
    }

    public void ShowInterstitialVideo()
    {
        _callbackSuccessShowVideo = null;
        Advertisement.Show(_interstitialPlacementId);
    }
}
