using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    Rigidbody2D rb;

    //Player
    public float movementSpeed = 4f;
    float horizontalInput;
    float verticalInput;
    
    //Sprint
    public float sprintMultiplier = 2f;
    float maxSprintLength = 3f;
    public float sprintLength = 3f;
    float maxRegenerateSprintLength = 0.5f;
    public float regenerateSprintLength = 0.5f;
    public float regenerateSprintAmount = 0.05f;

    //Lerp
    public float lerpAmount = 0.05f;


    

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
        if(Input.GetButton("Fire1") && sprintLength > 0f)
        {
            regenerateSprintLength = maxRegenerateSprintLength;
            sprintLength -= Time.deltaTime;
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(horizontalInput, verticalInput).normalized * (movementSpeed * sprintMultiplier), lerpAmount);
        }
        else
        {
            rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(horizontalInput, verticalInput).normalized * movementSpeed, lerpAmount);
        }

        if(!Input.GetButton("Fire1"))
        {
            if(regenerateSprintLength <= 0f)
            {
                if(sprintLength <= maxSprintLength)
                {
                    sprintLength += (Time.deltaTime + regenerateSprintAmount);
                }
            }
            else
            {
                regenerateSprintLength -= Time.deltaTime;
            }
        }
    }
}
