using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInventoryUI : InventoryUI
{
    //public GameObject prefab;
    public GameObject descriptionUI;
    public Text descriptionTXT;
    public Text descriptionTitleTxt;

    private void Start()
    {
        GenerateSlots();
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
                    CheckItemType(slotID);
                }

                itemTxt[inv.slots.Count].text = null;
                iconIMG[inv.slots.Count].sprite = defaultIconImage;

            }
        }
    }
    public void Update()
    {
        
        //inventory open
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inventoryUITitleTxt.SetActive(!inventoryUITitleTxt.activeSelf);
            descriptionUI.SetActive(!descriptionUI.activeSelf);

            LockCursor();
        }

        //update UI
        if (inv.inventoryUpdateRequired)
        {
            UpdateInventory();
        }
        
    }

    //sets the description of an inventory item
    public void SetPlayerInventoryDecription(int slotID)
    {
        if (slotID < inv.slots.Count)
        {
            descriptionTitleTxt.text = inv.slots[slotID].itemType.displayName;
            descriptionTXT.text = inv.slots[slotID].itemType.description;
        }
        
    }

    //generates slots based on slot limit
    void GenerateSlots()
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
}
