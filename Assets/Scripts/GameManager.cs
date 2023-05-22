using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public float fishCatchCount;
    public float maxFishCatchCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fishCatchCount = player.GetComponent<playerScript>().fishCatchCount;
        maxFishCatchCount = player.GetComponent<playerScript>().maxFishCatchCount;

        if (fishCatchCount == maxFishCatchCount)
        {

        }
    }
}
