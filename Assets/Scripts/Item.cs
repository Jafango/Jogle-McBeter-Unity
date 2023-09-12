using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Jogle-McBeter-Unity/Item", order = 0)]
public class Item : ScriptableObject {
    // Item variables to identify item
    public string displayName;
    public string description;
    public Sprite icon;

    public int amount;
}