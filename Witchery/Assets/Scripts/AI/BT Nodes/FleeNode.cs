using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeNode : Node
{
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    EnemyStats stats;


    public FleeNode(Animator _animator, NavMeshAgent _agent, Transform _target, EnemyStats _stats)
    {
        agent = _agent;
        target = _target;
        animator = _animator;
        stats = _stats;
        
    }

    public override NodeStatus RunBehaviour()
    {
        //gets distance
        float distance = Vector3.Distance(agent.transform.position, target.transform.position);
        
        //if at target return sucess
        if (distance < 10)
        {
            //flee to new position
            Vector3 dirToPlayer = agent.transform.position - target.transform.position;
            Vector3 newpos = agent.transform.position + dirToPlayer;
            agent.SetDestination(newpos);

            stats.Speech = "I gotta get out of here!";
            stats.BT = "Flee";

            return NodeStatus.success;
            
        }
        animator.SetTrigger("Moving");
        return NodeStatus.running;
        
    }

    //sets target
    public void SetTarget(Transform _target)
    {
        target = _target;
    }

}
