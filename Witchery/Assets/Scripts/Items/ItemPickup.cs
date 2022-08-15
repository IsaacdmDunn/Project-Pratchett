using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryStorage inventory;
    [SerializeField] public ItemType item;
    [SerializeField] Material foragedMAT;
    [SerializeField] Material unforagedMAT;
    bool foragable = true;
    [SerializeField] int amount = 1;
    // Start is called before the first frame update
    void Start()
    {
        unforagedMAT = gameObject.GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //if player in near object 
        if(other.tag == "Player")
        {
            //if its foragable and player pressed E then add item to inventory
            if (foragable && Input.GetKey(KeyCode.E))
            {
                inventory.AddItem(item, amount);
                foragable = false;
                gameObject.GetComponent<MeshRenderer>().material = foragedMAT;
            }
        }
    }
}
