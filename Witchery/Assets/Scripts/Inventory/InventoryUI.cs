using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<Text> itemTxt;
    public List<Image> iconIMG;
    public InventoryStorage inv;
    public GameObject inventoryUI;
    public GameObject inventoryUITitleTxt;
    public Sprite defaultIconImage;

    public GameObject SlotPrefab;
    public CameraLook cameraLook;

    [SerializeField] protected int sizeX = 5;
    [SerializeField] protected int sizeY = 4;

    //check item in inventory slot
    protected void CheckItemType(int slotID)
    {
        //if potion set color to potion mixture color
        if (inv.slots[slotID].itemType.GetType() == typeof(ItemPotion))
        {
            ItemPotion tempPotion = (ItemPotion)inv.slots[slotID].itemType;
            iconIMG[slotID].color = new Color (tempPotion.potionColour.r, tempPotion.potionColour.g, tempPotion.potionColour.b, 1f);
        }
        //else reset color
        else
        {
            iconIMG[slotID].color = new Color(1f, 1f, 1f, 1f);
        }
    }

    //locks camera and cursor
    public void LockCursor()
    {

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
    

    ////updates inventory UI when item is picked up
    ////TODO make it change a specific slot for efficientcy
    //public void UpdateInventory()
    //{
    //    int slotID;
    //    for (int x = 0; x < sizeX; x++)
    //    {
    //        for (int y = 0; y < sizeY; y++)
    //        {
    //            slotID = (x * sizeY) + y;
    //            if (slotID < inv.slots.Count)
    //            {
    //                itemTxt[slotID].text = inv.slots[slotID].amount.ToString();
    //                iconIMG[slotID].sprite = inv.slots[slotID].itemType.icon;
    //            }
    //        }
    //    }
    //}
}
