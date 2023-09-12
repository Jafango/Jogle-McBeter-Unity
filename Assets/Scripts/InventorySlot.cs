using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI labelText;
    public TextMeshProUGUI stackSizeText;

    public void ClearSlot()
    {
        icon.enabled = false;
        labelText.enabled = false;
        stackSizeText.enabled = false;
    }

    public void DrawSlot(Slot slot)
    {
        if(slot == null)
        {
            ClearSlot();
            return;
        }

        icon.enabled = true;
        labelText.enabled = true;
        stackSizeText.enabled = true;

        icon.sprite = slot.itemData.icon;
        labelText.text = slot.itemData.displayName;
        stackSizeText.text = slot.objectCounter.ToString();
    }
}
