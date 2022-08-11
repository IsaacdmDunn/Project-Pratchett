using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient")]
public class ItemIngredient : ItemType
{
    [SerializeField] public Color potionColour;
    [SerializeField] List<Effect> ingredientEffects;
    [SerializeField] float potentcy;
    [SerializeField] float effectLength;
    enum Effect
    {
        None,
        HealthRegen,
        ManaRegen,
        DamageIncrease,
    }

    
}


