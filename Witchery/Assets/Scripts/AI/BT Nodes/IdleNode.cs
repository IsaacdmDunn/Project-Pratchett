using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleNode : Node
{
    Vector3 idleTo;
    float timer;
    NavMeshAgent agent;
    Animator animator;
    public IdleNode(Animator _animator, NavMeshAgent _agent)
    {
        agent = _agent;
        animator = _animator;
        RandomPosition();
    }

    public override NodeState Evaluate()
    {
        animator.SetTrigger("Moving");
        //countdown timer before targer position change
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            RandomPosition();
        }

        //if not at destination fail
        if (agent.remainingDistance > 0)
        {
            return NodeState.failure;
        }

        //set destination
        agent.destination = idleTo;

        return NodeState.success;
    }

    //select random position
    public void RandomPosition()
    {
        timer = Random.Range(3.0f, 10.0f);
        idleTo = new Vector3(Random.Range(-30.0f, 30.0f), 1, Random.Range(-30.0f, 30.0f));
    }
}
