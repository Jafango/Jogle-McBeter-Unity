using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    // Variables of the slot
    [Header("Objects detail in slot")]
    public GameObject item;
    public string displayName;
    public string description;
    public bool empty;
    public Sprite icon;

    [Header("Counter variables")]
    [Tooltip("Text used to count number of same objects in a slot")]
    public TMP_Text numberOfObject;
    private int objectCounter;

    public void UpdateSlot()
    {
        this.GetComponent<Image>().sprite = icon;
        objectCounter = 1;
    }

    public void UpdateNumberOfObject()
    {
        objectCounter += 1;
        numberOfObject.text = "x" + objectCounter.ToString();
    }
}
