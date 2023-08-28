using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHookController : MonoBehaviour
{
    // rigidbody
    private Rigidbody2D rb2D;

    // vector that stores the movement inputs
    private Vector2 moveInput;

    // speed variable
    public float speed;

    // input variables
    private float inputHorizontal;
    private float inputVertical;

    // Start is called before the first frame update
    void Start()
    {
        // setting the rigidbody
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    // fixed update isn't based on the in game fps making physics more accurate
    void FixedUpdate()
    {
        // getting horizontal and vertical inputs
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        // setting the vector move input x and y to the move inputs
        moveInput = new Vector2(inputHorizontal, inputVertical);

        // if the player presses any movement key move based on the vector
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            rb2D.AddForce(moveInput * speed * Time.deltaTime); // add a force in the direction of the x,y of the vector
        }
    }
}
