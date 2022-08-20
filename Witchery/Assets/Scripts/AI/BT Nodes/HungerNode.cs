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

    public override NodeState Evaluate()
    {
        //if hungry return sucess
        if (stats.hungerAmount > stats.hungerThreshold)
        {
            return NodeState.success;
        }
        return NodeState.failure;
    }
}
