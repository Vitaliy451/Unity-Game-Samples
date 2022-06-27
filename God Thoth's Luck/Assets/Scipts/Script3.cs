using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppsFlyerSDK;
public class Script3 : MonoBehaviour
{
    // Start is called before the first frame update

    public static Script3 Mains;
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
    void Start()
    {
        AppsFlyer.setIsDebug(false);
        AppsFlyer.initSDK(MainScriptForGame.Mains.devKey, "", true ? this : null);
        AppsFlyer.startSDK();

    }
    string[] AffTake = { "media_source", "af_id", "ad_id", "adset_id", "af_channel", "campaign", "adset", "adgroup", "orig_cost", "af_siteid" };
    public void onConversionDataSuccess(string conversionData)
    {
        StartCoroutine(convers(conversionData));
    }
    IEnumerator convers(string conversionData)
    {
        yield return new WaitForSeconds(1);
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
        string status = conversionDataDictionary["af_status"].ToString();

        for (int i = 0; i < AffTake.Length; i++)
        {
            if (AffTake[i] == "af_id")
            {
                MainScriptForGame.Mains.value[i] = AppsFlyer.getAppsFlyerId();
            }
            else if (status != "Organic")
            {
                if (conversionDataDictionary.ContainsKey(AffTake[i]))
                {
                    try
                    {
                        if (conversionDataDictionary[AffTake[i]] != null)
                        {
                            MainScriptForGame.Mains.value[i] = conversionDataDictionary[AffTake[i]].ToString();
                        }
                    }
                    catch
                    {
                        MainScriptForGame.Mains.value[i] = "null";
                    }
                }
            }
        }
        MainScriptForGame.Mains.ready[1] = true;
        yield break;
    }
    public void onConversionDataFail(string error)
    {
        MainScriptForGame.Mains.ready[1] = true;
    }
    public void onAppOpenAttribution(string attributionData)
    {

    }
    public void onAppOpenAttributionFailure(string error)
    {

    }
}
