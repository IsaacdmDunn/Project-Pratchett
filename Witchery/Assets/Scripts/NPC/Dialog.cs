using UnityEngine;

/// <summary>
/// creates dialogue for a character
/// </summary>
[CreateAssetMenu(menuName = "Dialog/Dialog")]
public class Dialog : ScriptableObject
{
    public enum Emotions
    {
        NONE = 0,
        HAPPY,
        CONFUSED,
        SHOCKED,
        FRUSTRATED
    }
    [SerializeField] [TextArea] private string[] dialog;
    [SerializeField] private Responce[] responces;
    [SerializeField] private Emotions[] emotes;

    public string[] Dialogue => dialog;
    public Responce[] Responces => responces;
    public Emotions[] Emotes => emotes;
}
