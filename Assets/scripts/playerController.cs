using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the player presses the cast key, the cast animation will play
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Animator>().SetTrigger("casting");
        }
    }

    public void catchFish()
    {
        // print to debug log that the player has caught the fish
        Debug.Log("You caught the fish!");
        // set the isFishCaught variable in the game manager to true
        gameManager.GetComponent<GameManager>().catchingFish();
    }
}
