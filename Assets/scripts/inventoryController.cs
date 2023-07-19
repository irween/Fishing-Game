using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour
{
    public bool[] hasFish;

    public Sprite[] fishSprites;

    public GameObject[] icons;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // get each inventory slot icon
        icons = GameObject.FindGameObjectsWithTag("inventoryIcon");
        fishSprites = gameManager.GetComponent<GameManager>().fishSprites;
        // for each icon in the icons list, set the hasFish boolean to false
        for (int i = 0; i < icons.Length; i++)
        {
            hasFish[i] = false;
        }
    }

    public void updateInventory(int fishIndex)
    {
        for (int i = 0; i < hasFish.Length; i++)
        {
            if (hasFish[i] == false)
            {
                hasFish[i] = true;
                icons[i].GetComponent<Image>().sprite = fishSprites[fishIndex];
                break;
            }
        }
    }
}
