using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Jogle-McBeter-Unity/Recipe", order = 1)]
public class RecipeScriptableObject : ScriptableObject
{
    public Item[] requireditems = new Item[4];

    public Item resultCraftedItem;
}
