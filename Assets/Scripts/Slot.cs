using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // Variables of the slot
    public GameObject item;
    public int ID;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    public TMP_Text numberOfObject;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
    }

    public void UpdateNumberOfObject()
    {
        numberOfObject.text += 1.ToString();
    }
}
