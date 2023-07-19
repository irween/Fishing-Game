using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isFishCaught = false;

    public GameObject catchingFishSliders;

    public Sprite[] fishSprites;

    public int fishIndex;

    public bool[] hasFish;

    public GameObject[] icons;

    public int[] caughtFish;

    // Start is called before the first frame update
    void Start()
    {
        catchingFishSliders.SetActive(false);

        // get each inventory slot icon
        icons = GameObject.FindGameObjectsWithTag("inventoryIcon");
        // for each icon in the icons list, set the hasFish boolean to false
        for (int i = 0; i < icons.Length; i++)
        {
            hasFish[i] = false;
            icons[i].GetComponent<Image>().preserveAspect = true;
            icons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFishCaught == true)
        {
            // print to debug log that the player has caught the fish
            Debug.Log("You caught the fish!");
            isFishCaught = false;
            updateFishInventory(fishIndex);
        }        
    }

    public void catchingFish()
    {
        // set the catching fish sliders to active
        catchingFishSliders.SetActive(true);
    }

    public void updateFishInventory(int fishIndex)
    {
        for (int i = 0; i < hasFish.Length; i++)
        {
            if (hasFish[i] == false)
            {
                hasFish[i] = true;
                icons[i].SetActive(true);
                icons[i].GetComponent<Image>().sprite = fishSprites[fishIndex];
                icons[i].GetComponent<Image>().preserveAspect = true;
                caughtFish[i] = fishIndex;
                break;
            }
        }
    }
}
