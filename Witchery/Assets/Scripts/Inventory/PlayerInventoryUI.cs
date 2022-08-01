using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInventoryUI : MonoBehaviour
{
    //public GameObject prefab;
    public List<Text> itemTxt;
    public List<Image> iconIMG;
    public InventoryStorage inv;
    public GameObject inventoryUI;
    public GameObject descriptionUI;
    public Text descriptionTXT;
    public Text descriptionTitleTxt;

    public GameObject SlotPrefab;

    [SerializeField] int sizeX = 5;
    [SerializeField] int sizeY = 4;

    public void Start()
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

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            descriptionUI.SetActive(!descriptionUI.activeSelf);
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
            }
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
