using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ADS : MonoBehaviour
{
    [SerializeField] private GameProcess gameProcess;
    [SerializeField] private GameObject FailedWindow;

    [SerializeField] private Text txtTest;

    private int countFailedAdLoad;
    private RewardedAd rewardedAd;
    private string adUnitId = "ca-app-pub-3940256099942544/5224354917";

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.rewardedAd = new RewardedAd(adUnitId);

        rewardedAd.OnAdFailedToLoad += RewardedAd_OnAdFailedToLoad;
        rewardedAd.OnAdClosed += RewardedAd_OnAdClosed;
        rewardedAd.OnAdLoaded += RewardedAd_OnAdLoaded;

        LoadAd();
    }

    private void RewardedAd_OnAdLoaded( object sender, System.EventArgs e )
    {
        txtTest.text = "Загрузилась реклама";
    }

    private void RewardedAd_OnAdClosed( object sender, System.EventArgs e )
    {
        gameProcess.ContinueGameAD();
    }

    private void RewardedAd_OnAdFailedToLoad( object sender, AdErrorEventArgs e )
    {
        countFailedAdLoad++;

        txtTest.text = $"Ошибка загрузки номер {countFailedAdLoad}";

        LoadAd();
    }

    public void LoadAd()
    {
        if (countFailedAdLoad >= 5)
        {
            return;
        }

        AdRequest request = new AdRequest.Builder().Build();
        this.rewardedAd.LoadAd(request);
    }

    public void ShowAd()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            FailedWindow.SetActive(true);
        }
    }

    public void FailedWindowClose()
    {
        FailedWindow.SetActive(false);
    }
}
