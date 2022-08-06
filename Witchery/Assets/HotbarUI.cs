using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : InventoryUI
{
    public bool inventoryOpen = false;

    public void Update()
    {

        if (inv.inventoryUpdateRequired)
        {
            UpdateInventory();
        }

    }
}
