using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixtureRecipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    enum Ingredient
    {
        dandelion = 1,
        dockleaf,
        ibuprofin,
    }

    public int CheckMixture(int a, int b)
    {
        switch (a)
        {
            default:
                return -1;
                break;
            case (int)Ingredient.dandelion:
                switch (b)
                {
                    default:
                        return -1;
                        break;
                    
                    case (int)Ingredient.dockleaf:
                        //test health potion
                        return (int)Ingredient.ibuprofin;
                        break;
                }
                break;
        }
    }

}
