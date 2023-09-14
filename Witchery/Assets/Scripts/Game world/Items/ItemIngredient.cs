using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ingredient")]
public class ItemIngredient : ItemType
{
    [SerializeField] public Color potionColour;
    [SerializeField] public List<Effect> ingredientEffects;
    [SerializeField] public float potentcy;
    [SerializeField] public float effectLength;
    public enum Effect
    {
        None,
        HealthRegen,
        ManaRegen,
        DamageIncrease,
    }

}


