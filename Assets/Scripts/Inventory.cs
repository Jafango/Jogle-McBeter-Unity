using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting.ReorderableList;

public class Inventory : MonoBehaviour
{
    // Boolean classes used to check if the canvas object is enabled

    [Header("Inventory")]
    [Tooltip("Used to check if the inventory is visible or not when the game starts")]
    public bool inventoryCanvasEnabled;

    [Tooltip("Inventory GameObject is placed here to be used in the script")]
    public GameObject inventoryGameObject;

    [Header("Inventory Slots")]
    private int allSlots;
    private int enabledSlots;

    [Tooltip("The number of slots that is with in the UI & the slots input area")]
    public List<Slot> inventorySlots = new List<Slot>();
    private Dictionary<Item, Slot> itemDictionary = new Dictionary<Item, Slot>();

    [Tooltip("The UI object that has the slots as the child in the UI")]
    public GameObject slotHolder;

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
        }
        else
        {
            Slot newItem = new Slot(itemData);
            inventorySlots.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"{itemData.displayName} first time ");
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
            inventoryGameObject.SetActive(true);
        }

        // If the boolean is false disables the inventory
        else
        {
            inventoryGameObject.SetActive(false);
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

 

/*    void AddItem(Item item)
    {

        // Used to check if a slot is empty to add item
        for (int i = 0; i < allSlots; i++)
        {
            // If the slot is empty then add item
            if (slot[i].GetComponent<Slot>().empty)
            {
                // Sets the ttem of the picked object to the slot
                slot[i].GetComponent<Slot>().item = itemObject;

                // Sets the icon of the picked object to the slot
                slot[i].GetComponent<Slot>().icon = itemIcon;

                // Sets the type of the picked object to the slot
                slot[i].GetComponent<Slot>().displayName = displayName;

                // Sets the icon of the picked object to the slot
                slot[i].GetComponent<Slot>().description = itemDescription;



                // Moves the item to the slot
                itemObject.transform.parent = slot[i].transform;

                // Disables the item object
                itemObject.SetActive(false);


                // Calls the function UpdateSlot
                slot[i].GetComponent<Slot>().UpdateSlot();


                // Sets the slot empty to false to make sure to other item is added to the slot
                slot[i].GetComponent<Slot>().empty = false;


                return;
            }
            else if (slot[i].GetComponent<Slot>().empty == false && slot[i].GetComponent<Slot>().displayName == displayName)
            {
                // Moves the item to the slot
                itemObject.transform.parent = slot[i].transform;

                // Disables the item object
                itemObject.SetActive(false);

                // Adds one to the text which is displayed to check the numbers of same items in the inventory
                slot[i].GetComponent<Slot>().UpdateNumberOfObject();

                return;
            }
        }
    } */
} 
