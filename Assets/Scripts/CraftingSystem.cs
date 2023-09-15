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
    public List<RecipeScriptableObject> recipeScriptable;
    //[SerializeField] public List<string> craftingSlots = new List<string>();
    [SerializeField] public List<InventorySlot> craftingSlots = new List<InventorySlot>();
    [SerializeField] public List<GameObject> slotImages = new List<GameObject>(4);
    public int amount = 0;
    public int maxCount = 4;
    private static bool itemIn;
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
        GameObject[] gameObject = GameObject.FindGameObjectsWithTag("CraftingImageSlot");
        for(int i = 0; i < gameObject.Length; i++)
        {
            slotImages[i] = gameObject[i];//.GetComponent<Image>();
            slotImages[i].GetComponent<CraftingSlot>().Clearslot();
        }
    }

    private void Update()
    {
        if(itemIn == true)
        {
            Debug.Log("in item in");
            changeSlotImage(tempValue.itemInfo.itemData.icon);
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
            Debug.Log("inventory slot " + tempValue.itemInfo.itemData.displayName);
            Debug.Log("inventory slot 2 " + tempValue.itemInfo.itemData.icon.ToString());
            changeSlotImage(tempValue.itemInfo.itemData.icon);

            Debug.Log(slotImages[amount].ToString());
            Debug.Log("in this crafting slot " + craftingSlots[amount].labelText.text);
            foreach(InventorySlot item in craftingSlots)
            {
                Debug.Log("current items in " + item.labelText.text);
            }
            amount++;
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
        Debug.Log("we here");
        slotImages[amount].GetComponent<CraftingSlot>().DrawSlot(iconSprite);
        Debug.Log(slotImages[amount].ToString());
        if(slotImages[amount].GetComponent<Image>() == true)
        {
            Debug.Log("slot images is enabled");
        }
    }

    public void RemoveCurrentItem()
    {

    }
}
