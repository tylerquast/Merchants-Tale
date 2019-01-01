using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Transform originalParent;
    private InventorySlot mytest;
    public bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        mytest = transform.parent.GetComponent<InventorySlot>();

        if (mytest.parentInventory.items[transform.parent.GetSiblingIndex()] != null)
        {
            Debug.Log("begindrag");
            isDragging = true;
            originalParent = transform.parent;
            transform.SetParent(transform.parent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;

        }
    }

    public void OnDrag(PointerEventData eventData)
    {

        if (mytest.parentInventory.items[originalParent.transform.GetSiblingIndex()] != null && eventData.button == PointerEventData.InputButton.Left)
        {
             Debug.Log("Ondrag");
            transform.position = Input.mousePosition;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && isDragging)
        {
            Debug.Log("OnpointerUp");
            isDragging = false;
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }


}
