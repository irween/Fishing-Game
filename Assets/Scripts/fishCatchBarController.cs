using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishCatchBarController : MonoBehaviour
{
    public GameObject fishCatchController;

    private float fishCatchCountMax; // maximum amount that the fish count can be (the amount of "time" that passes for a fish to be caught)
    private float fishCatchCount; // current fish count
    public float fishCountPercentage; // the percentage that the fish has been caught (for the fish catch slider)

    private Slider fishCatchSlider; // fish catch slider
    
    // Start is called before the first frame update
    void Start()
    {
        fishCatchSlider = gameObject.GetComponent<Slider>(); // getting the slider component
    }

    // Update is called once per frame
    void Update()
    {
        fishCatchCountMax = fishCatchController.GetComponent<fishCatchController>().maxFishCatchCount; // getting the max count from game manager
        fishCatchCount = fishCatchController.GetComponent<fishCatchController>().fishCatchCount; // getting the current count from the game manager
        fishCountPercentage = fishCatchCount / fishCatchCountMax; // getting the percentage for the fish catch slider
        fishCatchSlider.value = fishCountPercentage; // setting the slider
    }
}
