using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public InventoryStorage inv;
    [SerializeField] ItemIngredient itemToAdd;
    public Light light;
    public void No()
    {
        inv.AddItem(itemToAdd, 30);

    }
    public void Yes()
    {
        light.intensity = 10f;
    }
}
