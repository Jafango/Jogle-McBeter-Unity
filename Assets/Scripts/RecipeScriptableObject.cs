using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Jogle-McBeter-Unity/Recipe", order = 1)]
public class RecipeScriptableObject : ScriptableObject
{
    public Item firstItem;
    public Item secondItem;
    public Item thirdItem;

}
