using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventory : MonoBehaviour
{

    public static ShopInventory instance;

    private void Awake()
    {
        instance = this;
    }

    public List<Item> items = new List<Item>();


    public void add(Item item)
    {
        items.Add(item);
    }
    public void remove(Item item)
    {
        items.Remove(item);
    }
}
