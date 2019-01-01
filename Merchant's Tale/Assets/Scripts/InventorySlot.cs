
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Inventory parentInventory;
    public Image icon;
    //public int index;
    Item item;

    public void AddItem(Item newItem)
    {
        item = newItem;
       // index = newItem.index;
        icon.sprite = item.icon;
       icon.enabled = true;
    }

    public void clearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
      //  index = -1;
    }

    public void UpdateSlot()
    {
        Debug.Log("item update");
        Debug.Log(parentInventory.items.Count);
        if (parentInventory.items[transform.GetSiblingIndex()] != null)
        {
            icon.sprite = parentInventory.items[transform.GetSiblingIndex()].icon;
            icon.enabled = true;
         }
        else
        {
            icon.enabled = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData != null && eventData.pointerDrag.GetComponent<ItemDragHandler>() != null)
        {
            Item droppedItem = parentInventory.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()];
            if (eventData.pointerDrag.transform.parent.name == gameObject.name)
            {
                return;
            }
            if (parentInventory.items[transform.GetSiblingIndex()] == null)
            {
                parentInventory.items[transform.GetSiblingIndex()] = droppedItem;
                parentInventory.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = null;
                parentInventory.OnItemChangedCallback.Invoke();
            }
            else
            {
                Item tempItem = parentInventory.items[transform.GetSiblingIndex()];
                parentInventory.items[transform.GetSiblingIndex()] = droppedItem;
                parentInventory.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = tempItem;
                parentInventory.OnItemChangedCallback.Invoke();
            }
        }
    }
 }
