using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Transform originalParent;
    public bool isDragging;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Inventory.instance.items[transform.parent.GetSiblingIndex()] != null)
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
        if (Inventory.instance.items[originalParent.transform.GetSiblingIndex()] != null && eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = Input.mousePosition;
        }
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && isDragging)
        {
            isDragging = false;
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }


}
