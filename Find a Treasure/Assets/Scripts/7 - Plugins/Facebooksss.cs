using Facebook.Unity;
using UnityEngine;

public class Facebooksss : MonoBehaviour
{
    string DeepLink;

    void Start()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            FB.ActivateApp();
        }
    }
    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            FB.Mobile.FetchDeferredAppLinkData(DeepLinkCallback);
        }
        else
        {

        }
    }
    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void DeepLinkCallback(IAppLinkResult result)
    {

        if (!string.IsNullOrEmpty(result.TargetUrl))
        {
            parseUrl(result.TargetUrl);

        }
        else
        {

        }

    }

    private void parseUrl(string url)
    {
        DeepLink = url;
        print(DeepLink + " - log Deeplink");

    }
}
