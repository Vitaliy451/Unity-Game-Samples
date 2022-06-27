using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovingScene : MonoBehaviour
{
    public static int SceneNumber;

    public GameObject loadingScreen;

    public Slider slider;

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

        for (int i = 0; i < 10; i++)
        {
            slider.value += 0.1f;
            yield return new WaitForSeconds(1);
        }
       
        
        SceneNumber = 1;
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
