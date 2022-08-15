using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotEvent : MonoBehaviour
{
    public int id;

    //if slot is hovered over update description
    public void Hover()
    {
        gameObject.transform.parent.GetComponentInParent<PlayerInventoryUI>().SetPlayerInventoryDecription(id);
    }

    //if slot is clicked on move item if l. shift is also pressed move whole stack
    public void Click()
    {
        if (id < gameObject.transform.parent.GetComponentInParent<InventoryUI>().inv.slots.Count)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                gameObject.transform.parent.GetComponentInParent<InventoryUI>().inv.MoveStack(id);
            }
            else
            {
                gameObject.transform.parent.GetComponentInParent<InventoryUI>().inv.MoveItem(id, 1);
            }
        }
    }
}
