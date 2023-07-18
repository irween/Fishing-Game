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

    // Start is called before the first frame update
    void Start()
    {
        // set fish type max to the length of the array
        fishTypesMax = fishSprites.Length;
        // select random sprite from fishSprites array
        fish.GetComponent<Image>().sprite = fishSprites[Random.Range(0, fishTypesMax)];
    }
}
