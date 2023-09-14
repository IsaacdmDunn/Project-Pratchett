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

    [SerializeField] protected int sizeX = 5;
    [SerializeField] protected int sizeY = 4;

    [SerializeField] public UIManager uIManager;

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

}
