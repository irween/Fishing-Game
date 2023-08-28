using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSelling : MonoBehaviour
{
    // game objects
    public GameObject gameManager;

    public int iconIndex; // index of icon

    public void triggerSellEvent() // when the offer buton is pressed trigger the selling events
    {
        gameManager.GetComponent<GameManager>().triggerSellingEvent(iconIndex);
        gameManager.GetComponent<GameManager>().removeItemFromInventory(iconIndex);
    }
}
