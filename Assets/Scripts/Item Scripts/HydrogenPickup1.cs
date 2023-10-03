using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyrogenPickup : MonoBehaviour, ICollectable
{
    public static event HandleHyrogenCollected onHyrogenCollected;
    public delegate void HandleHyrogenCollected(Item item); //does the add item
    public Item itemData;


    public void Collect()
    {
        Destroy(gameObject);
        onHyrogenCollected?.Invoke(itemData);
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
