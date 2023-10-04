using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
    public Image icon;
    public Sprite test;

    public Slot slot;

    private void Start()
    {
        //icon = transform.GetChild(0).gameObject.GetComponent<Image>();
        //icon = transform.GetChild(0).gameObject;
    }
    public void ClearSlot()
    {
        icon.GetComponent<Image>().enabled = false;
        //icon.enabled = false;
    }

    public void EnableSlot()
    {
        this.icon.enabled = true;
        //icon.enabled = true;
    }

    public void DrawSlot(Sprite tempSprite)
    {
        //icon.GetComponent<Image>().enabled = true;
        //icon.GetComponent<Image>().sprite = test;
        this.icon.sprite = tempSprite;
        //this.slot = newSlot;
        //icon.GetComponent<Image>().enabled = true;
        //icon.SetActive(true);
        //icon.gameObject.SetActive(true);
        //gameObject.SetActive(true);

        //Debug.Log("is enabled " + icon.GetComponent<Image>().isActiveAndEnabled);
        //icon.sprite = sprite;
        //icon.GetComponent<Image>().sprite = tempSprite;
        //Debug.Log("The correct sprite should be " + icon.GetComponent<Image>().sprite);
    }
}
