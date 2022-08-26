using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemType : ScriptableObject
{
    public int id;
    public string displayName;
    [SerializeField][TextArea] public string description;
    public Sprite icon;
}
