using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryController : MonoBehaviour
{
    public bool[] hasFish;
    public GameObject[] slots;

    // Start is called before the first frame update
    void Start()
    {
        // get each inventory slot icon
        slots = GameObject.FindGameObjectsWithTag("inventoryIcon");
    }

    public void updateInventory(int fishIndex)
    {
        // set the inventory slot icon to active
        slots[fishIndex].SetActive(true);
    }
}
