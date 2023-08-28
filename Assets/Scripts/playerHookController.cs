using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHookController : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private Vector2 moveInput;

    public float speed;
    public float speedLimiter;
    private float inputHorizontal;
    private float inputVertical;

    public float xPosMax = 1.14f;
    public float xPosMin = -2.18f;
    public float yPosMax = 1.05f;
    public float yPosMin = -1.176f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(inputHorizontal, inputVertical);

        if (inputHorizontal != 0 || inputVertical != 0)
        {
            rb2D.AddForce(moveInput * speed * Time.deltaTime);
        }
    }
}
