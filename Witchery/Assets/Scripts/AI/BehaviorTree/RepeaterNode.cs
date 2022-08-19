using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NEEDS TESTING
public class Repeater: Node
{
    protected Node node;
    public Repeater(Node node)
    {
        this.node = node;
    }

    public override NodeState Evaluate()
    {
        while (nodeState != NodeState.failure) { 
            switch (node.Evaluate())
            {
                case NodeState.running:
                    nodeState = NodeState.running;
                    return nodeState;
                    break;
                case NodeState.success:
                    nodeState = NodeState.success;
                    return nodeState;
                    break;
                case NodeState.failure:
                    nodeState = NodeState.failure;
                    break;
                default:
                    break;
            }

            
        }
        return nodeState;
    }
}
