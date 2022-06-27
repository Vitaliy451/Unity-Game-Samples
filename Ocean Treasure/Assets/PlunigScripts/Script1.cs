using Facebook.Unity;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    public static Script1 Mains;
    private void Awake()
    {
        multiPoko();
    }
    void multiPoko()
    {
        if (Mains == null)
        {
            DontDestroyOnLoad(gameObject);
            Mains = this;
        }
        else if (Mains != this)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void  Start()
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
            MainScriptForGame.Mains.ready[2] = true;
        }

    }
    
    private void parseUrl(string url)
    {
        MainScriptForGame.Mains.STR = url;
        MainScriptForGame.Mains.ready[2] = true;
    }
}
