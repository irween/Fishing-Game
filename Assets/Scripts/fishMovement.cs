using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    // speed variables
    private float speed;
    public float baseSpeed;

    public float delay; // delay between movements
    private float timeToMove; // time taken to move

    public float minDistance; // minimum distance 

    private float distance; // current distance to player
    private Rigidbody2D rb2D;

    private Vector2 movement;

    private void Start()
    {
        speed = (GetComponent<fishVariationController>().fishIndex + 1) * baseSpeed/2; // getting a speed for the fish based on the rarity (higher speed = more difficult)
        rb2D = GetComponent<Rigidbody2D>(); // getting the rigidbody component

        movement = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed)); // getting a random movement speed/direction
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (distance > minDistance) // checking if the distance to the player is outside the minimum distance to the player
        {

            if (timeToMove >= Random.Range(1, delay)) // getting a random delay between movements
            {
                movement = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed)); // getting a random movement speed/direction

                timeToMove = 0; // reseting the timer
            }

            timeToMove += Time.deltaTime; // counting up the timer

            rb2D.AddForce(movement * Time.deltaTime); // moving the fish
        }
        else
        {
            distance = Vector2.Distance(GameObject.FindGameObjectWithTag("Hook").transform.position, transform.position); // getting distance to player
            Vector2 direction = transform.position - GameObject.FindGameObjectWithTag("Hook").transform.position; // getting the direction to the player
            rb2D.AddForce(direction * Time.deltaTime * speed); // moving away from the player
        }
    }

    // once the fish collides with the border move away from it
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            movement = -movement;
            timeToMove = 0;
        }
    }
}
