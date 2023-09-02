using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Slider hunger;
    [SerializeField] Slider awareness;
    [SerializeField] EnemyStats stats;
    [SerializeField] GameObject camera;
    [SerializeField] Text abt;

    // Update is called once per frame
    void Update()
    {
        canvas.transform.rotation = Quaternion.LookRotation(transform.position - camera.transform.position);

        CheckAwareness();
        abt.text = "Behaviour: " + stats.BT +  "\n";
        abt.text += "Speech: " + stats.Speech;

        //updates hunger ui
        hunger.value = stats.hungerAmount;
    }

    //updates the awareness UI
    void CheckAwareness()
    {
        awareness.value = stats.awarenessAmount;
        switch (stats.awareness)
        {
            case EnemyStats.Awareness.NORMAL:
                awareness.image.color = new Color(1, 1, 1, 1);
                break;
            case EnemyStats.Awareness.SUSPICIOUS:
                awareness.image.color = new Color(1, 1, 0, 1);
                break;
            case EnemyStats.Awareness.AWARE:
                awareness.image.color = new Color(1, 0.5f, 0, 1);
                break;
            case EnemyStats.Awareness.SPOTTED:
                awareness.image.color = new Color(1, 0, 0, 1);
                break;
            default:
                break;
        }
    }
}
