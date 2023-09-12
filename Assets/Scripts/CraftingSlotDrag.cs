using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftingSlotDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Began Drag");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Ended Drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
    }
}
