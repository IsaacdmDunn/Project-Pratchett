using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : Node
{
    public AttackNode()
    {

    }

    public override NodeState Evaluate()
    {
        return NodeState.success;
    }
}
