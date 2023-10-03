using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupTest : MonoBehaviour, ICollectable
{
    public static event HandleTestItemCollected onTestItemCollected;
    public delegate void HandleTestItemCollected(Item item); //does the add item
    public Item itemData;


    public void Collect()
    {
        Destroy(gameObject);
        onTestItemCollected?.Invoke(itemData);
    }

    public void OnMouseEnter()
    {
        ToolTipManager._instance.SetAndShowToolTips(itemData.displayName, itemData.description);
    }

    private void OnMouseExit()
    {
        ToolTipManager._instance.HideToolTips();
    }
}
