using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkNode : Node
{
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    EnemyStats stats;


    public WalkNode(Animator _animator, NavMeshAgent _agent, Transform _target, EnemyStats _stats)
    {
        agent = _agent;
        target = _target;
        animator = _animator;
        stats = _stats;
    }

    public override NodeStatus RunBehaviour()
    {
        //walk to target 
        agent.SetDestination(target.position);
        //if at target return sucess
        if (agent.remainingDistance < 0.3)
        {
            stats.Speech = "Heading over there";
            stats.BT = "Walking";
            
            return NodeStatus.success;
            
        }
        animator.SetTrigger("Moving");
        return NodeStatus.running;
        
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
