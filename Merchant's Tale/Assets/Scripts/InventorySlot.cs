
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
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
}
