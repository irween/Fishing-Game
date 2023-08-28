using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishSlider : MonoBehaviour
{
    // slider variable
    public Slider slider;

    // speed variables
    private float speed;
    public float speedMax; // max speed the fish can move
    public float speedMin; // min speed the fish can move

    public float difficulty = 1.0f; // difficulty of the fish

    // delay/timer variables
    public float timeInterval;
    public float timeIntervalMax = 2.0f; // interval between movement changes

    // maximum and minimum random heights of the slider
    public float maxRandHeight;
    public float minRandHeight;

    // bool that flips the movement of the fish (up/down)
    public bool flipMovement;

    // gameobject variables
    public GameObject gameManager;
    public GameObject fishSprite;

    void Start()
    {
        // getting a random max/min height
        maxRandHeight = Mathf.Round(Random.Range(0.5f, 1) * 100) * 0.01f;
        minRandHeight = Mathf.Round(Random.Range(0, 0.5f) * 100) * 0.01f;

        // setting the timer
        timeInterval = timeIntervalMax;

        // setting the start position of the fish
        slider.value = Random.Range(0, 1);

        speed = 1;

    }

    // function that resets all the variables
    public void resetSlider()
    {
        slider.value = Random.Range(0, 1);
        maxRandHeight = Mathf.Round(Random.Range(0.5f, 1) * 100) * 0.01f;
        minRandHeight = Mathf.Round(Random.Range(0, 0.5f) * 100) * 0.01f;

        timeInterval = timeIntervalMax;
    }

    void Update()
    {
        fishSprite.GetComponent<Image>().sprite = gameManager.GetComponent<GameManager>().fishSprites[gameManager.GetComponent<GameManager>().fishIndex];

        // checking if the slider value has reached the max or min height, then getting new heights and flipping the movement
        if (slider.value == maxRandHeight || slider.value == minRandHeight)
        {
            flipMovement = !flipMovement;
            maxRandHeight = Mathf.Round(Random.Range(slider.value, 1) * 100) * 0.01f;
            minRandHeight = Mathf.Round(Random.Range(0, slider.value) * 100) * 0.01f;
        }

        // inverses the movement based on if the boolean is true or false
        if (flipMovement)
        {
            slider.value += speed * Time.deltaTime * difficulty; // moving the slider
        }
        else
        {
            slider.value -= speed * Time.deltaTime * difficulty; // moving the slider
        }

        // once the timer runs out sets a random speed
        if (timeInterval >= 0)
        {
            timeInterval -= Time.deltaTime; // ticking the timer down
        }
        else
        {
            speed = Random.Range(speedMin, speedMax); // getting random speed
            timeInterval = timeIntervalMax;
        }

        slider.value = Mathf.Clamp(slider.value, minRandHeight, maxRandHeight); // clamping the slider value to the maximum/minimum random heights
    }
}
