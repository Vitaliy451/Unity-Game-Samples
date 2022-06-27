using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneSignalsss : MonoBehaviour
{
    void Start()
    {
        try
        {
            OneSignalka();
        }
        catch
        {
        }
    }

    public string OneSignalID;
    private void OneSignalka()
    {
        OneSignal.StartInit(OneSignalID)
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
}
