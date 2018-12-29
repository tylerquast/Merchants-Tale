
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsContainer;
    Inventory inventory;
    // Start is called before the first frame update
    InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;
        slots = itemsContainer.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            /*
            if (inventory.items[i] != null)
                slots[i].AddItem(inventory.items[i]);
            else
                slots[i].clearSlot();
                */
            slots[i].UpdateSlot();


        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
