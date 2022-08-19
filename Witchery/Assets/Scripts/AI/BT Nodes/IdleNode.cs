using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleNode : Node
{
    Vector3 idleTo;
    float timer;
    NavMeshAgent agent;
    public IdleNode(NavMeshAgent _agent)
    {
        agent = _agent;
        RandomPosition();
    }

    public override NodeState Evaluate()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            RandomPosition();
        }
        if (agent.remainingDistance > 0)
        {
            return NodeState.failure;
        }
        agent.destination = idleTo;

        return NodeState.success;
    }

    public void RandomPosition()
    {
        timer = Random.Range(3.0f, 10.0f);
        idleTo = new Vector3(Random.Range(-30.0f, 30.0f), 1, Random.Range(-30.0f, 30.0f));
    }
}
