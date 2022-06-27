using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rows : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;


    // Start is called before the first frame update
    void Start()
    {
        rowStopped = true;
        GameControl.HandlePulled += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");

    }
    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -1.75f)
                transform.position = new Vector2(transform.position.x, 3.5f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            yield return new WaitForSeconds(timeInterval);
        }

        randomValue = Random.Range(60, 100);

        switch (randomValue % 3)
        {
            case 1:
                randomValue += 1;
                break;
            case 2:
                randomValue += 2;
                break;
            
        }

        for (int i = 0; i < randomValue; i++)
        {
            if (transform.position.y <= -1.75f)
                transform.position = new Vector2(transform.position.x, 3.5f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f))
                timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f))
                timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }

        //step for each roll is 92f

        if (transform.position.y <= 4f && transform.position.y >= 3.25f)
            stoppedSlot = "PurpleTen";
        else if (transform.position.y <= 3f && transform.position.y >= 2.25f)
            stoppedSlot = "GoldA";
        else if (transform.position.y <= 1.95f && transform.position.y >= 0.9f)
            stoppedSlot = "BlueJ";
        else if (transform.position.y <= 0.75f && transform.position.y >= -0.3f)
            stoppedSlot = "Princess";
        else if (transform.position.y <= -0.75f && transform.position.y >= -1.5f)
            stoppedSlot = "Dolphin";
        else if (transform.position.y <= -1.75f && transform.position.y >= -2.75)
            stoppedSlot = "GreenQ";
        else if (transform.position.y <= -3f && transform.position.y >= -4.5f)
            stoppedSlot = "Poseidon";

        rowStopped = true;
    }

    private void OnDestroy()
    {
        GameControl.HandlePulled -= StartRotating;
    }

  
}
