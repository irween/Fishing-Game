using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerSliderController : MonoBehaviour
{
    // declaring slider variables
    public Slider fishSlider;
    public Slider playerSlider;

     // declaring hitbox variable
    public float hitbox;

    // declaring time interval variables
    public float timeInterval;
    public float timeIntervalMax = 2.0f;

    // declaring fish catch variables
    public float fishCatchCount;
    public float maxFishCatchCount;
    public float fishCatchInterval;

    // declaring speed variable
    public float speed;
    public float gravity;

    // declaring difficulty variable
    public float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        timeInterval = timeIntervalMax;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player holds the up or down arrow key, the playerSlider will move up or down
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
            //playerSlider.value += speed * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
            //playerSlider.value -= speed * Time.deltaTime;
        //}

        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerSlider.value += speed * Time.deltaTime;
        }

        playerSlider.value -= gravity * Time.deltaTime;

        // if the player slider position is equal to the fish slider position, the fish catch count will increase
        if ((fishSlider.value >= playerSlider.value - hitbox) && (fishSlider.value <= playerSlider.value + hitbox))
        {
            if (timeInterval >= 0)
            {
                timeInterval -= Time.deltaTime;
                fishCatchCount += fishCatchInterval;
            }
            else
            {
                timeInterval = timeIntervalMax;
            }
        }
        // decreases the fish catch count if the player slider position is not equal to the fish slider position
        else
        {
            fishCatchCount -= fishCatchInterval;
        }

        // clamps the fish count to the max fish count
        fishCatchCount = Mathf.Clamp(fishCatchCount, 0, maxFishCatchCount);
    }
}
