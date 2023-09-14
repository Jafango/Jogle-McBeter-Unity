using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;


public class CraftingSystem : MonoBehaviour, IDropHandler
{
    public List<RecipeScriptableObject> recipeScriptable;

    public Item[] itemList;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("we outside");
        if(other.tag == "CraftingSlotCopy")
        {
            Debug.Log("in the triggerr");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped");
    }
}
