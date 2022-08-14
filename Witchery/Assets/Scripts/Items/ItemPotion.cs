using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Potions/Potion")]
public class ItemPotion : ItemType
{
    [SerializeField] public Color potionColour;
    [SerializeField] public List<ItemIngredient> ingredientEffects;
    [SerializeField] public List<float> volumes;

}
