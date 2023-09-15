using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCStatsUI : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Slider hunger;
    [SerializeField] Slider awareness;
    [SerializeField] NPCStats stats;
    [SerializeField] GameObject camera;
    [SerializeField] Text abt;

    // Update is called once per frame
    void Update()
    {
        //rotates UI towards player
        canvas.transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);

        //changes awareness UI
        CheckAwareness();

        //displays current beahaviour
        abt.text = "Behaviour: " + stats.BT +  "\n";
        abt.text += "Speech: " + stats.Speech;

        //updates hunger ui
        hunger.value = stats.hungerAmount;
    }

    //updates the awareness UI with colours for awareness level
    void CheckAwareness()
    {
        awareness.value = stats.awarenessAmount;
        switch (stats.awareness)
        {
            case NPCStats.Awareness.NORMAL:
                awareness.image.color = new Color(1, 1, 1, 1);
                break;
            case NPCStats.Awareness.SUSPICIOUS:
                awareness.image.color = new Color(1, 1, 0, 1);
                break;
            case NPCStats.Awareness.AWARE:
                awareness.image.color = new Color(1, 0.5f, 0, 1);
                break;
            case NPCStats.Awareness.SPOTTED:
                awareness.image.color = new Color(1, 0, 0, 1);
                break;
            default:
                break;
        }
    }
}
