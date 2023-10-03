using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenPickup : MonoBehaviour, ICollectable
{
    public static event HandleOxygenCollected onOxygenCollected;
    public delegate void HandleOxygenCollected(Item item); //does the add item
    public Item itemData;


    public void Collect()
    {
        Destroy(gameObject);
        onOxygenCollected?.Invoke(itemData);
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
