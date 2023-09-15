using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//node for idle behaviour
public class IdleNode : Node
{
    Vector3 idleTo;
    float timer;
    NavMeshAgent agent;
    Animator animator;
    NPCStats stats;

    //constructor
    public IdleNode(Animator _animator, NavMeshAgent _agent, NPCStats _stats)
    {
        agent = _agent;
        animator = _animator;
        stats = _stats;
        RandomPosition();
    }

    //run behaviour
    public override NodeStatus RunBehaviour()
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
            return NodeStatus.failure;
        }

        //set destination
        agent.destination = idleTo;

        stats.Speech = "I'm just wandering";
        stats.BT = "Idle";

        return NodeStatus.success;
    }

    //select random position
    public void RandomPosition()
    {
        timer = Random.Range(3.0f, 10.0f);
        idleTo = new Vector3(Random.Range(-30.0f, 30.0f), 1, Random.Range(-30.0f, 30.0f));
    }
}
