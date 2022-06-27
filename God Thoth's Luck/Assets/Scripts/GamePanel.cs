using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject slotGamePanel;

    [SerializeField]
    private Animator slotGamePanelAnim;

    public void OpenGamePanel()
    {
        slotGamePanel.SetActive(true);
        slotGamePanelAnim.Play("SlideIn");

    }
    public void CloseGamePanel()
    {
        StartCoroutine(CloseGame());
    }
    IEnumerator CloseGame()
    {
        slotGamePanelAnim.Play("SlideOut");
        yield return new WaitForSeconds(1f);
        slotGamePanel.SetActive(false);
    }
}