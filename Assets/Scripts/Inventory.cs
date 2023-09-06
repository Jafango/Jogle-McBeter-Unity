using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Boolean classes used to check if the canvas object is enabled
    public bool inventoryCanvasEnabled;
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;
    public GameObject[] slot;

    public GameObject slotHolder;



    public void Start()
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
    }



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
            inventory.SetActive(true);
        }

        // If the boolean is false disables the inventory
        else
        {
            inventory.SetActive(false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            // Defines the item picked up for a bit to be placed in the inventory
            GameObject itemPicked = collision.gameObject.gameObject;

            // Gets the components within the item script
            Item item = itemPicked.GetComponent<Item>();

            // Calls the AddItem function and adds the item variables required in the function
            AddItem(itemPicked, item.ID, item.type, item.description, item.icon);
        }
    }



    void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {

        // Used to check if a slot is empty to add item
        for (int i = 0; i < allSlots; i++)
        {
            // If the slot is empty then add item
            if (slot[i].GetComponent<Slot>().empty)
            {
                // Sets the picked boolean to true
                itemObject.GetComponent<Item>().picked = true;



                // Sets the ttem of the picked object to the slot
                slot[i].GetComponent<Slot>().item = itemObject;

                // Sets the icon of the picked object to the slot
                slot[i].GetComponent<Slot>().icon = itemIcon;

                // Sets the type of the picked object to the slot
                slot[i].GetComponent<Slot>().type = itemType;

                // Sets the id of the picked object to the slot
                slot[i].GetComponent<Slot>().ID = itemID;

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
            else if (slot[i].GetComponent<Slot>().empty == false && slot[i].GetComponent<Slot>().ID == itemID)
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
    }
}
