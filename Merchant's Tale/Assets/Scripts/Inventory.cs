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
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
               // item.index = i;
                items[i] = item;
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();
                return;
            }
        }
        if (items.Count < space)
        {

           // item.index = items.Count;
            items.Add(item);
            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
            return;
        }
    }
    public void add(Item item, int index)
    {
        if (items[index] == null)
        {
            items[index] = item;
            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
            return;
        }
        else
        {
            Debug.Log("no space at item index");
        }
    }
    public void remove(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {
                items[i] = item;
                if (OnItemChangedCallback != null)
                    OnItemChangedCallback.Invoke();
                return;
            }
        }
    }
    public void remove(int index)
    {

        if (items[index] != null)
        {
            items[index] = null;
            if (OnItemChangedCallback != null)
                OnItemChangedCallback.Invoke();
            return;
        }
        else
        {
            Debug.Log("no item at space index");
        }
    }
}
