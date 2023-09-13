using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

[Serializable]

public class Slot
{
    // Variables of the slot
    [Header("Item data passed in from Item class")]
    public Item itemData;

    [Header("Counter variables")]
    [Tooltip("total number of items")]
    public int objectCounter;

    public Slot(Item item)
    {
        itemData = item;
        AddToStack(item.amount);
    }

    public void AddToStack(int amount)
    {
        objectCounter = objectCounter + amount;
    }
    public void RemoveFromStack()
    {
        objectCounter--;
    }
}
