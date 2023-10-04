using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SulphurPickup : MonoBehaviour, ICollectable
{
    public static event HandleSulphurCollected onSulphurCollected;
    public delegate void HandleSulphurCollected(Item item); //does the add item
    public Item itemData;


    public void Collect()
    {
        Destroy(gameObject);
        onSulphurCollected?.Invoke(itemData);
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
