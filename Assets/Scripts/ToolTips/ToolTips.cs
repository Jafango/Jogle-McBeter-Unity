using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTips : MonoBehaviour
{
    private Item itemData;

    public void Start()
    {
        itemData = gameObject.GetComponent<pickupTest>().itemData;
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
