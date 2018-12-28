using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    private void Awake()
    {
        instance = this;
    }

    public int space = 20;
    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangedCallback;
    public List<Item> items = new List<Item>();


    public void add(Item item)
    {
        items.Add(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
    public void remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangedCallback != null)
            OnItemChangedCallback.Invoke();
    }
}
