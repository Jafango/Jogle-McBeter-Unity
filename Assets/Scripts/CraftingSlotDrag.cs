using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlotDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public InventorySlot inventorySlot;
    public GameObject player;
    public Inventory inventory;
    public GameObject slotCopy;
    //used to stop player from moving temp slot
    public GameObject dontCopySlot;
    private SlotCopy dragInfo;
    private CanvasGroup canvasGroup;

    public CraftingSystem craftingSystem;

    private void Start() 
    {
        canvasGroup = GetComponent<CanvasGroup>();
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = player.GetComponent<Inventory>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //When beginning to drag the item, code will make a copy (instantiate) of the item image, which the player will drag around
        //this instantiated ui object will be destroyed if dragged back into the inventory item side, or will be added to the crafting system is left go of in the crafting side
        
        if(inventorySlot.icon.isActiveAndEnabled)
        {
            GameObject dragged = Instantiate(slotCopy, transform.parent.transform.parent);
            dragInfo = dragged.GetComponent<SlotCopy>();
            dragInfo.SetSlotInfo(inventorySlot.icon.sprite, inventorySlot.itemInfo);

            

            //Debug.Log("i be dragging");
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;

            dragInfo.BlockRayCasts(true);
            //Debug.Log("i be really dragging");
        }
    }

    private void InventoryRemove(Item itemData)
    {
        inventory.Remove(itemData);
        inventorySlot.UpdateCounter();
    }
    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("stuck dragging");
    }

    private void Update()
    {
        /*if(craftingSystem.checkItemIn())
        {
            Debug.Log("in if");
            string itemName = inventorySlot.itemInfo.itemData.displayName;
            Debug.Log("item name = " + itemName);
            craftingSystem.AddItem(inventorySlot.itemInfo.itemData);
            craftingSystem.setItemIn(false);
        }*/
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("let go");
        //THIS FUCKING FUNCTION GOES BEFORE ONDROP WTFF
        if(inventorySlot.icon.isActiveAndEnabled)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            dragInfo.BlockRayCasts(false);
            if(craftingSystem.checkItemIn())
            {
                //string itemName = new string("");
                InventorySlot tempInventorySlot = GetComponent<InventorySlot>();
                //itemName = inventorySlot.itemInfo.itemData.displayName;
                tempInventorySlot = inventorySlot;
                //Debug.Log("the item name " + itemName);
                //craftingSystem.AddItem(itemName);
                craftingSystem.AddItem(tempInventorySlot);
            }
            dragInfo.Delete();
        }
    }
}
