
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
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
        if (Inventory.instance.items[transform.GetSiblingIndex()] != null)
        {
            icon.sprite = Inventory.instance.items[transform.GetSiblingIndex()].icon;
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
            Item droppedItem = Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()];
            if (eventData.pointerDrag.transform.parent.name == gameObject.name)
            {
                return;
            }
            if (Inventory.instance.items[transform.GetSiblingIndex()] == null)
            {
                Inventory.instance.items[transform.GetSiblingIndex()] = droppedItem;
                Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = null;
                Inventory.instance.OnItemChangedCallback.Invoke();
            }
            else
            {
                Item tempItem = Inventory.instance.items[transform.GetSiblingIndex()];
                Inventory.instance.items[transform.GetSiblingIndex()] = droppedItem;
                Inventory.instance.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = tempItem;
                Inventory.instance.OnItemChangedCallback.Invoke();
            }
        }
    }
 }
