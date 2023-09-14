using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldrenMixture : MonoBehaviour
{
    [SerializeField] public List<ItemIngredient> mixture;
    public List<int> itemIngredientIDs = new List<int>();
    public List<float> volume = new List<float>();
    [SerializeField] public float totalVolume = 0f;
    [SerializeField] Cauldren cauldren;
    public List<Recipe> recipes = new List<Recipe>();
    float temperature =0;
    [SerializeField] float mixRate =0.01f;
    public Color liquidColor = new Color(255, 255, 255, 255);

    public bool updateUIRequired = false;

    public void Start()
    {
        //gets all recipes for potions
        recipes.AddRange(Resources.LoadAll<Recipe>("Recipes/"));
        recipes.RemoveAt(0);//sorts bug of recipe 0 being null

        //FOR TESTING REMOVE
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
    
    //adds ingredient to mixture 
    public void AddIngredient(ItemIngredient itemToAdd)
    {
        //if the ingredient is already in mixture increase the volume of the ingredient in cauldron
        if (itemIngredientIDs.Contains( itemToAdd.id))
        {
            for (int ingredientID= 0; ingredientID < mixture.Count; ingredientID++) 
            {
                if (mixture[ingredientID].id == itemToAdd.id)
                {
                    volume[ingredientID] += 1f;
                }
            }
        }
        //else add new ingredient to mixture
        else
        {
            mixture.Add(itemToAdd);
            itemIngredientIDs.Add(itemToAdd.id);
            volume.Add(1f);
        }
        
        //increase the total volume and tell UI to update
        totalVolume += 1f;
        updateUIRequired = true;
    }

    //removes ingredients when volume is too low
    public void RemoveEmptyIngredients()
    {
        //checks each ingredient in mixture and if its below the mixrate remove from mixture
        for (int mixtureCounter = 0; mixtureCounter < mixture.Count; mixtureCounter++)
        {
            if (volume[mixtureCounter] < mixRate)
            {
                volume.RemoveAt(mixtureCounter);
                itemIngredientIDs.Remove(mixture[mixtureCounter].id);
                mixture.RemoveAt(mixtureCounter);
                updateUIRequired = true;
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
                updateUIRequired = true;

                //if mixture does not already contain output ingredient
                if (!mixture.Contains(recipe.outputIngredient))
                {
                    mixture.Add(recipe.outputIngredient);
                    itemIngredientIDs.Add(recipe.outputIngredient.id);
                    volume.Add(mixRate * recipe.ingredentIDs.Count);
                    
                }

                //checks each ingredient to see if it needs increasing or deceasing based on its role
                //in the recipe and if theres enough volume to make potion
                //BUG: ONLY NEEDS ONE INGREDIENT TO MAKE A POTION
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

    //sets the color of the mixture to the weighted sum of eachs liquid volumes
    public void SetPotionColour()
    {
        liquidColor = new Vector4(0f, 0f, 0f, 0f);
        for (int i = 0; i < mixture.Count; i++)
        {
            liquidColor += mixture[i].potionColour * volume[i] / totalVolume;
        }
    }
}
