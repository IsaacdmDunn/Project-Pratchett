using UnityEngine;

/// <summary>
/// creates dialogue for a character
/// </summary>
[CreateAssetMenu(menuName = "Dialog/Dialog")]
public class Dialog : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialog;
    [SerializeField] private Responce[] responces;

    public string[] Dialogue => dialog;
    public Responce[] Responces => responces;
}
