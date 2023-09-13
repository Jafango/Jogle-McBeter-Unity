using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCopy : MonoBehaviour
{
    public Image slotImage;

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetSlotInfo(Sprite image)
    {
        slotImage.sprite = image;
    }

    public void OnCollsiionEnter2D(Collider2D other)
    {
        Debug.Log("Slot copy collide");
        if(other.tag == "CraftingSystem")
        {
            Debug.Log("in the triggerr");
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}