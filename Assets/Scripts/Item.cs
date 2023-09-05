using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Item variables to identify item
    public int ID;
    public string type;
    public string description;
    public Sprite icon;
    public bool picked;

    void Start()
    {
        picked = false;
    }
}