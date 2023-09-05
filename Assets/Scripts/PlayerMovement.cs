using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    Rigidbody2D rb;

    //Player
    public float movementSpeed = 4f;
    public float sprintMultiplier = 1.5f;
    public float lerpAmount = 0.05f;
    float horizontalInput;
    float verticalInput;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(horizontalInput, verticalInput).normalized * movementSpeed, lerpAmount);
    }
}
