#if UNITY_ANDROID && !UNITY_EDITOR
#define ANDROID_DEVICE
#endif

using UnityEngine;

public static class AndroidRootChecker
{
    private static AndroidJavaObject _rootUtils;
    private static AndroidJavaObject _currentActivity;
    private static bool _initialized;
    
#if ANDROID_DEVICE
    private static readonly string[] RootAppsPackages =
    {
        "com.koushikdutta.superuser",
        "com.noshufou.android.su",
        "com.noshufou.android.su.elite",
        "com.ramdroid.appquarantine",
        "com.thirdparty.superuser",
        "com.yellowes.su",
        "com.zachspong.temprootremovejb",
        "eu.chainfire.supersu",

        //dangerous packages
        "com.chelpus.lackypatch",
        "com.dimonvideo.luckypatcher",
        "com.koushikdutta.rommanager",
        "com.koushikdutta.rommanager.license",
        "com.ramdroid.appquarantine",
        "com.ramdroid.appquarantinepro",

        //root cloaking packages
        "com.amphoras.hidemyroot",
        "com.amphoras.hidemyrootadfree",
        "com.devadvance.rootcloak",
        "com.devadvance.rootcloakplus",
        "com.formyhm.hiderootPremium",
        "com.formyhm.hideroot",
        "com.saurik.substrate",
        "com.zachspong.temprootremovejb",
        "de.robv.android.xposed.installer",
    };

    private static readonly string[] FilesPaths =
    {
        "/cache/recovery/xposed.zip",
        "/magisk/xposed/system/lib/libsigchain.so",
        "/magisk/xposed/system/lib/libart.so",
        "/magisk/xposed/system/lib/libart-disassembler.so",
        "/magisk/xposed/system/lib/libart-compiler.so",
        "/system/app/Superuser.apk",
        "/system/bin/app_process64_xposed",
        "/system/bin/app_process32_xposed",
        "/system/bin/app_process32_orig",
        "/system/bin/app_process64_orig",
        "/system/framework/XposedBridge.jar",
        "/system/lib/libxposed_art.so",
        "/system/lib64/libxposed_art.so",
        "/system/xposed.prop",
    };

    private static readonly string[] SuPaths =
    {
        "/data/local/",
        "/data/local/bin/",
        "/data/local/xbin/",
        "/magisk/.core/bin/",
        "/sbin/",
        "/su/bin/",
        "/su/xbin/",
        "/system/app/",
        "/system/bin/",
        "/system/bin/.ext/",
        "/system/bin/failsafe/",
        "/system/sd/xbin/",
        "/system/usr/we-need-root/",
        "/system/xbin/",
    };

    private static readonly string[] ReadOnlyPaths =
    {
        "/etc",
        "/sbin",
        "/system",
        "/system/bin",
        "/system/sbin",
        "/system/xbin",
        "/vendor/bin",
    };

    private static readonly string[] SuCommands =
    {
        "which su",
        "/system/xbin/which su",
        "/system/bin/which su",
    };

    private const string AndroidClassName = "com.unitymedved.rootchecker.RootUtils";
    private const string UnityClassName = "com.unity3d.player.UnityPlayer";
    private const string UnityClassField = "currentActivity";
#endif

    private static void Initialize()
    {
#if ANDROID_DEVICE
        using (var unityPlayer = new AndroidJavaClass(UnityClassName))
        {
            _currentActivity = unityPlayer.GetStatic<AndroidJavaObject>(UnityClassField);
        }
        _rootUtils = new AndroidJavaObject(AndroidClassName);
#endif
        _initialized = true;
    }
    
    public static bool CheckPackages()
    {
        if (!_initialized)
            Initialize();
        
#if ANDROID_DEVICE
        return _rootUtils.CallStatic<bool>("isAnyPackageFromListInstalled", new object[] { RootAppsPackages, _currentActivity });
#else
        return false;
#endif
    }

    public static bool CheckFiles()
    {
        if (!_initialized)
            Initialize();
        
#if ANDROID_DEVICE
        return _rootUtils.CallStatic<bool>("checkFiles", new object[] { FilesPaths });
#else
        return false;
#endif
    }

    public static bool CheckBinaries()
    {
        if (!_initialized)
            Initialize();
        
#if ANDROID_DEVICE
        return _rootUtils.CallStatic<bool>("checkBinary", new object[] { SuPaths, "su" }) || 
               _rootUtils.CallStatic<bool>("checkBinary", new object[] { SuPaths, "busybox" });
#else
        return false;
#endif
    }

    public static bool CheckDangerousProps()
    {
        if (!_initialized)
            Initialize();
        
#if ANDROID_DEVICE
        return _rootUtils.CallStatic<bool>("checkDangerousProps");
#else
        return false;
#endif
    }

    public static bool CheckReadWritePaths()
    {
        if (!_initialized)
            Initialize();
        
#if ANDROID_DEVICE
        return _rootUtils.CallStatic<bool>("checkRWPaths", new object[] { ReadOnlyPaths });
#else
        return false;
#endif
    }

    public static bool CheckTestKeys()
    {
        if (!_initialized)
            Initialize();
        
#if ANDROID_DEVICE
        return _rootUtils.CallStatic<bool>("checkTestKeys");
#else
        return false;
#endif
    }

    public static bool CheckCommandsExists()
    {
        if (!_initialized)
            Initialize();
        
#if ANDROID_DEVICE
        return _rootUtils.CallStatic<bool>("checkCommandsExists", new object[] { SuCommands });
#else
        return false;
#endif
    }

    public static bool IsRooted()
    {
        return CheckPackages() || CheckFiles() || CheckBinaries() || CheckDangerousProps() || CheckReadWritePaths() ||
               CheckTestKeys() || CheckCommandsExists();
    }
}