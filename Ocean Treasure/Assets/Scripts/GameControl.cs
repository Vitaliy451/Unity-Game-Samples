using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameControl : MonoBehaviour
{
    public static event Action HandlePulled = delegate { };

    [SerializeField]
    private Text prizeText;

    [SerializeField]
    private Text Coins;

    [SerializeField]
    private Rows[] rows;

    [SerializeField]
    private Transform handle;

    [SerializeField]
    private Button backButton;

    private int prizeValue;

    private int currentCoins;

    private bool resultsChecked = false;

    void Update()
    {
        //Debug.Log("1");
        if (!rows[0].rowStopped || !rows[1].rowStopped || !rows[2].rowStopped || !rows[3].rowStopped)
        {
            //Debug.Log("2");
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
            

        }
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped && !resultsChecked)
        {
            //Debug.Log("3");
            CheckResults();
            //Debug.Log($"Slot position {rows[0]} is at: {rows[1].transform.position.y}");
            //Debug.Log($"Slot position {rows[1]} is at: {rows[1].transform.position.y}");
            //Debug.Log($"Slot position {rows[2]} is at: {rows[1].transform.position.y}");
            //Debug.Log($"Slot position {rows[3]} is at: {rows[1].transform.position.y}");
            prizeText.enabled = true;
            if (prizeValue != 0)
            {
                prizeText.text = $"Prize:{prizeValue}!";
                currentCoins += prizeValue;
                Coins.text = $"{currentCoins}";
            }
            else
                prizeText.text = "Try your luck!";

            Debug.Log(prizeValue);
        }
    }


    public void OnMouseDown()
    {
        //Debug.Log("4");
        if (rows[0].rowStopped && rows[1].rowStopped && rows[2].rowStopped && rows[3].rowStopped)
        {
            //Debug.Log("5");
            StartCoroutine("PullButton");
            backButton.interactable = false;
        }


    }

    private IEnumerator PullButton()
    {


        handle.Rotate(0f, 0f, 0f);
        yield return new WaitForSeconds(0.1f);


        HandlePulled();


        handle.Rotate(0f, 0f, 0);
        yield return new WaitForSeconds(0.1f);

    }

    private void CheckResults()
    {
        //Check for quadruplets
        if (rows[0].stoppedSlot == "LetterJ"
                && rows[1].stoppedSlot == "LetterJ"
                && rows[2].stoppedSlot == "LetterJ"
                && rows[3].stoppedSlot == "LetterJ")
        {
            prizeValue = 1000;
            Debug.Log("LetterJ:1000");
        }

        else if (rows[0].stoppedSlot == "letterK"
                && rows[1].stoppedSlot == "letterK"
                && rows[2].stoppedSlot == "letterK"
                && rows[3].stoppedSlot == "letterK")
        {
            prizeValue = 2000;
            Debug.Log("letterK:2000");
        }
        else if (rows[0].stoppedSlot == "LetterQ"
                && rows[1].stoppedSlot == "LetterQ"
                && rows[2].stoppedSlot == "LetterQ"
                && rows[3].stoppedSlot == "LetterQ")
        {
            prizeValue = 3000;
            Debug.Log("LetterQ:3000");
        }

        else if (rows[0].stoppedSlot == "bottle"
                && rows[1].stoppedSlot == "bottle"
                && rows[2].stoppedSlot == "bottle"
                && rows[3].stoppedSlot == "bottle")
        {
            prizeValue = 4000;
            Debug.Log("bottle:4000");
        }

        else if (rows[0].stoppedSlot == "compass"
                && rows[1].stoppedSlot == "compass"
                && rows[2].stoppedSlot == "compass"
                && rows[3].stoppedSlot == "compass")
        {
            prizeValue = 5000;
            Debug.Log("compass:5000");
        }

        else if (rows[0].stoppedSlot == "goldenNugget"
                && rows[1].stoppedSlot == "goldenNugget"
                && rows[2].stoppedSlot == "goldenNugget"
                && rows[3].stoppedSlot == "goldenNugget")
        {
            prizeValue = 6000;
            Debug.Log("goldenNugget:6000");
        }

        else if (rows[0].stoppedSlot == "chest"
                && rows[1].stoppedSlot == "chest"
                && rows[2].stoppedSlot == "chest"
                && rows[3].stoppedSlot == "chest")
        {
            prizeValue = 7777;
            Debug.Log("chest:7777");
        }
        //--


        //Check for duos
        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[0].stoppedSlot == "LetterJ"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "LetterJ"))

            || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
            && (rows[0].stoppedSlot == "LetterJ"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[1].stoppedSlot == "LetterJ"))

            || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
            && (rows[1].stoppedSlot == "LetterJ"))

            || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
            && (rows[2].stoppedSlot == "LetterJ")))))
        {
            prizeValue = 100;
            Debug.Log("2 LetterJ:100");
        }


        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "letterK"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "letterK"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "letterK"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "letterK"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "letterK"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "letterK")))))
        {
            prizeValue = 200;
            Debug.Log("2 letterK:200");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "letterQ"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "letterQ"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "letterQ"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "letterQ"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "letterQ"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "letterQ")))))
        {
            prizeValue = 300;
            Debug.Log("2 letterQ:300");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "bottle"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "bottle"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "bottle"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "bottle"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "bottle"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "bottle")))))
        {
            prizeValue = 400;
            Debug.Log("2 bottle:400");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "compass"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "compass"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "compass"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "compass"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "compass"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "compass")))))
        {
            prizeValue = 500;
            Debug.Log("2 compass:500");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "goldenNugget"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "goldenNugget"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "goldenNugget"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "goldenNugget"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "goldenNugget"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "goldenNugget")))))
        {
            prizeValue = 600;
            Debug.Log("2 goldenNugget:600");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "chest"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "chest"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "chest"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "chest"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "chest"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "chest")))))
        {
            prizeValue = 777;
            Debug.Log("2 chest:777");
        }
        //--

        //Check for triplets
        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "LetterJ"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "LetterJ"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "LetterJ"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "LetterJ")))))
        {
            prizeValue = 250;
            Debug.Log("3 LetterJ:250");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "letterK"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "letterK"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "letterK"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "letterK")))))
        {
            prizeValue = 350;
            Debug.Log("3 letterK:350");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "letterQ"))

          || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
          && (rows[2].stoppedSlot == rows[3].stoppedSlot)
          && (rows[1].stoppedSlot == "letterQ"))

          || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
          && (rows[2].stoppedSlot == rows[3].stoppedSlot)
          && (rows[0].stoppedSlot == "letterQ"))

          || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
          && (rows[1].stoppedSlot == rows[3].stoppedSlot)
          && (rows[0].stoppedSlot == "letterQ")))))
        {
            prizeValue = 350;
            Debug.Log("3 letterQ:450");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "bottle"))

          || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
          && (rows[2].stoppedSlot == rows[3].stoppedSlot)
          && (rows[1].stoppedSlot == "bottle"))

          || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
          && (rows[2].stoppedSlot == rows[3].stoppedSlot)
          && (rows[0].stoppedSlot == "bottle"))

          || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
          && (rows[1].stoppedSlot == rows[3].stoppedSlot)
          && (rows[0].stoppedSlot == "bottle")))))
        {
            prizeValue = 450;
            Debug.Log("3 letterQ:450");
        }
        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "compass"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "compass"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "compass"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "compass")))))
        {
            prizeValue = 650;
            Debug.Log("3 compass:650");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "goldenNugget"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "goldenNugget"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "goldenNugget"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "goldenNugget")))))
        {
            prizeValue = 750;
            Debug.Log("3 goldenNugget:750");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "chest"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "chest"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "chest"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "chest")))))
        {
            prizeValue = 850;
            Debug.Log("3 chest:850");
        }
        //--

        resultsChecked = true;
        backButton.interactable = true;
    }
}