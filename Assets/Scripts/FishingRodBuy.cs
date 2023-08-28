using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishingRodBuy : MonoBehaviour
{
    public TMP_Text[] buyButtonText;
    public TMP_Text moneyText;

    public GameObject gameManager;
    public GameObject player;
    public GameObject playerHook;
    public GameObject buyMenu;

    public float catchSpeedCostInitial;
    public float hitBoxCostInitial;
    public float hookSpeedCostInitial;

    public float catchSpeedCost;
    public float hitBoxCost;
    public float hookSpeedCost;

    private void Update()
    {
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

    public void BuyButton(int buttonIndex)
    {

        if (buttonIndex == 0) // increase catch speed (+5%)
        {
            gameManager.GetComponent<GameManager>().money -= catchSpeedCost;
            player.GetComponent<playerSliderController>().timeIntervalMax -= player.GetComponent<playerSliderController>().timeIntervalMax * 0.05f;
            StartDay();
        }
        else if (gameManager.GetComponent<GameManager>().money <= gameManager.GetComponent<GameManager>().money - catchSpeedCost)
        {
            FindAnyObjectByType<noticeBoard>().GetComponent<noticeBoard>().DisplayWord("Not Enough Money");
        }

        if (buttonIndex == 1) // increase hit box (+2%)
        {
            gameManager.GetComponent<GameManager>().money -= hitBoxCost;
            player.GetComponent<playerSliderController>().hitbox += player.GetComponent<playerSliderController>().hitbox * 0.05f;
            StartDay();
        }
        else if (gameManager.GetComponent<GameManager>().money <= gameManager.GetComponent<GameManager>().money - hitBoxCost)
        {
            FindAnyObjectByType<noticeBoard>().GetComponent<noticeBoard>().DisplayWord("Not Enough Money");
        }

        if (buttonIndex == 2) // increase hook speed (+7%)
        {
            gameManager.GetComponent<GameManager>().money -= hookSpeedCost;
            playerHook.GetComponent<playerHookController>().speed += playerHook.GetComponent<playerHookController>().speed * 0.07f;
            StartDay();
        }
        else if (gameManager.GetComponent<GameManager>().money <= gameManager.GetComponent<GameManager>().money - hookSpeedCost)
        {
            FindAnyObjectByType<noticeBoard>().GetComponent<noticeBoard>().DisplayWord("Not Enough Money");
        }

    }

    private void StartDay()
    {
        buyMenu.SetActive(false);
        gameManager.GetComponent<GameManager>().StartNextDay();
    }

    public void NoUpgrade()
    {
        gameManager.GetComponent<GameManager>().StartNextDay();
        buyMenu.SetActive(false);
    }
}
