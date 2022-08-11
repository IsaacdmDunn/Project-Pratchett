using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potions/Recipe")]
public class Recipe : ScriptableObject
{
    [SerializeField] public List<int> ingredentIDs;
    [SerializeField] public ItemIngredient outputIngredient;
    int correctIngredientCount = 0;
    public bool CheckIngredients(List<int> _ingredentIDs)
    {
        
        for (int i = 0; i < ingredentIDs.Count; i++)
        {
            if (_ingredentIDs.Contains(ingredentIDs[i]))
            {
                
                correctIngredientCount++;
            }

            if (correctIngredientCount == ingredentIDs.Count)
            {
                correctIngredientCount = 0;
                return true;
            }
        }

        return false;
    }
}
