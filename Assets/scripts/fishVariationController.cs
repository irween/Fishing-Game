using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class fishVariationController : MonoBehaviour
{
    // declaring fish variables
    public int fishTypesMax;

    public Sprite[] fishSprites;

    public GameObject gameManager;

    public int fishIndex;

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

    public void ResetFish()
    {
        fishIndex = Random.Range(0, fishTypesMax);
        gameObject.GetComponent<SpriteRenderer>().sprite = fishSprites[fishIndex];
    }

    private void Update()
    {
        timeToFish += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Hook") && timeToFish >= delay)
        {
            gameManager.GetComponent<GameManager>().SetSliderFish(fishIndex);
            timeToFish = 0;
            ResetFish();
        }
    }
}
