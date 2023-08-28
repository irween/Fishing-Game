using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishingRodBuy : MonoBehaviour
{
    // text variables
    public TMP_Text[] buyButtonText; // text as a list for each button
    public TMP_Text moneyText;

    // gameobject variables
    public GameObject gameManager;
    public GameObject player;
    public GameObject playerHook;
    public GameObject buyMenu;

    // base upgrade costs
    public float catchSpeedCostInitial;
    public float hitBoxCostInitial;
    public float hookSpeedCostInitial;

    // upgrade costs (changes as the game continues)
    public float catchSpeedCost;
    public float hitBoxCost;
    public float hookSpeedCost;

    private void Update()
    {
        // setting the button text to the matching cost
        for (int i = 0; i < buyButtonText.Length; i++)
        {
            if (i == 0)
            {
                buyButtonText[i].text = "$" + catchSpeedCost;
            }

            if (i == 1)
            {
                buyButtonText[i].text = "$" + hitBoxCost;
            }

            if (i == 2)
            {
                buyButtonText[i].text = "$" + hookSpeedCost;
            }
        }
    }

    // function that controls which button gets triggered (the int parameter is used to tell which button is pressed
    public void BuyButton(int buttonIndex)
    {

        if (buttonIndex == 0) // increase catch speed (+5%)
        {
            gameManager.GetComponent<GameManager>().money -= catchSpeedCost; // removes the cost from the money
            player.GetComponent<playerSliderController>().timeIntervalMax -= player.GetComponent<playerSliderController>().timeIntervalMax * 0.05f;
            StartDay(); // restarts the day
        }
        else if (gameManager.GetComponent<GameManager>().money <= gameManager.GetComponent<GameManager>().money - catchSpeedCost) // checks if the player has enough money (then displays a warning message)
        {
            FindAnyObjectByType<noticeBoard>().GetComponent<noticeBoard>().DisplayWord("Not Enough Money");
        }

        if (buttonIndex == 1) // increase hit box (+2%)
        {
            gameManager.GetComponent<GameManager>().money -= hitBoxCost; // removes the cost from the money
            player.GetComponent<playerSliderController>().hitbox += player.GetComponent<playerSliderController>().hitbox * 0.05f;
            StartDay(); // restarts the day 
        }
        else if (gameManager.GetComponent<GameManager>().money <= gameManager.GetComponent<GameManager>().money - hitBoxCost) // checks if the player has enough money (then displays a warning message)
        {
            FindAnyObjectByType<noticeBoard>().GetComponent<noticeBoard>().DisplayWord("Not Enough Money");
        }

        if (buttonIndex == 2) // increase hook speed (+7%)
        {
            gameManager.GetComponent<GameManager>().money -= hookSpeedCost; // removes the cost from the money
            playerHook.GetComponent<playerHookController>().speed += playerHook.GetComponent<playerHookController>().speed * 0.07f;
            StartDay(); // restarts the day
        }
        else if (gameManager.GetComponent<GameManager>().money <= gameManager.GetComponent<GameManager>().money - hookSpeedCost) // checks if the player has enough money (then displays a warning message)
        {
            FindAnyObjectByType<noticeBoard>().GetComponent<noticeBoard>().DisplayWord("Not Enough Money");
        }

    }

    // restarts the day
    private void StartDay()
    {
        buyMenu.SetActive(false);
        gameManager.GetComponent<GameManager>().StartNextDay();
    }

    // if the player selects no upgrade (due to not enough money)
    public void NoUpgrade()
    {
        gameManager.GetComponent<GameManager>().StartNextDay(); // restarts the day
        buyMenu.SetActive(false);
    }
}
