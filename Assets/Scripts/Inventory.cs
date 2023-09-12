using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting.ReorderableList;
using System;

public class Inventory : MonoBehaviour
{
    // Boolean classes used to check if the canvas object is enabled

    [Header("Inventory")]
    [Tooltip("Used to check if the inventory is visible or not when the game starts")]
    public bool inventoryCanvasEnabled;

    [Tooltip("Inventory GameObject is placed here to be used in the script")]
    public GameObject inventoryGameObject;
    public GameObject CraftingGameObject;

    [Tooltip("The number of slots that is with in the UI & the slots input area")]

    public static event Action<List<Slot>> OnInventoryChange;
    public List<Slot> inventorySlots = new List<Slot>();
    private Dictionary<Item, Slot> itemDictionary = new Dictionary<Item, Slot>();

    private void OnEnable() {
        pickupTest.onTestItemCollected += Add;
    }

    private void OnDisable() {
        pickupTest.onTestItemCollected -= Add;
    }
    public void Add(Item itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out Slot item))
        {
            item.AddToStack();
            Debug.Log($"{item.itemData.displayName} total stack is now {item.objectCounter}");
            OnInventoryChange?.Invoke(inventorySlots);
        }
        else
        {
            Slot newItem = new Slot(itemData);
            inventorySlots.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"{itemData.displayName} first time ");
            OnInventoryChange?.Invoke(inventorySlots);
        }
    }

    public void Remove(Item itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out Slot item))
        {
            item.RemoveFromStack();
            if(item.objectCounter == 0)
            {
                inventorySlots.Remove(item);
                itemDictionary.Remove(itemData);
            }
            OnInventoryChange?.Invoke(inventorySlots);
        }
    }

    /*public void Start()
    {
        // Variables used
        allSlots = 2;
        slot = new GameObject[allSlots];



        for (int i = 0; i < allSlots; i++)
        {
            // Gets the slot child from the slot holder and setting it to slot[i]
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            // Makes sure that the slots contain nothing
            if (slot[i].GetComponent<Slot>().item == null)
            {
                // Sets the empty boolean to true
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
    } */



    void Update()
    {
        // Sets the bool variable inventoryCanvasEnabled to true/false
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryCanvasEnabled = !inventoryCanvasEnabled;
        }


        // If the inventoryCanvasEnabled boolean is true then enables the inventory
        if (inventoryCanvasEnabled == true)
        {
            //inventoryGameObject.GetComponentInChildren<CanvasRenderer>().cull = true;
            //inventoryGameObject.SetActive(true);
            /*foreach(GameObject go in GameObject.FindGameObjectsWithTag("Crafting"))
            {
                CanvasRenderer renderer = go.GetComponent<CanvasRenderer>();
                renderer.cull = true;
            }*/
            //CraftingGameObject.GetComponent<CanvasRenderer>().cull = false;

        }

        // If the boolean is false disables the inventory
        else
        {
            //inventoryGameObject.GetComponentInChildren<CanvasRenderer>().cull = false;
            //inventoryGameObject.SetActive(false);
            /*foreach(GameObject go in GameObject.FindGameObjectsWithTag("Crafting"))
            {
                CanvasRenderer renderer = go.GetComponent<CanvasRenderer>();
                renderer.cull = false;
            }*/
            //CraftingGameObject.GetComponent<CanvasRenderer>().cull = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ICollectable collectable = collision.GetComponent<ICollectable>();
        if(collectable != null)
        {
            collectable.Collect();
            // Defines the item picked up for a bit to be placed in the inventory
            GameObject itemPicked = collision.gameObject.gameObject;

            // Gets the components within the item script
            //Item item = itemPicked.GetComponent<Item>();

            // Calls the AddItem function and adds the item variables required in the function
            //AddItem(item);
        }
    }
} 
