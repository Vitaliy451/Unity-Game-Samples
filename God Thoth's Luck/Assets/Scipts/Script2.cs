using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script2 : MonoBehaviour
{
    public static Script2 Mains;
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

}
