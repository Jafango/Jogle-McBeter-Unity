using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotCopy : MonoBehaviour
{
    public Image slotImage;
    public CanvasGroup canvasGroup; 

    private void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetSlotInfo(Sprite image, Slot inheretedInventorySlot)
    {
        slotImage.sprite = image;
    }

    public void BlockRayCasts(bool block)
    {
        if(block == true)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
        else
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
        }
    }

    public void Delete()
    {
        Destroy(gameObject);
    }
}
