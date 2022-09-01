using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CauldronUI : InventoryUI
{

    [SerializeField] Cauldren cauldron;
    [SerializeField] int cauldrenDisplayLimit = 10;
    public bool isEmptying = false;
    [SerializeField] Sprite potionBottleSprite;
    [SerializeField] InputField potionName;
    /// <summary>
    /// TODO make big inventory with optimised for size and scrolling
    /// </summary>

    public void Start()
    {
        GenerateSlots();


    }

    //update UI sprites and text
    public void UpdateInventory()
    {
        for (int slotID = 0; slotID < cauldrenDisplayLimit; slotID++)
        {
            if (slotID < cauldrenDisplayLimit && cauldron.cauldrenMixture.mixture.Count > slotID)
            {
                itemTxt[slotID].text = cauldron.cauldrenMixture.mixture[slotID].displayName + " \n " + Mathf.RoundToInt(cauldron.cauldrenMixture.volume[slotID] * 100) + "ml";
                iconIMG[slotID].sprite = cauldron.cauldrenMixture.mixture[slotID].icon;
            }
            if (cauldron.cauldrenMixture.mixture.Count - 1 < slotID)
            {
                itemTxt[slotID].text = "";
                iconIMG[slotID].sprite = defaultIconImage;
            }

        }

        cauldron.cauldrenMixture.updateUIRequired = false;
    }

    public void Update()
    {
        //if item was put into the cauldron check if its an ingredient if so add to the mixture if not return to player inventory
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
            }
        }

        //update UI
        if (cauldron.cauldrenMixture.updateUIRequired)
        {
            UpdateInventory();

        }

        //if the cauldron is emptying
        if (isEmptying)
        {
            for (int ingredientVolume = 0; ingredientVolume < cauldron.cauldrenMixture.volume.Count; ingredientVolume++)
            {
                cauldron.cauldrenMixture.volume[ingredientVolume] -= (0.01f * cauldron.cauldrenMixture.volume[ingredientVolume]);
            }
        }
    }

    //button for if the cauldron should be emptied
    public void EmptyCauldron()
    {
        isEmptying = !isEmptying;
    }

    //serialises the elements of a potions and creates an item for it to add to the inventory
    public void MakePotion()
    {
        float tempTotal = cauldron.cauldrenMixture.totalVolume;
        List<float> potionVolumes = new List<float>();
        //remove potion from cauldron mixture NEEDS TWEAKING taking more than needed
        for (int ingredientVolume = 0; ingredientVolume < cauldron.cauldrenMixture.volume.Count; ingredientVolume++)
        {
            float amountToRemove = cauldron.cauldrenMixture.volume[ingredientVolume] / tempTotal;
            potionVolumes.Add(amountToRemove);
            cauldron.cauldrenMixture.volume[ingredientVolume] -= amountToRemove;
            cauldron.cauldrenMixture.totalVolume -= amountToRemove;
            //cauldron.cauldrenMixture.volume[ingredientVolume] -= (1f / cauldron.cauldrenMixture.volume[ingredientVolume] / (cauldron.cauldrenMixture.volume.Count +1));



        }

        //makes new potion from mixture
        ItemPotion potionToMake = new ItemPotion();

        //set potion name
        if (potionName.text == "")
        {
            potionToMake.displayName = "New Potion";
        }
        else
        {
            potionToMake.displayName = potionName.text;
        }
        
        //set values for potion
        potionToMake.potionColour = cauldron.cauldrenMixture.liquidColor;
        potionToMake.volumes = potionVolumes;
        potionToMake.ingredientEffects = cauldron.cauldrenMixture.mixture;
        potionToMake.icon = potionBottleSprite;

        //set description for potion 

        //each effect
        potionToMake.description = "Effects: \n";
        for (int i = 0; i < potionToMake.volumes.Count; i++)
        {
            for (int j = 0; j < potionToMake.ingredientEffects[i].ingredientEffects.Count; j++)
            {
                potionToMake.description += "Gives " + potionToMake.ingredientEffects[i].potentcy + " " + potionToMake.ingredientEffects[i].ingredientEffects[j];
                if (potionToMake.ingredientEffects[i].effectLength > 0)
                {
                    potionToMake.description += " lasts for " + potionToMake.ingredientEffects[i].effectLength + " seconds";
                }
                potionToMake.description += "\n";
            }
        }

        //each ingredient
        potionToMake.description += "Ingredients: \n";
        for (int i = 0; i < potionToMake.volumes.Count; i++)
        {
                potionToMake.description += potionToMake.ingredientEffects[i].displayName + " " + (potionToMake.volumes[i] * 100) + "%";
                potionToMake.description += "\n";
        }

        //add to inventory
        inv.AddItem(potionToMake, 1);
    }

    //generates slots based on slot limit
    void GenerateSlots()
    {
        for (int slotID = 0; slotID < cauldrenDisplayLimit; slotID++)
        {
            if (slotID < cauldrenDisplayLimit)
            {
                GameObject slotGO = Instantiate(SlotPrefab);
                slotGO.transform.SetParent(inventoryUI.gameObject.transform);
                slotGO.name = "inventorySlot " + (slotID).ToString();
                itemTxt.Add(slotGO.GetComponentInChildren<Text>());
                iconIMG.Add(slotGO.GetComponentInChildren<Image>());
            }

        }
    }
}
