using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sellOffers : MonoBehaviour
{
    // first slot (0) is the first offer (lowest offer) - lowest risk (90% chance)
    // second slot (1) is the second offer (medium offer) - medium risk (70% chance)
    // third slot (2) is the third offer (high offer) - highest risk (50% chance)
    public TMP_Text[] sellButtonText;
    public TMP_Text moneyText;

    public GameObject noticeBoard;

    public GameObject gameManager;

    public List<float> offers = new List<float>();

    public float lowOfferRisk;
    public float mediumOfferRisk;
    public float highOfferRisk;

    private int lowOfferIndex = 0;
    private int medOfferIndex = 1;
    private int highOfferIndex = 2;

    public float minLowOffer;
    public float maxLowOffer;

    public float minMedOffer;
    public float maxMedOffer;

    public float minHighOffer;
    public float maxHighOffer;

    public float cost;
    public float newMoney;

    private void Start()
    {
        moneyText.text = "$0";
    }

    public void SellingFish(float fishQuality)
    {
        foreach (TMP_Text textObject in sellButtonText)
        {
            int textObjectIndex = System.Array.IndexOf(sellButtonText, textObject);
            if (textObjectIndex == lowOfferIndex)
            {
                cost = Random.Range(minLowOffer, maxLowOffer);
            }

            else if (textObjectIndex == medOfferIndex)
            {
                cost = Random.Range(minMedOffer, maxMedOffer);
            }

            else if (textObjectIndex == highOfferIndex)
            {
                cost = Random.Range(minHighOffer, maxHighOffer);
            }

            cost = Mathf.Round(cost);

            Debug.Log(cost);
            cost = cost * fishQuality;
            offers.Add(cost);
            textObject.text = "$" + cost;
        }
    }

    public void SellButton(int buttonIndex)
    {
        Debug.Log(buttonIndex);

        float currentMoney = gameManager.GetComponent<GameManager>().money;

        float offerRandomNumber = Random.Range(1, 100);

        if (buttonIndex == lowOfferIndex & offerRandomNumber <= lowOfferRisk)
        {
            Debug.Log(lowOfferIndex);
            newMoney = currentMoney + offers[lowOfferIndex];
            moneyText.text = "$" + newMoney;
            noticeBoard.SetActive(true);
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Successful");
        }

        if (buttonIndex == medOfferIndex & offerRandomNumber <= mediumOfferRisk)
        {
            Debug.Log(medOfferIndex);
            newMoney = currentMoney + offers[medOfferIndex];
            moneyText.text = "$" + newMoney;
            noticeBoard.SetActive(true);
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Successful");
        }

        if (buttonIndex == highOfferIndex& offerRandomNumber <= highOfferRisk)
        {
            Debug.Log(highOfferIndex);
            newMoney = currentMoney + offers[highOfferIndex];
            moneyText.text = "$" + newMoney;
            noticeBoard.SetActive(true);
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Successful");
        }

        else if (offerRandomNumber <= lowOfferRisk | offerRandomNumber <= highOfferRisk | offerRandomNumber <= mediumOfferRisk)
        {
            noticeBoard.SetActive(true);
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Failed");
            noticeBoard.GetComponent<Animator>().Play("On");
        }

        offers.Clear();
        gameManager.GetComponent<GameManager>().money = newMoney;
        gameManager.GetComponent<GameManager>().finishSelling();
        
    }
}
