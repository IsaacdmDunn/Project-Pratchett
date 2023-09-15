using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    //constructor setting child nodes
    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    //run behaviour
    public override NodeStatus RunBehaviour()
    {
        //for each child node check node status
        foreach (Node node in nodes)
        {
            switch (node.RunBehaviour())
            {
                //if any child is running break
                case NodeStatus.running:
                    nodeState = NodeStatus.running;
                    return nodeState;
                    break;
                //if successful continue
                case NodeStatus.success:
                    nodeState = NodeStatus.success;
                    return nodeState;
                    break;
                //if failed 
                case NodeStatus.failure:
                    break;
                default:
                    break;
            }
        }
        //if all children failed then the selector returns a fail
        nodeState = NodeStatus.failure;
        return nodeState;
    }

}
