
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
        //Debug.Log("item update");
        //Debug.Log(parentInventory.items.Count);
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
            Debug.Log("Ondrop");
            Inventory theirInventory = eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetComponent<InventorySlot>().parentInventory;
            // Their Inventory
            Item droppedItem = theirInventory.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()];
            if (eventData.pointerDrag.transform.parent.name == gameObject.name)
            {
                return;
            } // ours
            if (parentInventory.items[transform.GetSiblingIndex()] == null)
            {
                //our inventory
                parentInventory.items[transform.GetSiblingIndex()] = droppedItem;
                // Their Inventory
                theirInventory.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = null;
                // Their Inventory & ours (make a conditional later to save code) 
                parentInventory.OnItemChangedCallback.Invoke();
                theirInventory.OnItemChangedCallback.Invoke();
            }
            else
            {
                //ours
                Item tempItem = parentInventory.items[transform.GetSiblingIndex()];
                //ours
                parentInventory.items[transform.GetSiblingIndex()] = droppedItem;
                //theirs
                theirInventory.items[eventData.pointerDrag.GetComponent<ItemDragHandler>().transform.parent.GetSiblingIndex()] = tempItem;
                //both
                parentInventory.OnItemChangedCallback.Invoke();
                theirInventory.OnItemChangedCallback.Invoke();
            }
        }
    }
 }
