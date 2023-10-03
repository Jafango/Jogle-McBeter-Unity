using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting.ReorderableList;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    [Tooltip("The number of slots that is with in the UI & the slots input area")]

    public static event Action<List<Slot>> OnInventoryChange;
    public List<Slot> inventorySlots = new List<Slot>();
    private Dictionary<Item, Slot> itemDictionary = new Dictionary<Item, Slot>();

    private void OnEnable() {
        pickupTest.onTestItemCollected += Add;
        pickupTest2.onTest2ItemCollected += Add;
        OxygenPickup.onOxygenCollected += Add;
        SulphurPickup.onSulphurCollected += Add;
        HyrogenPickup.onHyrogenCollected += Add;
    }

    private void OnDisable() {
        pickupTest.onTestItemCollected -= Add;
        pickupTest2.onTest2ItemCollected -= Add;
        OxygenPickup.onOxygenCollected -= Add;
        SulphurPickup.onSulphurCollected -= Add;
        HyrogenPickup.onHyrogenCollected -= Add;
    }

    private void Start()
    {
        OnInventoryChange?.Invoke(inventorySlots);
        SceneManager.activeSceneChanged += OnSceneLoaded;
    }

    public void reloadScene()
    {
        OnInventoryChange?.Invoke(inventorySlots);
    }

    private void OnSceneLoaded(Scene current, Scene next)
    {
        string currentName = current.name;

        if(currentName == null)
        {
            OnInventoryChange?.Invoke(inventorySlots);
        }
    }


    public void Add(Item itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out Slot item))
        {
            item.AddToStack(item.itemData.amount);
            //Debug.Log($"{item.itemData.displayName} total stack is now {item.objectCounter}");
            OnInventoryChange?.Invoke(inventorySlots);
        }
        else
        {
            Slot newItem = new Slot(itemData);
            inventorySlots.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            //Debug.Log($"{itemData.displayName} first time ");
            OnInventoryChange?.Invoke(inventorySlots);
        }
    }

    public Slot ReturnItem(Item itemData)
    {
        if(itemDictionary.TryGetValue(itemData, out Slot item))
        {
            return item;
        }
        else
        {
            return null;
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
