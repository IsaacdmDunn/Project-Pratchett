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

//public class SlotEvent : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
//{
//    public int id;

//    //Detect if a click occurs
//    public void OnPointerClick(PointerEventData pointerEventData)
//    {
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            gameObject.transform.parent.GetComponentInParent<PlayerInventoryUI>().inv.MoveStack(id);
//        }
//        else
//        {
//            gameObject.transform.parent.GetComponentInParent<PlayerInventoryUI>().inv.MoveItem(id, 1);
//        }
//    }

//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        gameObject.transform.parent.GetComponentInParent<PlayerInventoryUI>().SetPlayerInventoryDecription(id);
//    }
//}
