using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Node
{
    public enum NodeStatus
    {
        running, success, failure
    }

    public NodeStatus nodeState;
    public abstract NodeStatus RunBehaviour();
    public NodeStatus GetNodeState { get { return nodeState; } }
    public List<Node> nodes = new List<Node>();
}
