using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    public override NodeStatus RunBehaviour()
    {
        bool nodeRunning = false;
        foreach (Node node in nodes)
        {
            switch (node.RunBehaviour())
            {
                case NodeStatus.running:
                    nodeRunning = true;
                    break;
                case NodeStatus.success:
                    break;
                case NodeStatus.failure:
                    nodeState = NodeStatus.failure;
                    return nodeState;
                    break;
                default:
                    break;
            }
        }
        if (nodeRunning)
        {
            nodeState = NodeStatus.running;
        }
        else
        {
            nodeState = NodeStatus.success;
        }
        return nodeState;
    }

}
