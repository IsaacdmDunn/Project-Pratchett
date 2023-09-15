using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//node for talking to other NPCs
public class TalkNode : Node
{
    Transform target;
    NavMeshAgent agent;
    Animator animator;
    NPCStats stats;

    //constructor
    public TalkNode(Animator _animator, NavMeshAgent _agent, Transform _target, NPCStats _stats)
    {
        agent = _agent;
        target = _target;
        animator = _animator;
        stats = _stats;
    }

    //run behaviour
    public override NodeStatus RunBehaviour()
    {
        //if at target return sucess
        if (agent.remainingDistance < 10)
        {
            //talk to target NPC
            stats.Speech = "Hi how are you " + target.gameObject.name;
            stats.BT = "Talking";
            stats.actionComplete = true;
            return NodeStatus.success;
            
        }
        //if not talking then node is running
        animator.SetTrigger("Moving");
        return NodeStatus.running;
        
    }

    //sets new target
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
