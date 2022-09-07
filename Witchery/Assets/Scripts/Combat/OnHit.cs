using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit : MonoBehaviour
{
    public bool isHit = false;
    public GameObject weapon;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            weapon = other.gameObject;
            isHit = true;
        }
        
    }
}
