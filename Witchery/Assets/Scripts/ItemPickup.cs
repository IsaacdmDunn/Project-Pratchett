using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryStorage inventory;
    [SerializeField] public ItemType item;
    [SerializeField] Material foragedMAT;
    bool foragable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
        if(other.tag == "Player")
        {

            if (foragable && Input.GetKey(KeyCode.E))
            {
                inventory.AddItem(item, 1);
                foragable = false;
                gameObject.GetComponent<MeshRenderer>().material = foragedMAT;
                //slot = new InventoryStorage.Slot();
                //slot.itemType = item;
                //slot.amount += 1;
                //inventory.slots.Add(slot);
                //Debug.Log("dwkajdioha");
            }
        }
    }
}
