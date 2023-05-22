using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishSlider : MonoBehaviour
{
    public Slider slider;

    public float speed = 1.0f;
    public float difficulty = 1.0f;

    public float timeInterval;
    public float timeIntervalMax = 2.0f;

    public float maxRandHeight;
    public float minRandHeight;

    public bool flipMovement;  

    void Start()
    {
        maxRandHeight = Mathf.Round(Random.Range(0.5f, 1) * 100) * 0.01f;
        minRandHeight = Mathf.Round(Random.Range(0, 0.5f) * 100) * 0.01f;
        
        difficulty = (float)GameObject.Find("fish").GetComponent<fishVariations>().fishType * 0.5f;

        timeInterval = timeIntervalMax;
    }
    
    void Update()
    {
        if (slider.value == maxRandHeight || slider.value == minRandHeight)
        {
            flipMovement = !flipMovement;
            maxRandHeight = Mathf.Round(Random.Range(slider.value, 1) * 100) * 0.01f;
            minRandHeight = Mathf.Round(Random.Range(0, slider.value) * 100) * 0.01f;
        }

        if (flipMovement)
        {
            slider.value += speed * Time.deltaTime * difficulty;
        }
        else
        {
            slider.value -= speed * Time.deltaTime * difficulty;
        }

        if (timeInterval >= 0)
        {
            timeInterval -= Time.deltaTime;
        }
        else
        {
            speed = Random.Range(0.5f, 1);
            timeInterval = timeIntervalMax;
        }

        slider.value = Mathf.Clamp(slider.value, minRandHeight, maxRandHeight);
    }
}
