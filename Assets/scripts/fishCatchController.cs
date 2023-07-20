using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishCatchController : MonoBehaviour
{
    public GameObject player;

    public float maxFishCatchCount;

    public bool isFishCaught = false;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<playerSliderController>().maxFishCatchCount = maxFishCatchCount;
    }

    // Update is called once per frame
    void Update()
    { 
        // get the players fish catch count
        float fishCatchCount = player.GetComponent<playerSliderController>().fishCatchCount;

        if (fishCatchCount >= maxFishCatchCount & !isFishCaught)
        {
            // print to debug log that the player has caught the fish
            GetComponent<GameManager>().isFishCaught = true;
            Debug.Log("You caught the fish!");
            isFishCaught = true;
        }
    }
}
