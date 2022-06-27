using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppsFlyerSDK;
public class Appsflayersss : MonoBehaviour
{
    public string DevKey;
    string apsflayerID;
    string[] value = new string[9];

    void Awake()
    {
        AppsFlyer.setIsDebug(true);
        AppsFlyer.initSDK(DevKey, "", true ? this : null);
        AppsFlyer.startSDK();
    }
    string[] AffTake = { "media_source",  "ad_id", "adset_id", "campaign_id", "campaign", "adset", "adgroup", "orig_cost", "af_siteid" };
    public void onConversionDataSuccess(string conversionData)
    {
        Dictionary<string, object> conversionDataDictionary = AppsFlyer.CallbackStringToDictionary(conversionData);
        string status = conversionDataDictionary["af_status"].ToString();
        apsflayerID = AppsFlyer.getAppsFlyerId();
        print(apsflayerID +" - log apsflayerID");
            for (int i = 0; i < AffTake.Length; i++)
            {

            if (status != "Organic")
            {
                if (conversionDataDictionary.ContainsKey(AffTake[i]))
                {
                    try
                    {
                        if (conversionDataDictionary[AffTake[i]] != null)
                        {
                            value[i] = conversionDataDictionary[AffTake[i]].ToString();
                            Debug.Log(AffTake[i] + " : " + value[i] + " - log Appsflayer");
                        }
                    }
                    catch
                    {
                        value [i] = "null";
                    }
                }
            }
        }
    }
    public void onConversionDataFail(string error)
    {

    }
    public void onAppOpenAttribution(string attributionData)
    {

    }
    public void onAppOpenAttributionFailure(string error)
    {
    }
}
