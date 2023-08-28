using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isFishCaught = false;

    // gameobject variables
    public GameObject playerFishSliders;
    public GameObject playerSlider;
    public GameObject player;
    public GameObject sellObject;
    public GameObject sellMenu;
    public GameObject fishSlider;
    public GameObject fishIcon;
    public GameObject[] icons; // list of inventory icons
    public GameObject noticeBoard;
    public GameObject catchingFishGame;
    public GameObject buyMenu;
    public GameObject buyOffers;
    public GameObject sellOffers;
    public GameObject gameOverScreen;
    public TMP_Text scoreText;

    private int iteration; // current iteration of the game

    // inventory object
    public GameObject inventoryObject;
    private bool inventoryBool = false; // controls if the inventory is enabled or disabled

    public TMP_Text moneyText;

    public Sprite[] fishSprites; // list of fish sprites

    public float money; // current money the player has

    public float dayCycleMax; // maximum time of day (the time the day starts at)
    public float timeOfDay; // the current time of day
    public float dayCycleInterval; // the time interval for the day timer
    public float dayCycleIntervalMax; // the max time interval for the day timer

    public int fishIndex; // current fish index

    public float billsCost; // total cost of bills
    private int currentDay = 1; // current in game day

    public GameObject catchingFishTimer; // timer object
    private bool catchingFishToggle = false; // toggle for catching fish
    public float catchingFishDelay; // delay to stop catching fish
    private float catchingFishTime = 0; // time taken

    private bool countingDown = true; // counting down bool that stops counting the day cycle down

    public IDictionary<int, float> inventory = new Dictionary<int, float>(); // inventory dictionary (inventory slot, fish index)

    // Start is called before the first frame update
    void Start()
    {
        // setting corresponding menus/games to off
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

        // set the time of day to the max time
        timeOfDay = dayCycleMax;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player presses the I key, turn on/off the inventory
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

        moneyText.text = "$" + money; // sets the money text to the money float

        if (isFishCaught) // checks if the fish is caught
        {
            // print to debug log that the player has caught the fish
            Debug.Log("You caught the fish!");
            isFishCaught = false;
            updateFishInventory(fishIndex); // updates the fish inventory with the current fish index
            // hide the catching fish sliders
            playerFishSliders.SetActive(false);
            resetCatchFish(); // reset the game
        }

        if (timeOfDay <= 0 && countingDown) // checking if the time of day is 0 and counting down is true
        {
            Debug.Log("Day Over"); // debug log for day over
            countingDown = false;
            endOfDayCycle(); // function for the end of the day
        }

        if (dayCycleInterval <= 0) // counting down the time
        {
            timeOfDay = Mathf.RoundToInt(timeOfDay -= 1); // rounding the time of day for the clock
            dayCycleInterval = dayCycleIntervalMax; // setting the interval back to the max
        }

        if (catchingFishToggle) // checking if the catching fish game is enabled
        {
            if (catchingFishTime >= catchingFishDelay) // if the delay has been met turn off the game
            {
                // setting the variables to their "off" state
                catchingFishGame.SetActive(false);
                catchingFishTimer.SetActive(false);
                catchingFishTime = 0;
                catchingFishTimer.GetComponent<Slider>().value = 0;
                player.GetComponent<playerController>().catchingFish = false;
                catchingFishToggle = false;
            }

            // setting the fish timer slider to the correct value (percentage of time passed)
            catchingFishTimer.GetComponent<Slider>().value = catchingFishTime / catchingFishDelay;
            catchingFishTime += Time.deltaTime; // incrementing the time by a second
        }

        if (countingDown) // checking if the day time can count down
        {
            dayCycleInterval -= Time.deltaTime; // counting down the timer
        }
    }

    // function that enables the catching fish game
    public void catchingFish()
    {
        // setting the variables to their "on" state
        catchingFishTimer.GetComponent<Slider>().value = 0;
        catchingFishToggle = true;
        catchingFishGame.SetActive(true);
        catchingFishTimer.SetActive(true);
    }

    // function that sets the max fish catch count based on the fish index
    public void SetMaxFishCatchCount()
    {
        float maxFishCatchCountBase = gameObject.GetComponent<fishCatchController>().maxFishCatchCountBase;
        gameObject.GetComponent<fishCatchController>().maxFishCatchCount = maxFishCatchCountBase + (maxFishCatchCountBase * (fishIndex/2));
    }

    // updating the inventory based on the index sent through
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

    // remove item from inventory based on the icon selected
    public void removeItemFromInventory(int iconIndex)
    {
        // update the inventory dictionary
        inventory[iconIndex] = 0;
        // update the inventory icon
        icons[iconIndex].GetComponent<Image>().sprite = null;
        icons[iconIndex].SetActive(false);
    }

    // reset the reeling fish slider game
    public void resetCatchFish()
    {
        // setting variables to "off" state
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

    // trigger a selling event based on the inventory index
    public void triggerSellingEvent(int inventoryIndex)
    {
        // setting the sell menu to active
        sellMenu.SetActive(true);
        Debug.Log(inventoryIndex); // printing the current inventory index
        Debug.Log(inventory[inventoryIndex]); // printing whats in the slot
        sellObject.GetComponent<sellOffers>().SellingFish(inventory[inventoryIndex]); // start the selling event for the fish
    }

    // disable sell menu
    public void finishSelling()
    {
        sellMenu.SetActive(false);
    }

    // trigger end of day cycle that removes money from the player and alows them to purchase upgrades
    public void endOfDayCycle()
    {
        noticeBoard.GetComponent<noticeBoard>().DisplayWord("End of the Day"); // display that the game has reached the end of the day
        Debug.Log(billsCost); // print the cost of bills 
        money -= billsCost; // remove the cost of bills from the money
        if (money <= 0) // if the money is now less than 0 the game is over
        {
            // trigger the game over screen
            Debug.Log("Game Over");
            noticeBoard.GetComponent<noticeBoard>().DisplayWord("Game Over");
            gameOverScreen.SetActive(true);
            scoreText.text = currentDay + " Day";
        }

        billsCost = (20 * currentDay * currentDay) + 150; // increase the cost of bills using an exponential curve upwards

        // set the upgrade buy offer costs/variables
        buyMenu.SetActive(true);
        buyOffers.GetComponent<FishingRodBuy>().catchSpeedCost += 50 * (currentDay * currentDay) + buyOffers.GetComponent<FishingRodBuy>().catchSpeedCostInitial;
        buyOffers.GetComponent<FishingRodBuy>().hitBoxCost += 50 * (currentDay * currentDay) + buyOffers.GetComponent<FishingRodBuy>().hitBoxCostInitial;
        buyOffers.GetComponent<FishingRodBuy>().hookSpeedCost += 50 * (currentDay * currentDay) + buyOffers.GetComponent<FishingRodBuy>().hookSpeedCostInitial;

        currentDay++; // iterate on the current day

        sellOffers.GetComponent<sellOffers>().difficulty += 0.5f; // increase the amount of money the sell offers have
    }

    // set the slider fish game variables based on the fish index
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

    // start next day resets relevant variables such as the clock/day time
    public void StartNextDay()
    {
        resetCatchFish(); // reseting the slider game
        // removing fish from the inventory
        for (int i = 0; i < icons.Length; i++)
        {
            removeItemFromInventory(i);
        }
        timeOfDay = dayCycleMax;
        var clockObject = GameObject.FindAnyObjectByType<clockController>();
        clockObject.GetComponent<clockController>().RestartClock(); // restarts the clock
    }

    public void RestartGame() // reloads the main game scene
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
