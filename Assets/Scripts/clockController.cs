using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clockController : MonoBehaviour
{
    // declaring variables
    public GameObject gameManager; // game manager
    public float timeOfDay; // current time of day
    public float timeOfDayInitial; // the initial time of day (the time before the current time of day changes)

    public float clockTimeHours; // the clocks hours
    public float clockTimeMinutes; // the clocks minutes

    public float clockTimeHoursInitial; // the start hours
    public float clockTimeMinutesInitial; // the start minutes

    public float timeInterval; // the time interval

    public bool countingDown; // whether the time should be counting down or not


    void Start()
    {
        timeOfDayInitial = gameManager.GetComponent<GameManager>().timeOfDay; // setting the initial time of day to the game managers time of day
        gameObject.GetComponent<TMP_Text>().text = string.Format("{0}:{1}0", clockTimeHours, clockTimeMinutes); // setting the text to the default value of 6:00 (6AM)
        countingDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay = gameManager.GetComponent<GameManager>().timeOfDay;
        if ((timeOfDayInitial - timeOfDay) == timeInterval && countingDown) // checks if the current time of day minus the initial time is the preset interval
        {
            clockTimeMinutes += 1; // adds to the minutes section
            if (clockTimeMinutes == 6) // if the minutes reaches 6 (60 seconds)
            {
                clockTimeMinutes = 0; // set the minutes to 0
                clockTimeHours += 1; // adds 1 to the hours
            }

            gameObject.GetComponent<TMP_Text>().text = string.Format("{0}:{1}0", clockTimeHours, clockTimeMinutes); // setting the hours and minutes to the current hours and minutes
            timeOfDayInitial = timeOfDay; // resetting the initial time of day

            if (clockTimeHours == 18) // once the clock reaches 18 the countdown stops
            {
                countingDown = false;
            }
        }
    }

    public void RestartClock() // restarting the clock 
    {
        // resetting all variables
        clockTimeHours = clockTimeHoursInitial;
        clockTimeMinutes = clockTimeMinutesInitial;
        gameObject.GetComponent<TMP_Text>().text = string.Format("{0}:{1}0", clockTimeHours, clockTimeMinutes);
        countingDown = true;
        timeOfDay = timeOfDayInitial = timeOfDay = gameManager.GetComponent<GameManager>().timeOfDay;
    }
}
