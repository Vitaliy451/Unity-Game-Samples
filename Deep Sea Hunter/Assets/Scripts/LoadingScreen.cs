using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public static int SceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneNumber == 0)
        {
            StartCoroutine(ToSplashTwo());
        }
       

    }
    IEnumerator ToSplashTwo()
    {
        yield return new WaitForSeconds(10);
        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
