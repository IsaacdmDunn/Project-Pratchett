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
