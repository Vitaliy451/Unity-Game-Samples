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
        if (rows[0].stoppedSlot == "PurpleTen"
                && rows[1].stoppedSlot == "PurpleTen"
                && rows[2].stoppedSlot == "PurpleTen"
                && rows[3].stoppedSlot == "PurpleTen")
        {
            prizeValue = 1000;
            Debug.Log("PurpleTen:100");
        }

        else if (rows[0].stoppedSlot == "BlueJ"
                && rows[1].stoppedSlot == "BlueJ"
                && rows[2].stoppedSlot == "BlueJ"
                && rows[3].stoppedSlot == "BlueJ")
        {
            prizeValue = 2000;
            Debug.Log("BlueJ:200");
        }
        else if (rows[0].stoppedSlot == "GreenQ"
                && rows[1].stoppedSlot == "GreenQ"
                && rows[2].stoppedSlot == "GreenQ"
                && rows[3].stoppedSlot == "GreenQ")
        {
            prizeValue = 3000;
            Debug.Log("GreenQ:300");
        }

        else if (rows[0].stoppedSlot == "GoldA"
                && rows[1].stoppedSlot == "GoldA"
                && rows[2].stoppedSlot == "GoldA"
                && rows[3].stoppedSlot == "GoldA")
        {
            prizeValue = 4000;
            Debug.Log("GoldA:400");
        }

        else if (rows[0].stoppedSlot == "Dolphin"
                && rows[1].stoppedSlot == "Dolphin"
                && rows[2].stoppedSlot == "Dolphin"
                && rows[3].stoppedSlot == "Dolphin")
        {
            prizeValue = 5000;
            Debug.Log("Dolphin:500");
        }

        else if (rows[0].stoppedSlot == "Princess"
                && rows[1].stoppedSlot == "Princess"
                && rows[2].stoppedSlot == "Princess"
                && rows[3].stoppedSlot == "Princess")
        {
            prizeValue = 6000;
            Debug.Log("Princess:600");
        }

        else if (rows[0].stoppedSlot == "Poseidon"
                && rows[1].stoppedSlot == "Poseidon"
                && rows[2].stoppedSlot == "Poseidon"
                && rows[3].stoppedSlot == "Poseidon")
        {
            prizeValue = 7777;
            Debug.Log("Poseidon:777");
        }
        //--


        //Check for duos
        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[0].stoppedSlot == "PurpleTen"))

            || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "PurpleTen"))

            || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
            && (rows[0].stoppedSlot == "PurpleTen"))

            || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[1].stoppedSlot == "PurpleTen"))

            || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
            && (rows[1].stoppedSlot == "PurpleTen"))

            || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
            && (rows[2].stoppedSlot == "PurpleTen")))))
        {
            prizeValue = 100;
            Debug.Log("2 PurpleTen:100");
        }


        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "BlueJ"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "BlueJ"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "BlueJ"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "BlueJ"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "BlueJ"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "BlueJ")))))
        {
            prizeValue = 200;
            Debug.Log("2 BlueJ:200");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "GreenQ"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "GreenQ"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "GreenQ"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "GreenQ"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "GreenQ"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "GreenQ")))))
        {
            prizeValue = 300;
            Debug.Log("2 GreenQ:300");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "GoldA"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "GoldA"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "GoldA"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "GoldA"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "GoldA"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "GoldA")))))
        {
            prizeValue = 400;
            Debug.Log("2 GoldA:400");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "Dolphin"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "Dolphin"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Dolphin"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "Dolphin"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "Dolphin"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "Dolphin")))))
        {
            prizeValue = 500;
            Debug.Log("2 Dolphin:500");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "Princess"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "Princess"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Princess"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "Princess"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "Princess"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "Princess")))))
        {
            prizeValue = 600;
            Debug.Log("2 Princess:600");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[0].stoppedSlot == "Poseidon"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "Poseidon"))

           || ((rows[0].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Poseidon"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[1].stoppedSlot == "Poseidon"))

           || ((rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "Poseidon"))

           || ((rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[2].stoppedSlot == "Poseidon")))))
        {
            prizeValue = 777;
            Debug.Log("2 Poseidon:777");
        }
        //--

        //Check for triplets
        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "PurpleTen"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "PurpleTen"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "PurpleTen"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "PurpleTen")))))
        {
            prizeValue = 250;
            Debug.Log("3 PurpleTen:250");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
            && (rows[1].stoppedSlot == rows[2].stoppedSlot)
            && (rows[0].stoppedSlot == "BlueJ"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "BlueJ"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "BlueJ"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "BlueJ")))))
        {
            prizeValue = 350;
            Debug.Log("3 BlueJ:350");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "GreenQ"))

          || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
          && (rows[2].stoppedSlot == rows[3].stoppedSlot)
          && (rows[1].stoppedSlot == "GreenQ"))

          || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
          && (rows[2].stoppedSlot == rows[3].stoppedSlot)
          && (rows[0].stoppedSlot == "GreenQ"))

          || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
          && (rows[1].stoppedSlot == rows[3].stoppedSlot)
          && (rows[0].stoppedSlot == "GreenQ")))))
        {
            prizeValue = 350;
            Debug.Log("3 GreenQ:450");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "GoldA"))

          || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
          && (rows[2].stoppedSlot == rows[3].stoppedSlot)
          && (rows[1].stoppedSlot == "GoldA"))

          || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
          && (rows[2].stoppedSlot == rows[3].stoppedSlot)
          && (rows[0].stoppedSlot == "GoldA"))

          || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
          && (rows[1].stoppedSlot == rows[3].stoppedSlot)
          && (rows[0].stoppedSlot == "GoldA")))))
        {
            prizeValue = 450;
            Debug.Log("3 GreenQ:450");
        }
        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "Dolphin"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "Dolphin"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Dolphin"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Dolphin")))))
        {
            prizeValue = 650;
            Debug.Log("3 Dolphin:650");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "Princess"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "Princess"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Princess"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Princess")))))
        {
            prizeValue = 750;
            Debug.Log("3 Princess:750");
        }

        else if (((((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[0].stoppedSlot == "Poseidon"))

           || ((rows[1].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[1].stoppedSlot == "Poseidon"))

           || ((rows[0].stoppedSlot == rows[2].stoppedSlot)
           && (rows[2].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Poseidon"))

           || ((rows[0].stoppedSlot == rows[1].stoppedSlot)
           && (rows[1].stoppedSlot == rows[3].stoppedSlot)
           && (rows[0].stoppedSlot == "Poseidon")))))
        {
            prizeValue = 850;
            Debug.Log("3 Poseidon:850");
        }
        //--

        resultsChecked = true;
    }
}