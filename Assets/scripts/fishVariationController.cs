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
    public int fishType;

    public Sprite[] fishSprites;

    // Start is called before the first frame update
    void Start()
    {
        // select random sprite from fishSprites array
        fish.GetComponent<Image>().sprite = fishSprites[Random.Range(0, fishSprites.Length)];
    }
}
