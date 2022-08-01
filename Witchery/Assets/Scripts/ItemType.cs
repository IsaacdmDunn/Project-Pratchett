using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(menuName = "Item Type")]
public class ItemType : ScriptableObject
{
    public int id;
    public string displayName;
    public string description;
    public Sprite icon;
    public GameObject prefab;
}
