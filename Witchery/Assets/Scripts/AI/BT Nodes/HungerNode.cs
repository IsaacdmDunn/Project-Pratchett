using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerNode : Node
{
    EnemyStats stats;
    public HungerNode(EnemyStats _stats)
    {
        stats = _stats;
    }

    public override NodeStatus RunBehaviour()
    {
        //if hungry return sucess
        if (stats.hungerAmount > stats.hungerThreshold)
        {
            stats.Speech = "I'm hungry";
            stats.BT = "Hungry";

            return NodeStatus.success;
        }
        return NodeStatus.failure;
    }
}
