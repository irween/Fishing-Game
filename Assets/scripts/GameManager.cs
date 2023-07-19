using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isFishCaught = false;

    public GameObject catchingFishSliders;

    // Start is called before the first frame update
    void Start()
    {
        catchingFishSliders.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isFishCaught)
        {

        }
    }

    public void catchingFish()
    {
        // set the catching fish sliders to active
        catchingFishSliders.SetActive(true);
    }
}
