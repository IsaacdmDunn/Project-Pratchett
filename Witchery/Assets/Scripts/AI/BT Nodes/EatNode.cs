using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatNode : Node
{
    public EatNode()
    {

    }

    public override NodeState Evaluate()
    {
        return NodeState.success;
    }
}
