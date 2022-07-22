using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;  //

public class BannerAdmob : MonoBehaviour
{
    private BannerView bannerView;



    public void Start()// Start is called before the first frame update
    {
        MobileAds.Initialize(initStatus => { });

        this.RequestBanner();

    }

    private void RequestBanner()
    {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-9743242268323219/1333856602";
#elif UNITY_IPHONE
#else
        string adUnitId = "unexpected_platform";
#endif
        if (this.bannerView != null)
        {
            bannerView.Destroy();
        }

        AdSize adaptiveSize =
            AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerView.LoadAd(request);
    }


    void Update()// Update is called once per frame
    {

    }
}
