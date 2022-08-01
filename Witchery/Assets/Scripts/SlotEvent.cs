using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotEvent : MonoBehaviour
{
    public int id;

    public void Hover()
    {
        gameObject.transform.parent.GetComponentInParent<PlayerInventoryUI>().SetPlayerInventoryDecription(id);
    }
}
