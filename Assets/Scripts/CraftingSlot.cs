using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public Image icon;
    public void Clearslot()
    {
        icon.enabled = false;
    }

    public void EnableSlot()
    {
        icon.enabled = true;
    }

    public void DrawSlot(Sprite sprite)
    {
        Debug.Log("the sprite is " + sprite);
        icon.enabled = true;
        icon.sprite = sprite;
    }
}
