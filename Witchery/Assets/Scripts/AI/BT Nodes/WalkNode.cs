using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkNode : Node
{
    Transform target;
    NavMeshAgent agent;
    Animator animator;


    public WalkNode(Animator _animator, NavMeshAgent _agent, Transform _target)
    {
        agent = _agent;
        target = _target;
        animator = _animator;
    }

    public override NodeState Evaluate()
    {
        //walk to target 
        agent.SetDestination(target.position);
        //if at target return sucess
        if (agent.remainingDistance < 0.3)
        {
            return NodeState.success;
            
        }
        animator.SetTrigger("Moving");
        return NodeState.running;
        
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
