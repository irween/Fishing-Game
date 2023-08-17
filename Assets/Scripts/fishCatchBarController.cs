using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishCatchBarController : MonoBehaviour
{
    public GameObject fishCatchController;

    private float fishCatchCountMax;
    private float fishCatchCount;
    public float fishCountPercentage;

    private Slider fishCatchSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        fishCatchSlider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        fishCatchCountMax = fishCatchController.GetComponent<fishCatchController>().maxFishCatchCount;
        fishCatchCount = fishCatchController.GetComponent<fishCatchController>().fishCatchCount;
        fishCountPercentage = fishCatchCount / fishCatchCountMax;
        fishCatchSlider.value = fishCountPercentage;
    }
}
