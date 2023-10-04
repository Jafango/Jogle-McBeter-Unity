using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject exitPosition;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = exitPosition.transform.position;
        }
    }
}
