using UnityEngine;

public class Script4 : MonoBehaviour
{
    public static Script4 Mains;

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
    private void Start()
    {
        try
        {
            Application.RequestAdvertisingIdentifierAsync((string advertisingId, bool trackingEnabled, string error) => { MainScriptForGame.Mains.gaid = advertisingId; MainScriptForGame.Mains.ready[0] = true; });
        }
        catch
        {
            MainScriptForGame.Mains.ready[0] = true;
        }
    }
}
