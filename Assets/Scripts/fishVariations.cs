using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fishVariations : MonoBehaviour
{
    public GameObject fish;

    public int fishTypesMax;
    public int fishType;

    public float difficulty;

    public Sprite fishsprite;

    // Start is called before the first frame update
    void Start()
    {
        // set the fish sprite to a random fish variation
        fishType = Random.Range(1, fishTypesMax + 1);
        fish.GetComponent<Image>().sprite = Resources.Load<Sprite>("FishAssets/fish" + fishType);
        fishsprite = fish.GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
