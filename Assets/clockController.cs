using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clockController : MonoBehaviour
{
    public GameObject gameManager;
    public float timeOfDay;
    public float timeOfDayInitial;

    public float clockTimeHours;
    public float clockTimeMinutes;

    public float timeInterval;

    public bool countingDown;

    private bool dayCycleFinished;

    void Start()
    {
        timeOfDayInitial = gameManager.GetComponent<GameManager>().timeOfDay;
        gameObject.GetComponent<TMP_Text>().text = string.Format("{0}:{1}0", clockTimeHours, clockTimeMinutes);
        countingDown = true;
        dayCycleFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay = gameManager.GetComponent<GameManager>().timeOfDay;
        if ((timeOfDayInitial - timeOfDay) == timeInterval && countingDown)
        {
            clockTimeMinutes += 1;
            if (clockTimeMinutes == 6)
            {
                clockTimeMinutes = 0;
                clockTimeHours += 1;
            }

            gameObject.GetComponent<TMP_Text>().text = string.Format("{0}:{1}0", clockTimeHours, clockTimeMinutes);
            timeOfDayInitial = timeOfDay;

            if (clockTimeHours == 18)
            {
                countingDown = false;
                dayCycleFinished = true;
            }
        }

        if (dayCycleFinished)
        {
            gameManager.GetComponent<GameManager>().endOfDayCycle();
            dayCycleFinished = false;
        }
    }
}
