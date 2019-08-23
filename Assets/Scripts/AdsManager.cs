using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;

    void Awake()
    {
        Instance = this;

        Monetization.Initialize (gameId, testMode);
    }

    public string gameId = "3263407";
    public bool testMode = true;

    void Start()
    {
    }

    public void ShowVideoAd ()
    {
        StartCoroutine (ShowAdWhenReady ("video"));
    }

    private IEnumerator ShowAdWhenReady (string placementId) 
    {
        while (!Monetization.IsReady (placementId)) {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent (placementId) as ShowAdPlacementContent;

        if(ad != null) {
            ad.Show ();
        }
    }

    private IEnumerator ShowBannerWhenReady()
    {
        while(!Advertisement.Banner.isLoaded)
        {
            yield return new WaitForSeconds(0.25f);
        }

        Advertisement.Banner.Show();
    }
}
