using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float hungerAmount = 0;
    public float hungerThreshold = 15;

    public float viewDistance = 30.0f;
    public float awarenessRise = 3f;
    public float awarenessFall = 0.5f;
    public float awarenessAmount = 0f;
    public Awareness awareness = Awareness.NORMAL;

    public float health = 100f;
    public enum Awareness
    {
        NORMAL,
        SUSPICIOUS,
        AWARE,
        SPOTTED
    }

    public void Update()
    {
        SetAwareness();
        UpdateHunger();
    }

    //sets the state of awareness of the agent and clamps the value
    private void SetAwareness()
    {
        if (awarenessAmount < 25f)
        {
            awareness = Awareness.NORMAL;
        }
        else if (awarenessAmount < 50f)
        {
            awareness = Awareness.SUSPICIOUS;
        }
        else if (awarenessAmount < 75)
        {
            awareness = Awareness.AWARE;
        }
        else
        {
            awareness = Awareness.SPOTTED;
        }

        if (awarenessAmount > awarenessFall)
        {
            awarenessAmount -= awarenessFall;
        }

        awarenessAmount = Mathf.Clamp(awarenessAmount, 0, 100);
    }

    //increases hunger and clamps value
    void UpdateHunger()
    {
        hungerAmount += 0.02f;
        hungerAmount = Mathf.Clamp(hungerAmount, 0, 100);

    }
}
