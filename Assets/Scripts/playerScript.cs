using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour
{
    public Slider fishSlider;
    public Slider playerSlider;

    public float hitbox;

    public float timeInterval;
    public float timeIntervalMax = 2.0f;

    public float fishCatchCount;
    public float maxFishCatchCount;
    public float fishCatchInterval;

    public float speed;

    public float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        timeInterval = timeIntervalMax;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player holds up or down, the playerSlider will move up or down
        if (Input.GetKey(KeyCode.UpArrow))
        {
            playerSlider.value += speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            playerSlider.value -= speed * Time.deltaTime;
        }

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
        else
        {
            fishCatchCount -= fishCatchInterval;
        }

        fishCatchCount = Mathf.Clamp(fishCatchCount, 0, maxFishCatchCount);
    }
}
