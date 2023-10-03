using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerMovement : MonoBehaviour
{
    public GameObject interactObject;
    public Animator animator; 
    private Vector2 boxSize = new Vector2(0.1f, 1f);
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
    [Header("Player smoother")]
    [Tooltip("this is how smooth the player movement is (keep this value really low (0.005 to 0.05))")]
    public float lerpAmount = 0.05f;


    

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        interactObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
            CheckInteraction();

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
        animator.SetFloat("Speed", movementSpeed);
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
    public void OpenInteractableIcon()
    {
        interactObject.SetActive(true);
    }

    public void CloseInteractableIcon()
    {
        interactObject.SetActive(false);
    }

    private void CheckInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize,0, Vector2.zero);
        if(hits.Length > 0)
            foreach(RaycastHit2D rc in hits)
            {
                if (rc.transform.GetComponent<Interactable>())
                {
                    rc.transform.GetComponent<Interactable>().Interact();
                    return;
                }
            }
    }
}
