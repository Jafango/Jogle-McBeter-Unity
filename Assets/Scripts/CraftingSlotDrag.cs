using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlotDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public InventorySlot inventorySlot;
    public GameObject slotCopy;
    private SlotCopy dragInfo;
    public void OnBeginDrag(PointerEventData eventData)
    {
        //When beginning to drag the item, code will make a copy (instantiate) of the item image, which the player will drag around
        //this instantiated ui object will be destroyed if dragged back into the inventory item side, or will be added to the crafting system is left go of in the crafting side
        GameObject dragged = Instantiate(slotCopy, transform.parent.transform.parent);
        dragInfo = dragged.GetComponent<SlotCopy>();
        dragInfo.SetSlotInfo(inventorySlot.icon.sprite);
        inventorySlot.itemInfo.RemoveFromStack();
        inventorySlot.UpdateCounter();
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragInfo.Delete();
    }
}
