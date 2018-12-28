using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTestItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Inventory inventory = Inventory.instance;
    public Item item;
    public void addTestItemFuction()
    {
        inventory.add(item);

    }
    void Start()
    {
        
    }
    
}
