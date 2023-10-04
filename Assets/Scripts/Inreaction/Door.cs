using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject exitPosition;
    public GameObject player;
    public GameObject door;
    private bool inTrigger;

    private void Start()
    {
        inTrigger = false;
        player = GameObject.FindGameObjectWithTag("Player");
        //player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        if (Input.GetKeyDown("h") && inTrigger == true)
        {
            Debug.Log("in get key");
            player.transform.position = exitPosition.transform.position;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("in trigger");
        if(other.tag == "Player")
        {
            inTrigger = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
    }
}
