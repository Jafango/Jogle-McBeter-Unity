using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Player"));
            Scene scene = SceneManager.GetActiveScene();
            if(scene == SceneManager.GetSceneByName("CraftingScene"))
            {
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
            if(scene == SceneManager.GetSceneByName("SampleScene"))
            {
                SceneManager.LoadScene("CraftingScene", LoadSceneMode.Single);
            }
        }
    }
}
