using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;



public class CraftingSystem : MonoBehaviour, IDropHandler
{
    //REMEMBER MAKE EVERY STATIC
    public static List<RecipeScriptableObject> recipeScriptable;
    //[SerializeField] public List<string> craftingSlots = new List<string>();

    //crafting slots is used for the crafting system to store the item information that are in the slots
    [SerializeField] public static List<InventorySlot> craftingSlots = new List<InventorySlot>();

    //gets the player inventory
    public Inventory playerInventory;
    public GameObject player;
        
    [SerializeField] public List<RecipeScriptableObject> recipes;

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
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        if(runItemReplace == true)
        {
            slotImages[amount].GetComponent<CraftingSlot>().EnableSlot();
            slotImages[amount].GetComponent<CraftingSlot>().DrawSlot(craftingSlots[amount].icon.sprite);
            amount = amount + 1;
            runItemReplace = false;
        }

        if(Input.GetKeyDown("tab"))
        {
            DontDestroyOnLoad(player.gameObject);
            SceneManager.LoadScene("Test_Level", LoadSceneMode.Single);  
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
    }

    public void CraftItem()
    {
        if(craftingSlots.Count() > 0)
        {
            for(int y = 0; y < recipes.Count(); y++)
            {
                Debug.Log("Hello: " + recipes[y].resultCraftedItem.ToString());
                //for keeping track of if the craftingSlots matches any of the recipes
                int canBeCrafted = 0;
                for(int x = 0; x < craftingSlots.Count(); x++)
                {
                    //these ifs are here to check if the crafting slot and recipe slot are null to prevent null errors
                    if(craftingSlots[x] != null)
                    {
                        if(craftingSlots[x].itemInfo.itemData == recipes[y].requiredItems[x])
                        {
                            canBeCrafted += 1;
                        }
                    }
                }
                //checks to see if the inputted crafting items are correct
                //and checks to see if the correct number 
                if(canBeCrafted == recipes[y].requiredItems.Count(s => s != null) && craftingSlots.Count() == recipes[y].requiredItems.Count(s => s != null))
                {
                    //used to remove one of the items
                    for(int x = 0; x < craftingSlots.Count(); x++)
                    {
                        //craftingSlots[x].itemInfo.RemoveFromStack();
                        playerInventory.Remove(craftingSlots[x].itemInfo.itemData);
                        //craftingSlots[x].UpdateCounter();
                    }
                    Debug.Log("IT WORKSSSS");
                    playerInventory.Add(recipes[y].resultCraftedItem);
                    RemoveCurrentItems();
                    break;
                }
                else
                {
                    //TODO: add tooltip thats says no recipe
                    RemoveCurrentItems();
                }
            }
        }
        else
        {
            //TODO: add ui popup that says cant craft without items dropped in
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
