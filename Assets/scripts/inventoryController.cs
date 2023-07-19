using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour
{
    public IDictionary<int, int> inventory = new Dictionary<int, int>();
    public GameObject[] icons;
    public Sprite[] fishSprites;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // get each inventory slot icon
        icons = GameObject.FindGameObjectsWithTag("inventoryIcon");
        fishSprites = gameManager.GetComponent<GameManager>().fishSprites;
    }

    public void updateInventory(int fishIndex)
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
                iconImage.sprite = fishSprites[fishIndex];

                // add the fish to the inventory
                inventory.Add(i, fishIndex);


                // exit the loop
                break;
            }
        }
    }
}
