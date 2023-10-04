using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class PlayerMovTest : MonoBehaviour
{
    public float movementSpeed = 4f;
    public float speedLimiter = 0.7f;
    float horizontalInput;
    float verticalInput;

     // Animations and states
    public Animator animator; 
    string currentAnimState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_UP = "Player_up";
    const string PLAYER_DOWN = "Player_down";
    const string PLAYER_LEFT = "Player_left";
    const string PLAYER_RIGHT = "Player_Right";

    Rigidbody2D rb;

    // Update is called once per frame
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate(){
        if (horizontalInput != 0 || verticalInput != 0){
            
            if (horizontalInput != 0 && verticalInput != 0){
                horizontalInput *= speedLimiter;
                verticalInput *= speedLimiter;
            }

            rb.velocity = new Vector2(horizontalInput * movementSpeed, verticalInput * movementSpeed);

            if (horizontalInput > 0) {
                ChangeAnimationState(PLAYER_RIGHT);
            }
            else if (horizontalInput < 0) {
                ChangeAnimationState(PLAYER_LEFT);
            }
            else if (verticalInput > 0) {
                ChangeAnimationState(PLAYER_UP);
            }
            else if (verticalInput < 0) {
                ChangeAnimationState(PLAYER_DOWN);
            }
        }
        else {
            rb.velocity = new Vector2(0f, 0f);
            ChangeAnimationState(PLAYER_IDLE);
        }
    }

    void ChangeAnimationState(string newState){
        if(currentAnimState == newState) return;

        animator.Play(newState);

        currentAnimState = newState;
    }
}
