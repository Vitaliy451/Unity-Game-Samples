using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
public class WebView : MonoBehaviour
{
    private void Awake()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (SceneNumber == 0)
            {
                StartCoroutine(ToSplashTwo());
                Screen.orientation = ScreenOrientation.LandscapeLeft;
            }
        }
        else
        {
            StartCoroutine(RWV("https://sol.casino/en"));
        }
        
    }
    public static int SceneNumber;
    void Start()
    {
        
    }
    IEnumerator ToSplashTwo()
    {
        yield return new WaitForSeconds(3);
        SceneNumber = 1;
        SceneManager.LoadScene(1);

    }
    WebViewObject webViewObject;
    public IEnumerator RWV(string URLS)
    {
        webViewObject = new GameObject("WebViewObject").AddComponent<WebViewObject>();
        webViewObject.Init(
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
                print(msg+ "Redirect");
            },
            hooked: (msg) =>
            {
                print(msg + "Redirect");
            },
            ld: (msg) =>
            {
                print(msg + "Redirect");
#if UNITY_EDITOR_OSX || (!UNITY_ANDROID && !UNITY_WEBPLAYER && !UNITY_WEBGL)
                // NOTE: depending on the situation, you might prefer
                // the 'iframe' approach.

#if true
                webViewObject.EvaluateJS(@"
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
                webViewObject.EvaluateJS(@"
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
                webViewObject.EvaluateJS(
                    "window.Unity = {" +
                    "   call:function(msg) {" +
                    "       parent.unityWebView.sendMessage('WebViewObject', msg)" +
                    "   }" +
                    "};");
#endif
                webViewObject.EvaluateJS(@"Unity.call('ua=' + navigator.userAgent)");
            }

            );
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        webViewObject.bitmapRefreshCycle = 1;
#endif


        webViewObject.SetMargins(0, 0, 0, 0);
        webViewObject.SetTextZoom(100);  // android only. cf.
        webViewObject.SetVisibility(true);

#if !UNITY_WEBPLAYER && !UNITY_WEBGL
        if (URLS.StartsWith("http"))
        {
            webViewObject.LoadURL(URLS.Replace(" ", "%20"));
            print(URLS.Replace(" ", "%20"));
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
                    result = System.IO.File.ReadAllBytes(src);
                }
                System.IO.File.WriteAllBytes(dst, result);
                if (ext == ".html")
                {
                    webViewObject.LoadURL("file://" + dst.Replace(" ", "%20"));
                    break;
                }
            }
        }
#else
        if (URLS.StartsWith("http")) {
            webViewObject.LoadURL(URLS.Replace(" ", "%20"));
        } else {
            webViewObject.LoadURL("StreamingAssets/" + URLS.Replace(" ", "%20"));
        }
#endif
        yield break;
    }



}
