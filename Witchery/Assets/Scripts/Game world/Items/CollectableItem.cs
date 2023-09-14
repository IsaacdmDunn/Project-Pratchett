using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public InventoryStorage inventory;

    [SerializeField] int amount = 1;
    [SerializeField] public ItemType item;

    private void Awake()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent<InventoryStorage>();
    }
    private void OnTriggerStay(Collider other)
    {
        //if player in near object 
        if (other.tag == "Player")
        {
            //if its foragable and player pressed E then add item to inventory
            if (Input.GetKey(KeyCode.E))
            {
                Forage();
            }
        }
    }

    //removes item
    public void Forage()
    {
        inventory.AddItem(item, amount);
        gameObject.SetActive(false);
    }
}
