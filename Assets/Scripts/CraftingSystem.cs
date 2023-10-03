using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;


public class CraftingSystem : MonoBehaviour, IDropHandler
{
    //REMEMBER MAKE EVERY STATIC
    public static List<RecipeScriptableObject> recipeScriptable;
    //[SerializeField] public List<string> craftingSlots = new List<string>();

    //crafting slots is used for the crafting system to store the item information that are in the slots
    [SerializeField] public static List<InventorySlot> craftingSlots = new List<InventorySlot>();

    //slot images is used to display the item that is put into the slots
    [SerializeField] public List<GameObject> slotImages = new List<GameObject>(4);
    public static int amount = 0;
    private static bool itemIn;
    private static bool runItemReplace;
    //public string tempValue;
    public InventorySlot tempValue;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            //Debug.Log("this is true");
            setItemIn(true);
            //currentItemList.Append(slotCopy.slot);
            //slotCopy.Delete();
        }
    }
    private void Start()
    {
        amount = 0;
        runItemReplace = false;
        for(int i = 0; i < slotImages.Count; i++)
        {
            slotImages[i].GetComponent<CraftingSlot>().ClearSlot();
        }
    }

    private void Update()
    {
        //Debug.Log("Crafting Slots count " + craftingSlots.Count);
    }

    private void LateUpdate()
    {
        if(slotImages[0] != null)
        {
            Debug.Log("slot image 0 is not null " + slotImages[0]);
        }
        if(runItemReplace == true)
        {
            Debug.Log("amount " + amount);
            slotImages[amount].GetComponent<CraftingSlot>().EnableSlot();
            Debug.Log("crafting slot count " + craftingSlots.Count);
            Debug.Log("inputted sprite " + craftingSlots[amount].icon.sprite);
            Debug.Log("current slot sprite " + slotImages[amount].GetComponent<CraftingSlot>().icon.sprite);
            slotImages[amount].GetComponent<CraftingSlot>().DrawSlot(craftingSlots[amount].icon.sprite);
            amount = amount + 1;
            runItemReplace = false;
        }
    }
    
    public bool checkItemIn()
    {
        return itemIn;
    }
    public void setItemIn(bool set)
    {
        itemIn = set;
    }
    public void AddItem(InventorySlot inventorySlot)
    {
        if(amount < 4)
        {
            //tempValue = name;
            tempValue = inventorySlot;
            craftingSlots.Add(tempValue);
            runItemReplace = true;
            //OnInventoryChange?.Invoke(craftingSlots);
            //slotImages[amount].GetComponent<CraftingSlot>().DrawSlot(tempValue.icon.sprite);
            //changeSlotImage(tempValue.icon.sprite);

            //Debug.Log("in this crafting slot " + craftingSlots[amount].labelText.text);
        }
        else
        {
            Debug.Log("max amount of items put in");
            //TODO put in some ui that says the player has the max amount of items put in
        }
        setItemIn(false);
    }

    private void changeSlotImage(Sprite iconSprite)
    {
        //Debug.Log("we here");
        slotImages[amount].GetComponent<CraftingSlot>().DrawSlot(iconSprite);
        //Debug.Log("inputted slot image " + slotImages[amount].GetComponent<CraftingSlot>().icon.sprite);
        if(slotImages[amount].GetComponent<Image>() == true)
        {
            //Debug.Log("slot images is enabled");
        }
    }

    public void RemoveCurrentItems()
    {
        craftingSlots.Clear();
        amount = 0;
        for(int x = 0; x < slotImages.Count; x++)
        {
            slotImages[x].GetComponent<CraftingSlot>().ClearSlot();
        }
    }
}
