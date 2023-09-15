using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    //constructor setting child nodes
    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    //run behaviour
    public override NodeStatus RunBehaviour()
    {
        bool nodeRunning = false;
        //for each child node check node status
        foreach (Node node in nodes)
        {
            switch (node.RunBehaviour())
            {
                //if node is running then sequence is running
                case NodeStatus.running:
                    nodeRunning = true;
                    break;
                //if node failed return fail for sequence node
                case NodeStatus.failure:
                    nodeState = NodeStatus.failure;
                    return nodeState;
                default:
                    break;
            }
        }
        //if a child node was running return with running
        if (nodeRunning)
        {
            nodeState = NodeStatus.running;
        }
        //if child node was successful then sequence is successful
        else
        {
            nodeState = NodeStatus.success;
        }
        return nodeState;
    }

}
