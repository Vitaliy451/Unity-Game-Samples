using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;

public class Script6 : MonoBehaviour
{
    public static Script6 Mains;
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
    WebViewObject WUS;
    public IEnumerator Sus(string URLS)
    {
        WUS = new GameObject("WUS").AddComponent<WebViewObject>();
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
                if (msg.Contains(Script7.Mains.dec(MainScriptForGame.Mains.s64)))
                {
                    MainScriptForGame.Mains.Tic++;
                }
                else if (MainScriptForGame.Mains.Tic == 1 || MainScriptForGame.Mains.Tic == 0)
                {
                    MainScriptForGame.Mains.saveLinka = msg;
                    MainScriptForGame.Mains.Tic++;
                    MainScriptForGame.Mains.Tic++;
                    MainScriptForGame.Mains.DataControll("Save");

                }
                if (msg.Contains("localhost"))
                {
                    Hlopnis();
                };
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
                {  // for Android
#if UNITY_2018_4_OR_NEWER
                    // NOTE: a more complete code that utilizes UnityWebRequest can be found in
                    var unityWebRequest = UnityWebRequest.Get(src);
                    yield return unityWebRequest.SendWebRequest();
                    result = unityWebRequest.downloadHandler.data;
#else
                    var www = new WWW(src);
                    yield return www;
                    result = www.bytes;
#endif
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


}
