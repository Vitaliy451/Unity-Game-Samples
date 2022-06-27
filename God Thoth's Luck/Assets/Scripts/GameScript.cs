using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameScript : MonoBehaviour
{
    public GameObject[] SQW;

    int pobedniy;

    public GameObject[] buttonHolder, pyramidHolder;

    public GameObject Tesx;

    private int prizeValue;

    private int currentCoins;

    public GameObject[] TTT;

    [SerializeField]
    private Text prizeText;

    [SerializeField]
    private Text Coins;

    public void QWERT()
    {
        TTT[0].GetComponent<Text>().text = "Win : " + score[0].ToString();
        TTT[1].GetComponent<Text>().text = "Lose : " + score[1].ToString();
        Tesx.GetComponent<Text>().text = "Try your Luck!";
        int i = 0;
        
        
        while (i < buttonHolder.Length)
        {
            buttonHolder[i].SetActive(true);
            i++;
        }
        int z = 0;
        while (z < pyramidHolder.Length)
        {
            pyramidHolder[z].SetActive(false);
            z++;
        }
        pobedniy = Random.Range(0, pyramidHolder.Length);
        pyramidHolder[pobedniy].SetActive(true);
    }

    
    IEnumerator POSE(int CHOSE)
    {
        for (int ee = 0; ee < buttonHolder.Length; ee++)
        {
            buttonHolder[ee].GetComponent<Animation>().Play();
        }
        yield return new WaitForSeconds(1);
        int i = 0;
        while (i < buttonHolder.Length)
        {
            buttonHolder[i].SetActive(false);
            i++;
        }
        if (CHOSE == pobedniy)
        {
            currentCoins += 100;
            Coins.text = $"{currentCoins}";
            Tesx.GetComponent<Text>().text = "You Won!";
            score[0]++;
            TTT[0].GetComponent<Text>().text = "Wins : " + score[0].ToString();
        }
        else
        {  
            Tesx.GetComponent<Text>().text = "You Lost!";
            score[1]++;
            TTT[1].GetComponent<Text>().text = "Loses : " + score[1].ToString();
        }
        yield return new WaitForSeconds(2f);
        for (int ee = 0; ee < buttonHolder.Length; ee++)
        {
            buttonHolder[ee].GetComponent<Image>().fillAmount = 1;
        }
        QWERT();

    }
    public void pobedniychus(int CHOSE)
    {

        StartCoroutine(POSE(CHOSE));

    }
    int[] score = new int[2];
    

}