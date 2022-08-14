using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronUI : InventoryUI
{
    
    [SerializeField] Cauldren cauldron;
    [SerializeField] int cauldrenDisplayLimit =10;
    public bool isEmptying = false;
    /// <summary>
    /// TODO make big inventory with optimised for size and scrolling
    /// </summary>

    public void Start() 
    {
        for (int slotID = 0; slotID < cauldrenDisplayLimit; slotID++)
        {
            if (slotID< cauldrenDisplayLimit)
            {
                GameObject slotGO = Instantiate(SlotPrefab);
                slotGO.transform.SetParent(inventoryUI.gameObject.transform);
                slotGO.name = "inventorySlot " + (slotID).ToString();
                itemTxt.Add(slotGO.GetComponentInChildren<Text>());
                iconIMG.Add(slotGO.GetComponentInChildren<Image>());
            }
            
        }

        
    }

    public void UpdateInventory()
    {
        if (inv.slots.Count > 0)
        {
            if (inv.slots[0].itemType.GetType() == typeof(ItemIngredient))
            {
                cauldron.cauldrenMixture.AddIngredient((ItemIngredient)inv.slots[0].itemType);
                inv.slots.RemoveAt(0);
            }
            else
            {
                inv.MoveStack(inv.slots[0].itemType.id);
                inv.slots.RemoveAt(0);
            }

        }
        
        for (int slotID = 0; slotID < cauldrenDisplayLimit; slotID++)
        {
            if (slotID < cauldrenDisplayLimit && cauldron.cauldrenMixture.mixture.Count > slotID)
            {
                itemTxt[slotID].text = cauldron.cauldrenMixture.mixture[slotID].displayName + " \n " + cauldron.cauldrenMixture.volume[slotID];
                iconIMG[slotID].sprite = cauldron.cauldrenMixture.mixture[slotID].icon;
            }
            if (cauldron.cauldrenMixture.mixture.Count-1 < slotID)
            {
                itemTxt[slotID].text = "";
                iconIMG[slotID].sprite = defaultIconImage;
            }

        }

        cauldron.cauldrenMixture.updateUIRequired = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            inventoryUITitleTxt.SetActive(!inventoryUITitleTxt.activeSelf);
        }

        if (inv.slots.Count>0)
        {
            UpdateInventory();
        }

        if (cauldron.cauldrenMixture.updateUIRequired)
        {
            UpdateInventory();

        }

        if (isEmptying)
        {
            for (int ingredientVolume = 0; ingredientVolume < cauldron.cauldrenMixture.volume.Count; ingredientVolume++)
            {
                cauldron.cauldrenMixture.volume[ingredientVolume] -= (0.01f  * cauldron.cauldrenMixture.volume[ingredientVolume]);
            }
        }
    }

    public void EmptyCauldron() 
    {
        isEmptying = !isEmptying;
    }
}
