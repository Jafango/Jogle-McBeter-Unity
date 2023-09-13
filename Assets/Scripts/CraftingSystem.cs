using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CraftingSystem : MonoBehaviour
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
}
