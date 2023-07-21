using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSelling : MonoBehaviour
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
        gameManager.GetComponent<GameManager>().triggerSellingEvent(iconIndex);
        gameManager.GetComponent<GameManager>().removeItemFromInventory(iconIndex);
    }
}
