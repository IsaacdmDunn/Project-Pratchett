using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkNode : Node
{
    Transform target;
    NavMeshAgent agent;

    public WalkNode(NavMeshAgent _agent, Transform _target)
    {
        agent = _agent;
        target = _target;
    }

    public override NodeState Evaluate()
    {
        agent.destination = target.position;
        return NodeState.success;
    }
}
