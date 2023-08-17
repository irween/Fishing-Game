using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishCatchController : MonoBehaviour
{
    public GameObject player;

    public float maxFishCatchCount;
    public float maxFishCatchCountBase;
    public float fishCatchCount;

    public bool isFishCaught = false;

    // Update is called once per frame
    void Update()
    { 
        // get the players fish catch count
        fishCatchCount = player.GetComponent<playerSliderController>().fishCatchCount;
        player.GetComponent<playerSliderController>().maxFishCatchCount = maxFishCatchCount;

        if (fishCatchCount >= maxFishCatchCount & !isFishCaught)
        {
            // print to debug log that the player has caught the fish
            GetComponent<GameManager>().isFishCaught = true;
            Debug.Log("You caught the fish!");
            isFishCaught = true;
        }
    }
}
