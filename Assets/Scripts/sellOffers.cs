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
        if (buttonIndex == lowOfferIndex)
        {
            Debug.Log(buttonIndex);

            if (Random.Range(1, 100) <= lowOfferRisk & buttonIndex == lowOfferIndex)
            {
                Debug.Log(lowOfferIndex);
                moneyText.text = "$" + offers[lowOfferIndex].ToString();
            }

            else if (Random.Range(1, 100) <= mediumOfferRisk & buttonIndex == medOfferIndex)
            {
                Debug.Log(medOfferIndex);

                moneyText.text = "$" + offers[medOfferIndex].ToString();
            }

            else if (Random.Range(1, 100) <= highOfferRisk & buttonIndex == highOfferIndex)
            {
                Debug.Log(highOfferIndex);

                moneyText.text = "$" + offers[highOfferIndex].ToString();
            }
        }

        if (moneyText.text != "$0")
        {
            offers.Clear();
            gameManager.GetComponent<GameManager>().finishSelling();
        }
    }
}
