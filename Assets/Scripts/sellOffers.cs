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

    // gameobject variables
    public GameObject noticeBoard;
    public GameObject gameManager;

    // offers list
    public List<float> offers = new List<float>();

    // chance of succeding an offer
    public float lowOfferRisk;
    public float mediumOfferRisk;
    public float highOfferRisk;

    // button indexs
    private int lowOfferIndex = 0;
    private int medOfferIndex = 1;
    private int highOfferIndex = 2;

    // range of min/max offer for each difficulty
    public float minLowOffer;
    public float maxLowOffer;

    public float minMedOffer;
    public float maxMedOffer;

    public float minHighOffer;
    public float maxHighOffer;

    public float cost; // the amount the fish can sell for
    public float newMoney; // the players money after selling

    public float difficulty = 1;

    private void Start()
    {
        moneyText.text = "$0"; // set money text to $0
    }

    // start selling fish based on the quality (higher quality means higher offers)
    public void SellingFish(float fishQuality)
    {
        // for each text object set a random cost for each offer type (low med high)
        foreach (TMP_Text textObject in sellButtonText)
        {
            int textObjectIndex = System.Array.IndexOf(sellButtonText, textObject);
            if (textObjectIndex == lowOfferIndex) // if the text object equals the low offer index
            {
                cost = Random.Range(minLowOffer, maxLowOffer) * difficulty;
            }

            else if (textObjectIndex == medOfferIndex) // if the text object equals the medium offer index
            {
                cost = Random.Range(minMedOffer, maxMedOffer) * difficulty;
            }

            else if (textObjectIndex == highOfferIndex) // if the text object equals the high offer index
            {
                cost = Random.Range(minHighOffer, maxHighOffer) * difficulty;
            }

            cost = Mathf.Round(cost); // round the cost

            Debug.Log(cost);
            if (fishQuality == 0) // if the index (quality) of the fish is 0 (lowest fish type) add 0.5
            {
                fishQuality += 0.5f;
            }
            cost = cost * fishQuality; // multiply the cost by the fish quality to get new cost amount based on fish quality
            offers.Add(cost); // add that cost to the offers list (first will be low, then medium, etc)
            textObject.text = "$" + cost; // show the cost on the button text
        }
    }

    // sells based on which button (offer type. I.e low, med, high) is pressed
    public void SellButton(int buttonIndex)
    {
        Debug.Log(buttonIndex);

        float currentMoney = gameManager.GetComponent<GameManager>().money; // gets the current money

        float offerRandomNumber = Random.Range(1, 100); // gets a random number to be used to see if the player got the offer

        if (buttonIndex == lowOfferIndex & offerRandomNumber <= lowOfferRisk) // checks if the player got the offer and they pressed the corresponding number
        {
            Debug.Log(lowOfferIndex);
            newMoney = currentMoney + offers[lowOfferIndex]; // adds the offer money to the players current money
            moneyText.text = "$" + newMoney; // displays the new money on the display
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Successful"); // notifies the player that they got the offer
        }
        // if the corresponding offer failed notifies the player they failed the offer
        else if (offerRandomNumber >= lowOfferRisk & buttonIndex == lowOfferIndex)
        {
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Failed");
        }

        if (buttonIndex == medOfferIndex & offerRandomNumber <= mediumOfferRisk) // checks if the player got the offer and they pressed the corresponding number
        {
            Debug.Log(medOfferIndex);
            newMoney = currentMoney + offers[medOfferIndex]; // adds the offer money to the players current money
            moneyText.text = "$" + newMoney; // displays the new money on the display
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Successful"); // notifies the player that they got the offer
        }
        // if the corresponding offer failed notifies the player they failed the offer
        else if (offerRandomNumber >= mediumOfferRisk & buttonIndex == medOfferIndex)
        {
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Failed");
        }

        if (buttonIndex == highOfferIndex & offerRandomNumber <= highOfferRisk) // checks if the player got the offer and they pressed the corresponding number
        {
            Debug.Log(highOfferIndex);
            newMoney = currentMoney + offers[highOfferIndex]; // adds the offer money to the players current money
            moneyText.text = "$" + newMoney; // displays the new money on the display
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Successful"); // notifies the player that they got the offer
        }
        // if the corresponding offer failed notifies the player they failed the offer
        else if (offerRandomNumber >= highOfferRisk & buttonIndex == highOfferIndex)
        {
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Offer Failed");
        }

        offers.Clear(); // clear the offers
        gameManager.GetComponent<GameManager>().money = newMoney; // set the money to the new money amount
        gameManager.GetComponent<GameManager>().finishSelling(); // stop selling
        
    }
}
