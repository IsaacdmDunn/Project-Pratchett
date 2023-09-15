using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//node for how hungry the NPC is
public class HungerNode : Node
{
    NPCStats stats;

    //constructor
    public HungerNode(NPCStats _stats)
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
        //if not hungry then fail node
        return NodeStatus.failure;
    }
}
