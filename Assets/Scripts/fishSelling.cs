using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSelling : MonoBehaviour
{
    // game objects
    public GameObject gameManager;

    public int iconIndex;

    public void triggerSellEvent()
    {
        gameManager.GetComponent<GameManager>().triggerSellingEvent(iconIndex);
        gameManager.GetComponent<GameManager>().removeItemFromInventory(iconIndex);
    }
}
