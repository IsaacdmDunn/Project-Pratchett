using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//walk node
public class WalkNode : Node
{
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    NPCStats stats;

    //contructor
    public WalkNode(Animator _animator, NavMeshAgent _agent, Transform _target, NPCStats _stats)
    {
        agent = _agent;
        target = _target;
        animator = _animator;
        stats = _stats;
    }

    //runs behaviour
    public override NodeStatus RunBehaviour()
    {
        //walk to target 
        agent.SetDestination(target.position);
        //if near target return sucess
        if (agent.remainingDistance < 0.3)
        {
            //set current behaviour for UI
            stats.Speech = "Heading over there";
            stats.BT = "Walking";
            
            return NodeStatus.success;
            
        }
        //if not at target set to running
        animator.SetTrigger("Moving");
        return NodeStatus.running;
        
    }

    //changes target to walk to
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
