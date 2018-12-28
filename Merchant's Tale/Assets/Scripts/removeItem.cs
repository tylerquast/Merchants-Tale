using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeItem : MonoBehaviour
{
    public Inventory inventory = Inventory.instance;
    public InventorySlot mySlot;
    public void removeItemFunction()
    {
        inventory.remove(mySlot.index);

    }
}
