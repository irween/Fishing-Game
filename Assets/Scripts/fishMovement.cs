using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    private float speed;
    public float baseSpeed;

    public float delay;
    private float timeToMove;

    public float minDistance;

    private float distance;
    private Rigidbody2D rb2D;

    private Vector2 movement;

    private void Start()
    {
        speed = (GetComponent<fishVariationController>().fishIndex + 1) * baseSpeed/2;
        rb2D = GetComponent<Rigidbody2D>();

        movement = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (distance > minDistance)
        {

            if (timeToMove >= Random.Range(1, delay))
            {
                movement = new Vector2(Random.Range(-speed, speed), Random.Range(-speed, speed));

                timeToMove = 0;
            }

            timeToMove += Time.deltaTime;

            rb2D.AddForce(movement * Time.deltaTime);
        }
        else
        {
            distance = Vector2.Distance(GameObject.FindGameObjectWithTag("Hook").transform.position, transform.position);
            Vector2 direction = transform.position - GameObject.FindGameObjectWithTag("Hook").transform.position;
            rb2D.AddForce(direction * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            movement = -movement;
            timeToMove = 0;
        }
    }
}
