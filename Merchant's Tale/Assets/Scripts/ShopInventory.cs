﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : Inventory
{
    public static ShopInventory instance;

    private void Awake()
    {
        instance = this;
    }
    
}
