using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopInventoryUI : InventoryUI
{

    /// <summary>
    /// TODO make big inventory with optimised for size and scrolling
    /// </summary>
    private void Start()
    {
        int slotID;
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                slotID = (x * sizeY) + y;
                GameObject slotGO = Instantiate(SlotPrefab);
                slotGO.transform.SetParent(inventoryUI.gameObject.transform);
                slotGO.name = "inventorySlot " + (slotID).ToString();
                slotGO.GetComponent<SlotEvent>().id = slotID;
                itemTxt.Add(slotGO.GetComponentInChildren<Text>());
                iconIMG.Add(slotGO.GetComponentInChildren<Image>());
                if (slotID < inv.slots.Count)
                {
                    itemTxt[slotID].text = inv.slots[slotID].amount.ToString();
                    iconIMG[slotID].sprite = inv.slots[slotID].itemType.icon;
                }

            }
        }
    }
    //updates inventory UI when item is picked up
    //TODO make it change a specific slot for efficientcy
    public void UpdateInventory()
    {
        int slotID;
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                slotID = (x * sizeY) + y;
                if (slotID < inv.slots.Count)
                {
                    itemTxt[slotID].text = inv.slots[slotID].amount.ToString();
                    iconIMG[slotID].sprite = inv.slots[slotID].itemType.icon;
                }

                itemTxt[inv.slots.Count].text = null;
                iconIMG[inv.slots.Count].sprite = defaultIconImage;

            }
        }
    }
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
