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

    public void Start()
    {
        //for (int i = 0; i < slotLimit; i++)
        //{
        //    slots.Add(null);
        //}
    }

    public void AddItem(ItemType itemToAdd, int amount)
    {
        inventoryUpdateRequired = true;
        for (int i = 0; i < slots.Count; i++)
        {
            
            if (slots[i].itemType == itemToAdd)
            {
                
                slots[i].amount += amount;
                return;
            }
        }
        if (slots.Count < slotLimit)
        {
            Slot slot = new Slot();
            slot.amount = amount;
            slot.itemType = itemToAdd;
            slots.Add(slot);
        }
        

    }

    public List<Slot> slots;
    [SerializeField] int slotLimit;
}
