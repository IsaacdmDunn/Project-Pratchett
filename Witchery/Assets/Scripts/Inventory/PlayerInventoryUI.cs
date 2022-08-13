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

    public CameraLook cameraLook;
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
        

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inventoryUITitleTxt.SetActive(!inventoryUITitleTxt.activeSelf);
            descriptionUI.SetActive(!descriptionUI.activeSelf);
            cameraLook.enabled = !cameraLook.enabled;
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inventoryUITitleTxt.SetActive(!inventoryUITitleTxt.activeSelf);
            cameraLook.enabled = !cameraLook.enabled;
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }

        if (inv.inventoryUpdateRequired)
        {
            UpdateInventory();
        }
        
    }

    

    public void SetPlayerInventoryDecription(int slotID)
    {
        if (slotID < inv.slots.Count)
        {
            descriptionTitleTxt.text = inv.slots[slotID].itemType.displayName;
            descriptionTXT.text = inv.slots[slotID].itemType.description;
        }
        
    }
}
