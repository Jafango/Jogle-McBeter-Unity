using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    Rigidbody2D rb;

    //Player
    [Header("Player Movement")]
    [Tooltip("base player movement speed")]
    public float movementSpeed = 4f;
    float horizontalInput;
    float verticalInput;
    
    //Sprint
    [Header("Sprint")]
    [Tooltip("player sprint speed multiplier")]
    public float sprintMultiplier = 2f;
    [Tooltip("this is the max amount of time the player can sprint for")]
    public float maxSprintLength = 3f;
    [Tooltip("this is the length of the sprint")]
    public float sprintLength = 3f;
    [Tooltip("this is the max amount of time it takes for the player to regenerate their sprint")]
    public float maxRegenerateSprintLength = 0.5f;
    [Tooltip("this is the time it takes to regenerate the sprint")]
    public float regenerateSprintLength = 0.5f;
    [Tooltip("this is how fast the sprint regenerates (keep this value low (0.05 - 0.10))")]
    public float regenerateSprintAmount = 0.05f;

    //Lerp
    [Header("Lerp")]
    [Tooltip("this is how smooth the player movement is (keep this value really low (0.005 to 0.05))")]
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
