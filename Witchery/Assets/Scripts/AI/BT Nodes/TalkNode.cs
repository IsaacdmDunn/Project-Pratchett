using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TalkNode : Node
{
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    EnemyStats stats;


    public TalkNode(Animator _animator, NavMeshAgent _agent, Transform _target, EnemyStats _stats)
    {
        agent = _agent;
        target = _target;
        animator = _animator;
        stats = _stats;
    }

    public override NodeState Evaluate()
    {
        //if at target return sucess
        if (agent.remainingDistance < 10)
        {
            //talk to NPC
            stats.Speech = "Hi how are you " + target.gameObject.name;
            stats.BT = "Talking";
            stats.actionComplete = true;
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
