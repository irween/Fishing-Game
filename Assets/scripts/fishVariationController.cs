using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class fishVariationController : MonoBehaviour
{
    // declaring fish variables
    public GameObject fish;

    public int fishTypesMax;

    public Sprite[] fishSprites;

    public GameObject gameManager;

    public int fishIndex;

    // Start is called before the first frame update
    void Awake()
    {
        // set fish type max to the length of the array
        fishSprites = gameManager.GetComponent<GameManager>().fishSprites;
        fishTypesMax = fishSprites.Length;
        // select random sprite from fishSprites array
        fishIndex = Random.Range(0, fishTypesMax);
        fish.GetComponent<Image>().sprite = fishSprites[fishIndex];
        gameManager.GetComponent<GameManager>().fishIndex = fishIndex;

        gameManager.GetComponent<GameManager>().SetMaxFishCatchCount();
    }

    public void resetFish()
    {
        // select random sprite from fishSprites array
        fishIndex = Random.Range(0, fishTypesMax);
        fish.GetComponent<Image>().sprite = fishSprites[fishIndex];
        gameManager.GetComponent<GameManager>().fishIndex = fishIndex;
        gameManager.GetComponent<GameManager>().SetMaxFishCatchCount();
    }
}
