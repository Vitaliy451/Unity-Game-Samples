using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private GameObject selectMenuPanel;
    [SerializeField]
    private Animator selectMenuAnim;

    public void OpenGameMenuPanel()
    {
        selectMenuPanel.SetActive(true);
        selectMenuAnim.Play("SlideIn");

    }
    public void CloseGameMenuPanel()
    {
        StartCoroutine(CloseGame());
    }
    IEnumerator CloseGame()
    {
        selectMenuAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        selectMenuPanel.SetActive(false);
    }
}