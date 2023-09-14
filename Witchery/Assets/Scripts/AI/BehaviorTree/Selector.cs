using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    
    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeStatus RunBehaviour()
    {
        foreach (Node node in nodes)
        {
            switch (node.RunBehaviour())
            {
                case NodeStatus.running:
                    nodeState = NodeStatus.running;
                    return nodeState;
                    break;
                case NodeStatus.success:
                    nodeState = NodeStatus.success;
                    return nodeState;
                    break;
                case NodeStatus.failure:
                    break;
                default:
                    break;
            }
        }
        nodeState = NodeStatus.failure;
        return nodeState;
    }

}
