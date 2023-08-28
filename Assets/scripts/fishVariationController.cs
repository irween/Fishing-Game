using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class fishVariationController : MonoBehaviour
{
    // max types of fish
    public int fishTypesMax;

    // fish sprites
    public Sprite[] fishSprites;

    // game manager
    public GameObject gameManager;

    // current index of the fish
    public int fishIndex;

    // initial delay/timer to trigger the reeling minigame
    private float timeToFish;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        // set fish type max to the length of the array
        fishSprites = gameManager.GetComponent<GameManager>().fishSprites;
        fishTypesMax = fishSprites.Length;

        // select random sprite from fishSprites array
        fishIndex = Random.Range(0, fishTypesMax);
        gameObject.GetComponent<SpriteRenderer>().sprite = fishSprites[fishIndex];

    }

    // resets the fish slider to the current fish
    public void ResetFish()
    {
        fishIndex = Random.Range(0, fishTypesMax);
        gameObject.GetComponent<SpriteRenderer>().sprite = fishSprites[fishIndex];
    }

    private void Update()
    {
        // counting the timer
        timeToFish += Time.deltaTime;
    }

    // when the player collides with the fish setting the slider fish to the current fish in the game manager
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hook") && timeToFish >= delay) // won't trigger if the delay hasn't been long enough
        {
            gameManager.GetComponent<GameManager>().SetSliderFish(fishIndex);
            timeToFish = 0;
            ResetFish();
        }
    }
}
