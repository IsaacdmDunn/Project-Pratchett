using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RENAME
public class HungerNode : Node
{
    public HungerNode()
    {

    }

    public override NodeState Evaluate()
    {
        return NodeState.success;
    }
}
