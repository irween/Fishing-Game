using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishSlider : MonoBehaviour
{
    public Slider slider;

    private float speed;
    public float speedMax;
    public float speedMin;

    public float difficulty = 1.0f;

    public float timeInterval;
    public float timeIntervalMax = 2.0f;

    public float maxRandHeight;
    public float minRandHeight;

    public bool flipMovement;

    public GameObject gameManager;

    public GameObject fishSprite;

    void Start()
    {
        maxRandHeight = Mathf.Round(Random.Range(0.5f, 1) * 100) * 0.01f;
        minRandHeight = Mathf.Round(Random.Range(0, 0.5f) * 100) * 0.01f;

        timeInterval = timeIntervalMax;

        slider.value = Random.Range(0, 1);

        speed = 1;

    }

    public void resetSlider()
    {
        slider.value = 0.5f;
        maxRandHeight = Mathf.Round(Random.Range(0.5f, 1) * 100) * 0.01f;
        minRandHeight = Mathf.Round(Random.Range(0, 0.5f) * 100) * 0.01f;

        timeInterval = timeIntervalMax;
    }

    void Update()
    {
        fishSprite.GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().fishSprites[gameManager.GetComponent<GameManager>().fishIndex];

        if (slider.value == maxRandHeight || slider.value == minRandHeight)
        {
            flipMovement = !flipMovement;
            maxRandHeight = Mathf.Round(Random.Range(slider.value, 1) * 100) * 0.01f;
            minRandHeight = Mathf.Round(Random.Range(0, slider.value) * 100) * 0.01f;
        }

        if (flipMovement)
        {
            slider.value += speed * Time.deltaTime * difficulty + 0.05f * Time.deltaTime;
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
            speed = Random.Range(speedMin, speedMax);
            timeInterval = timeIntervalMax;
        }

        slider.value = Mathf.Clamp(slider.value, minRandHeight, maxRandHeight);
    }
}
