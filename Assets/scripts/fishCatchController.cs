using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishCatchController : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;

    public float maxFishCatchCount;

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

        if (fishCatchCount >= maxFishCatchCount)
        {
            // print to debug log that the player has caught the fish
            Debug.Log("You caught the fish!");
            gameManager.GetComponent<GameManager>().isFishCaught = true;
        }
    }
}
