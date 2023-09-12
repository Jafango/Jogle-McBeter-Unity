using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            DontDestroyOnLoad(this.gameObject);
            SceneManager.LoadScene("CraftingScene", LoadSceneMode.Additive);
        }
    }
}
