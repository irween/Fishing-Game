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
    public TMP_Text[] textmeshpro;

    public float lowOfferRisk;
    public float mediumOfferRisk;
    public float highOfferRisk;

    private int lowOfferIndex = 0;
    private int mediumOfferIndex = 1;
    private int highOfferIndex = 2;

    public float minLowOffer;
    public float maxLowOffer;

    public float minMedOffer;
    public float maxMedOffer;

    public float minHighOffer;
    public float maxHighOffer;

    public float cost;

    public float fishQuality;

    public void SellingFish()
    {
        for (int i = 0; i < textmeshpro.Length; i++)
        {
            if (System.Array.IndexOf(textmeshpro, i) == lowOfferIndex)
            {
                cost = Random.Range(minLowOffer, maxLowOffer);
            }

            if (System.Array.IndexOf(textmeshpro, i) == mediumOfferIndex)
            {
                cost = Random.Range(minMedOffer, maxMedOffer);
            }

            if (System.Array.IndexOf(textmeshpro, i) == highOfferIndex)
            {
                cost = Random.Range(minHighOffer, maxHighOffer);
            }

            textmeshpro[i].text = "$" + cost * fishQuality;
        }
    }
}
