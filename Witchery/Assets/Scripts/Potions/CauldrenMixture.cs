using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldrenMixture : MonoBehaviour
{
    [SerializeField] List<ItemIngredient> mixture;
    public List<int> itemIngredientIDs = new List<int>();
    public List<float> volume = new List<float>();
    [SerializeField] float totalVolume = 0f;
    [SerializeField] Cauldren cauldren;
    public List<Recipe> recipes = new List<Recipe>();
    float temperature =0;
    [SerializeField] float mixRate =0.01f;
    public Color liquidColor = new Color(255, 255, 255, 255);

    public void Start()
    {
        recipes.AddRange(Resources.LoadAll<Recipe>("Recipes/"));
        recipes.RemoveAt(0);
        foreach (ItemIngredient item in mixture)
        {
            itemIngredientIDs.Add(item.id);
            volume.Add(1f);
            totalVolume += 1f;
        }
    }

    public void LateUpdate()
    {
       MixingPotion();
       SetPotionColour();
    }
    
    //searches
    public void changeIngredientVolume(int id)
    {
        
    }

    public void AddIngredient(ItemIngredient itemToAdd)
    {
        mixture.Add(itemToAdd);
        foreach (ItemIngredient ingredient in mixture)
        {
            itemIngredientIDs.Add(ingredient.id);
            volume.Add(1f);
            totalVolume += 1f;
        }
    }

    //removes ingredients when volume is too low
    public void RemoveEmptyIngredients()
    {

        for (int mixtureCounter = 0; mixtureCounter < mixture.Count; mixtureCounter++)
        {
            if (volume[mixtureCounter] < 0.00001f)
            {
                volume.RemoveAt(mixtureCounter);
                itemIngredientIDs.Remove(mixture[mixtureCounter].id);
                mixture.RemoveAt(mixtureCounter);
            }
        }
    }
 
    //checks if a potions can be mixed into new potion
    public void MixingPotion()
    {
        RemoveEmptyIngredients();

        //each recipe 
        foreach (Recipe recipe in recipes)
        {
            //if recipe is complete 
            
            if (recipe.CheckIngredients(itemIngredientIDs))
            {
                Debug.Log(itemIngredientIDs.Count);
                //if mixture does not already contain output ingredient
                if (!mixture.Contains(recipe.outputIngredient))
                {
                    mixture.Add(recipe.outputIngredient);
                    itemIngredientIDs.Add(recipe.outputIngredient.id);
                    volume.Add(mixRate * recipe.ingredentIDs.Count);
                }

                for (int mixtureCounter = 0; mixtureCounter < mixture.Count; mixtureCounter++)
                {
                    if (volume[mixtureCounter] >= mixRate)
                    {
                        if (recipe.ingredentIDs.Contains(itemIngredientIDs[mixtureCounter]))
                        {
                            volume[mixtureCounter] -= mixRate;
                        }
                        else
                        {
                            volume[mixtureCounter] += mixRate * recipe.ingredentIDs.Count;
                        }
                    }
                    
                }

                
            }
        }
    }

    public void SetPotionColour()
    {
        liquidColor = new Vector4(0f, 0f, 0f, 0f);
        for (int i = 0; i < mixture.Count; i++)
        {
            liquidColor += mixture[i].potionColour * volume[i] / totalVolume;
        }
    }
}
