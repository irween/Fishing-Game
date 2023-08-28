using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishCatchController : MonoBehaviour
{
    public GameObject player; // player object

    public float maxFishCatchCount; // maximum amount that the fish count can be (the amount of "time" that passes for a fish to be caught)
    public float maxFishCatchCountBase; // the base amount for the fish count
    public float fishCatchCount; // current fish count

    public bool isFishCaught = false; // boolean for if the fish is caught

    // Update is called once per frame
    void Update()
    { 
        // get the players fish catch counts
        fishCatchCount = player.GetComponent<playerSliderController>().fishCatchCount;
        player.GetComponent<playerSliderController>().maxFishCatchCount = maxFishCatchCount;

        if (fishCatchCount >= maxFishCatchCount & !isFishCaught) // checks if the fish count matches the max amount and if the fish is not currently caught
        {
            
            GetComponent<GameManager>().isFishCaught = true; // setting the gamemanager bool to true
            Debug.Log("You caught the fish!"); // print to debug log that the player has caught the fish
            isFishCaught = true; // setting the caught fish bool to true
        }
    }
}
