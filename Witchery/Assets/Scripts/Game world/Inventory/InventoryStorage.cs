using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStorage : MonoBehaviour
{
    [System.Serializable]
    public class Slot
    {
        public ItemType itemType = null;
        public int amount;
    }

    public bool inventoryUpdateRequired = false;
    [SerializeField]public InventoryStorage otherInventory = null;
    public List<Slot> slots;
    [SerializeField] int slotLimit;

    public void Start()
    {
        
    }

    //add new item to inventory
    public void AddItem(ItemType itemToAdd, int amount)
    {
        inventoryUpdateRequired = true;
        
        //check item exists if so add amount and return
        for (int i = 0; i < slots.Count; i++)
        {
            
            if (slots[i].itemType == itemToAdd)
            {
                
                slots[i].amount += amount;
                return;
            }
        }

        //if there is room in inventory add new item
        if (slots.Count < slotLimit)
        {
            Slot slot = new Slot();
            slot.amount = amount;
            slot.itemType = itemToAdd;
            slots.Add(slot);
        }
        

    }

    //moves items from one inventory to another
    public void MoveItem(int slotID, int amount)
    {
        inventoryUpdateRequired = true;
        slots[slotID].amount -= 1;
        otherInventory.AddItem(slots[slotID].itemType, 1);
        if (slots[slotID].amount == 0)
        {
            slots.RemoveAt(slotID);
        }
    }

    //moves whole stack of items
    public void MoveStack(int slotID)
    {
        inventoryUpdateRequired = true;
        otherInventory.AddItem(slots[slotID].itemType, slots[slotID].amount);
        slots[slotID].amount = 0;
        slots.RemoveAt(slotID);
    }


    
}
