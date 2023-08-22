using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerController : MonoBehaviour
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    public float fishAmount;

    public GameObject fish;

    // Start is called before the first frame update
    void Start()
    {
        InstantiateFish();
    }

    public void InstantiateFish()
    {
        for (int i = 0; i < fishAmount; i++)
        {
            Vector2 randomPosition = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));

            GameObject fishClone = Instantiate(fish, randomPosition, Quaternion.identity);

            fishClone.transform.parent = gameObject.transform;
        }
    }
}
