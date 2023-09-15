using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//abstract node for behaviours
public abstract class Node
{
    //status for a node
    public enum NodeStatus
    {
        running, success, failure
    }

    public NodeStatus nodeState;

    //behaviour for node in BT
    public abstract NodeStatus RunBehaviour();

    //gets node status
    public NodeStatus GetNodeState { get { return nodeState; } }

    //stores child nodes
    public List<Node> nodes = new List<Node>();
}
