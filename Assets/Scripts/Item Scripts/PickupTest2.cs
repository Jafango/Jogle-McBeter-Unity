using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupTest2 : MonoBehaviour, ICollectable
{
    public static event HandleTestItem2Collected onTest2ItemCollected;
    public delegate void HandleTestItem2Collected(Item item); //does the add item
    public Item itemData;


    public void Collect()
    {
        Destroy(gameObject);
        onTest2ItemCollected?.Invoke(itemData);
    }
}
