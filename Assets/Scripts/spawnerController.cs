using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{
    // max/min x,y pos
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // amount of fish to spawn
    public float fishAmount;

    // fish prefab
    public GameObject fish;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateFish();
    }

    // instantiate fish at a random position
    public void InstantiateFish()
    {
        for (int i = 0; i < fishAmount; i++) // loop for the amount of fish to spawn
        {
            Vector2 randomPosition = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)); // get a random position

            GameObject fishClone = Instantiate(fish, randomPosition, Quaternion.identity); // instantiate at that position

            fishClone.transform.parent = gameObject.transform; // make the spawner the parent
        }
    }
}
