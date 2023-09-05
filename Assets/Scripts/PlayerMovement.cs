using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components
    Rigidbody2D rb;

    //Player
    float movementSpeed = 4f;
    float sprintMultiplier = 1.5f;
    float horizontalInput;
    float verticalInput;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<RigidBody2D>()
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        
    }
}
