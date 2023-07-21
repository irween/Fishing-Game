using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isFishCaught = false;

    public GameObject catchingFishSliders;
    public GameObject playerSlider;
    public GameObject player;
    public Sprite[] fishSprites;

    public int fishIndex;

    public IDictionary<int, int> inventory = new Dictionary<int, int>();

    public GameObject[] icons;

    public GameObject fishSlider;
    public GameObject fishIcon;

    // Start is called before the first frame update
    void Start()
    {
        catchingFishSliders.SetActive(false);

        // get each inventory slot icon
        icons = GameObject.FindGameObjectsWithTag("inventoryIcon");
        // for each icon in the icons list, set the hasFish boolean to false
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].GetComponent<Image>().preserveAspect = true;
            icons[i].SetActive(false);

            inventory.Add(i, 0);
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
            // hide the catching fish sliders
            catchingFishSliders.SetActive(false);
            resetCatchFish();
        }        
    }

    public void catchingFish()
    {
        // set the catching fish sliders to active
        catchingFishSliders.SetActive(true);
    }

    public void updateFishInventory(int fishIndex)
    {
        // iterate through each inventory slot
        for (int i = 0; i < icons.Length; i++)
        {
            // get the inventory slot's image component
            Image iconImage = icons[i].GetComponent<Image>();

            // if the inventory slot is empty
            if (iconImage.sprite == null)
            {
                // set the inventory slot's image to the fish's sprite
                icons[i].SetActive(true);
                iconImage.GetComponent<Image>().sprite = fishSprites[fishIndex];
                iconImage.GetComponent<Image>().preserveAspect = true;
                // add the fish to the inventory
                inventory[i] = fishIndex;
                // print the inventory dictionary
                foreach (KeyValuePair<int, int> entry in inventory)
                {
                    Debug.Log("Key: " + entry.Key + " Value: " + entry.Value);
                }

                // exit the loop
                break;
            }
        }
    }

    public void removeItemFromInventory(int iconIndex)
    {
        // update the inventory dictionary
        inventory[iconIndex] = 0;
        // update the inventory icon
        icons[iconIndex].GetComponent<Image>().sprite = null;
        icons[iconIndex].SetActive(false);
    }

    public void resetCatchFish()
    {
        // call the resetFish function in the fishVariationController script and the fishSlider script
        fishIcon.GetComponent<fishVariationController>().resetFish();
        fishSlider.GetComponent<fishSlider>().resetSlider();
        playerSlider.GetComponent<playerSliderController>().fishCatchCount = 0;
        playerSlider.GetComponent<Slider>().value = 0;
        player.GetComponent<playerController>().catchingFish = false;
        GetComponent<fishCatchController>().isFishCaught = false;
        isFishCaught = false;
    }
}
