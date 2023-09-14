using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryStorage inventory;
    [SerializeField] public ItemType item;
    [SerializeField] Material foragedMAT;
    [SerializeField] Material unforagedMAT;
    public bool foragable = true;
    [SerializeField] int amount = 1;
    [SerializeField] int foodAmount = 50;
    int timer = 1200;
    // Start is called before the first frame update
    void Start()
    {
        unforagedMAT = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        timer--;
        if (timer < 0)
        {
            ResetItem();
            timer = 1200;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //if player in near object 
        if(other.tag == "Player")
        {
            //if its foragable and player pressed E then add item to inventory
            if (foragable && Input.GetKey(KeyCode.E))
            {
                Forage();
            }
        }
    }

    //removes item
    public void Forage()
    {
        inventory.AddItem(item, amount);
        foragable = false;
        gameObject.GetComponent<MeshRenderer>().material = foragedMAT;
    }

    public int Eat()
    {

        foragable = false;
        gameObject.GetComponent<MeshRenderer>().material = foragedMAT;
        return foodAmount;
    }

    public void ResetItem()
    {
        gameObject.GetComponent<MeshRenderer>().material = unforagedMAT;
        foragable = true;
        amount = 1;
    }
}
