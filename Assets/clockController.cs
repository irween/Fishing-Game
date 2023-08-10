using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class clockController : MonoBehaviour
{
    public GameObject gameManager;
    private float timeOfDay;
    private float timeOfDayInitial;

    public float timeInterval;

    void Start()
    {
        timeOfDayInitial = gameManager.GetComponent<GameManager>().timeOfDay;
        gameObject.GetComponent<TMP_Text>().text = timeOfDayInitial.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay = gameManager.GetComponent<GameManager>().timeOfDay;
        if ((timeOfDayInitial - timeOfDay) == timeInterval)
        {
            gameObject.GetComponent<TMP_Text>().text = timeOfDay.ToString();
            timeOfDayInitial = timeOfDay;
        }
    }
}
