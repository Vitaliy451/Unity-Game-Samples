using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public static int SceneNumber;

    public GameObject loadingScreen;

    public Slider slider;

    void Start()
    {
        if (SceneNumber == 0)
        {
            StartCoroutine(ToSplashTwo());
        }


    }
    IEnumerator ToSplashTwo()
    {

        for (int i = 0; i < 11; i++)
        {
            slider.value += 0.1f;
            yield return new WaitForSeconds(1);
        }

        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }

}
