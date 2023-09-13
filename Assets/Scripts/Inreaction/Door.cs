using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject exitPosition;
    public GameObject player;
    public GameObject door;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("in trigger");
        if(Input.GetKeyDown("g"))
        {
            Debug.Log("in get key");
            player.transform.position = exitPosition.transform.position;
        }
    }
}
