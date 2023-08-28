using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isFishCaught = false;

    public GameObject playerFishSliders;
    public GameObject playerSlider;
    public GameObject player;
    public GameObject sellObject;
    public GameObject sellMenu;
    public GameObject fishSlider;
    public GameObject fishIcon;
    public GameObject[] icons;
    public GameObject noticeBoard;
    public GameObject catchingFishGame;
    public GameObject startDayButton;
    public GameObject buyMenu;
    public GameObject buyOffers;
    public GameObject sellOffers;
    public GameObject gameOverScreen;
    public TMP_Text scoreText;

    private int iteration;

    public GameObject inventoryObject;
    private bool inventoryBool = false;

    public TMP_Text moneyText;

    public Sprite[] fishSprites;

    public float money;

    public float dayCycleMax;
    public float timeOfDay;
    public float dayCycleInterval;
    public float dayCycleIntervalMax;

    public int fishIndex;

    public float billsCost;
    static int currentDay = 1;

    public GameObject catchingFishTimer;
    private bool catchingFishToggle = false;
    public float catchingFishDelay;
    private float catchingFishTime = 0;

    private bool countingDown = true;

    public IDictionary<int, float> inventory = new Dictionary<int, float>();

    // Start is called before the first frame update
    void Start()
    {
        sellMenu.SetActive(false);
        playerFishSliders.SetActive(false);
        catchingFishTimer.SetActive(false);

        // get each inventory slot icon
        icons = GameObject.FindGameObjectsWithTag("inventoryIcon");
        // for each icon in the icons list, set the hasFish boolean to false
        for (int i = 0; i < icons.Length; i++)
        {
            icons[i].GetComponent<Image>().preserveAspect = true;
            icons[i].SetActive(false);

            inventory.Add(i, 0);
        }

        timeOfDay = dayCycleMax;
        startDayButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryBool = !inventoryBool;
        }

        if (inventoryBool)
        {
            inventoryObject.SetActive(true);
        }
        else
        {
            inventoryObject.SetActive(false);
        }

        moneyText.text = "$" + money;

        if (isFishCaught)
        {
            // print to debug log that the player has caught the fish
            Debug.Log("You caught the fish!");
            isFishCaught = false;
            updateFishInventory(fishIndex);
            // hide the catching fish sliders
            playerFishSliders.SetActive(false);
            resetCatchFish();
        }

        if (timeOfDay <= 0 && countingDown)
        {
            Debug.Log("Day Over");
            countingDown = false;
            endOfDayCycle();
        }

        if (dayCycleInterval <= 0)
        {
            timeOfDay = Mathf.RoundToInt(timeOfDay -= 1);
            dayCycleInterval = dayCycleIntervalMax;
        }

        if (catchingFishToggle)
        {
            if (catchingFishTime >= catchingFishDelay)
            {
                catchingFishGame.SetActive(false);
                catchingFishTimer.SetActive(false);
                catchingFishTime = 0;
                catchingFishTimer.GetComponent<Slider>().value = 0;
                player.GetComponent<playerController>().catchingFish = false;
                catchingFishToggle = false;
            }

            catchingFishTimer.GetComponent<Slider>().value = catchingFishTime / catchingFishDelay;
            catchingFishTime += Time.deltaTime;
        }

        if (countingDown)
        {
            dayCycleInterval -= Time.deltaTime;
        }
    }

    public void catchingFish()
    {
        catchingFishTimer.GetComponent<Slider>().value = 0;
        catchingFishToggle = true;
        catchingFishGame.SetActive(true);
        catchingFishTimer.SetActive(true);
    }

    public void SetMaxFishCatchCount()
    {
        float maxFishCatchCountBase = gameObject.GetComponent<fishCatchController>().maxFishCatchCountBase;
        gameObject.GetComponent<fishCatchController>().maxFishCatchCount = maxFishCatchCountBase + (maxFishCatchCountBase * (fishIndex/2));
    }

    public void updateFishInventory(int fishIndex)
    {
        // iterate through each inventory slot
        for (int i = 0; i < icons.Length; i++)
        {
            // get the inventory slot's image component
            Image iconImage = icons[i].GetComponent<Image>();

            // if the inventory slot is empty
            if (iconImage.sprite == null)
            {
                // set the inventory slot's image to the fish's sprite
                icons[i].SetActive(true);
                iconImage.GetComponent<Image>().sprite = fishSprites[fishIndex];
                iconImage.GetComponent<Image>().preserveAspect = true;
                // add the fish index to the inventory
                inventory[i] = fishIndex;
                // print the inventory dictionary
                foreach (KeyValuePair<int, float> entry in inventory)
                {
                    Debug.Log("Key: " + entry.Key + " Value: " + entry.Value);
                }

                // exit the loop
                break;
            }
        }
    }

    public void removeItemFromInventory(int iconIndex)
    {
        // update the inventory dictionary
        inventory[iconIndex] = 0;
        // update the inventory icon
        icons[iconIndex].GetComponent<Image>().sprite = null;
        icons[iconIndex].SetActive(false);
    }

    public void resetCatchFish()
    {
        // call the resetFish function in the fishSlider script
        fishSlider.GetComponent<fishSlider>().resetSlider();
        playerSlider.GetComponent<playerSliderController>().fishCatchCount = 0;
        playerSlider.GetComponent<Slider>().value = 0;
        player.GetComponent<playerController>().catchingFish = false;
        GetComponent<fishCatchController>().isFishCaught = false;
        catchingFishTimer.GetComponent<Slider>().value = 0;
        catchingFishTime = 0;
        catchingFishToggle = false;
        isFishCaught = false;
        countingDown = true;
    }

    public void triggerSellingEvent(int inventoryIndex)
    {
        sellMenu.SetActive(true);
        Debug.Log(inventoryIndex);
        Debug.Log(inventory[inventoryIndex]);
        sellObject.GetComponent<sellOffers>().SellingFish(inventory[inventoryIndex]);
    }

    public void finishSelling()
    {
        sellMenu.SetActive(false);
    }

    public void endOfDayCycle()
    {
        noticeBoard.GetComponent<noticeBoard>().DisplayWord("End of the Day");
        Debug.Log(billsCost);
        money -= billsCost;
        if (money <= 0)
        {
            Debug.Log("Game Over");
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Game Over");
            gameOverScreen.SetActive(true);
            scoreText.text = currentDay + " Day";
        }

        billsCost = (20 * currentDay * currentDay) + 150;
        currentDay++;

        buyMenu.SetActive(true);
        buyOffers.GetComponent<FishingRodBuy>().catchSpeedCost += 50 * (iteration * iteration) + buyOffers.GetComponent<FishingRodBuy>().catchSpeedCostInitial;
        buyOffers.GetComponent<FishingRodBuy>().hitBoxCost += 50 * (iteration * iteration) + buyOffers.GetComponent<FishingRodBuy>().hitBoxCostInitial;
        buyOffers.GetComponent<FishingRodBuy>().hookSpeedCost += 50 * (iteration * iteration) + buyOffers.GetComponent<FishingRodBuy>().hookSpeedCostInitial;

        iteration++;

        sellOffers.GetComponent<sellOffers>().difficulty += 0.5f;
    }

    public void SetSliderFish(int index)
    {
        fishIndex = index;
        SetMaxFishCatchCount();
        catchingFishGame.SetActive(false);
        catchingFishTimer.SetActive(false);
        playerFishSliders.SetActive(true);
        catchingFishToggle = false;
        catchingFishTimer.GetComponent<Slider>().value = 0;
        catchingFishTime = 0;
    }

    public void StartNextDay()
    {
        timeOfDay = dayCycleMax;
        startDayButton.SetActive(false);
        resetCatchFish();
        for (int i = 0; i < icons.Length; i++)
        {
            removeItemFromInventory(i);
        }
        timeOfDay = dayCycleMax;
        var clockObject = GameObject.FindAnyObjectByType<clockController>();
        clockObject.GetComponent<clockController>().RestartClock();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
