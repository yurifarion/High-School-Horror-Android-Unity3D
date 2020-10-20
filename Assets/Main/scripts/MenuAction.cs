using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class MenuAction : MonoBehaviour
{
	public GameObject music_on;
	public GameObject music_off;
	public bool isMusicOn = true;
	
	private BannerView bannerView;
	private RewardedAd rewardedAd;
    // Start is called before the first frame update
    void Start()
    {
         // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
		this.rewardedAd = new RewardedAd("ca-app-pub-3940256099942544/5224354917");

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
		// Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.RequestBanner();
    }
	 private void RequestBanner()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        // Create a 320x50 banner at the top of the screen.
        this.bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
		
		AdRequest request = new AdRequest.Builder().Build();
		bannerView.LoadAd(request);
    }
	void Update(){
		if(isMusicOn && music_on != null){
			music_on.SetActive(true);
			music_off.SetActive(false);
			AudioListener.volume = 1;
		}
		if(!isMusicOn && music_off != null){
			music_on.SetActive(false);
			music_off.SetActive(true);
			AudioListener.volume = 0;
		}
	}
	public void goToMainMenu(){
		Application.LoadLevel("Menu");
		bannerView.Destroy();
	}
	public void revive(){
		bannerView.Destroy();
		if (this.rewardedAd.IsLoaded()) {
			this.rewardedAd.Show();
		}
	}
	public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
						
						Application.LoadLevel("MainLevel");
    }
	public void goToGame(){
		Application.LoadLevel("MainLevel");
		bannerView.Destroy();
	}
	public void Quit(){
		Application.Quit();
	}
	public void ToggleMusic(){
		isMusicOn =  !isMusicOn;
	}
}
