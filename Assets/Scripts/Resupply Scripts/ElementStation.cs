using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class ElementStation : MonoBehaviour
{
    [SerializeField] private Item elementData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Inventory>().Add(elementData);
        }
    }
}