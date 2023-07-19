using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selling : MonoBehaviour
{
    // game objects
    public GameObject gameManager;

    public int iconIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerSellEvent()
    {
        // get the inventory dictionary from the game manager
        IDictionary<int, int> inventory = gameManager.GetComponent<GameManager>().inventory;
        gameManager.GetComponent<GameManager>().removeItemFromInventory(iconIndex);
    }
}
