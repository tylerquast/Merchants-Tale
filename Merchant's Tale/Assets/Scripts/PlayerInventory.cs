using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : Inventory
{
    public static PlayerInventory instance;

    private void Awake()
    {
         instance = this;
    }
    
}
