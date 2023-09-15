using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using System.Linq;
using System;


public class CraftingSystem : MonoBehaviour, IDropHandler
{
    public List<RecipeScriptableObject> recipeScriptable;
    [SerializeField] public List<string> craftingSlots = new List<string>();
    public int amount = 0;
    public int maxCount = 4;
    private static bool itemIn;
    public string tempValue;
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
    }
    public bool checkItemIn()
    {
        return itemIn;
    }
    public void setItemIn(bool set)
    {
        itemIn = set;
    }
    public void AddItem(string name)
    {
        if(amount <= 4)
        {
            tempValue = name;
            craftingSlots.Add(tempValue);
            Debug.Log("in this crafting slot " + craftingSlots[amount]);
            foreach(String item in craftingSlots)
            {
                Debug.Log("current items in " + item);
            }
            amount++;
        }
        else
        {
            Debug.Log("max amount of items put in");
            //TODO put in some ui that says the player has the max amount of items put in
        }
    }

    public void RemoveCurrentItem()
    {

    }
}
