using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// creates a responce for a dialogue option
/// </summary>

[System.Serializable]
public class Responce
{
    [SerializeField] private string responceText;
    [SerializeField] private Dialog dialog;

    public string ResponceText => responceText;
    public Dialog dialogObject => dialog;
}
