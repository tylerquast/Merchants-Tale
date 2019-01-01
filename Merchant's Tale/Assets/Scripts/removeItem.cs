using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeItem : MonoBehaviour
{
    public InventorySlot mySlot;
    public void removeItemFunction()
    {
       
        InventorySlot mytest = transform.parent.GetComponent<InventorySlot>();
        mytest.parentInventory.remove(mySlot.transform.GetSiblingIndex());
    }
}
