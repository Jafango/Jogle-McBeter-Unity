using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public GameObject player;
    public Transform playerSpawn;
    void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            GameObject instPlayer = Instantiate(player);
            instPlayer.transform.position = playerSpawn.position;
        }
    }
}
