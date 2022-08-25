
using UnityEngine;
using UnityEngine.UI;

public class NPC_UI : MonoBehaviour
{

    public Sprite[] emotes;
    public Image emoteUI;
    Emotions emotion;
    public bool emoteChanged = false;
    public enum Emotions
    {
        NONE=0,
        HAPPY,
        CONFUSED,
        SHOCKED,
        FRUSTRATED
    }

    public void ChangeEmote(Emotions _emotion)
    {
        emotion = _emotion;
        emoteChanged = true;
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (emoteChanged)
        {
            emoteChanged = false;

            switch (emotion)
            {
                case Emotions.NONE:
                    emoteUI.color = new Color(255,255,255,0);
                    emoteUI.sprite = emotes[0];
                    break;
                case Emotions.HAPPY:
                    emoteUI.color = new Color(255, 255, 255, 255);
                    emoteUI.sprite = emotes[1];
                    break;
                case Emotions.CONFUSED:
                    emoteUI.color = new Color(255, 255, 255, 255);
                    emoteUI.sprite = emotes[2];
                    break;
                case Emotions.SHOCKED:
                    emoteUI.color = new Color(255, 255, 255, 255);
                    emoteUI.sprite = emotes[3];
                    break;
                case Emotions.FRUSTRATED:
                    emoteUI.color = new Color(255, 255, 255, 255);
                    emoteUI.sprite = emotes[4];
                    break;
                default:
                    break;
            }
        }
    }
}
