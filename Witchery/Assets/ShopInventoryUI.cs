using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventoryUI : InventoryUI
{
    
    /// <summary>
    /// TODO make big inventory with optimised for size and scrolling
    /// </summary>

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inventoryUITitleTxt.SetActive(!inventoryUITitleTxt.activeSelf);
        }

        if (inv.inventoryUpdateRequired)
        {
            UpdateInventory();
        }

    }

   
}
