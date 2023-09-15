using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//node for attacking NPCs
public class AttackNode : Node
{
    Animator animator;
    NPCStats stats;

    //constructor
    public AttackNode(Animator _animator, NPCStats _stats)
    {
        animator = _animator;
        stats = _stats;
    }

    //run behaviour
    public override NodeStatus RunBehaviour()
    {
        //allows NPC attack collision to function returning success
        animator.SetTrigger("Attacking");
        stats.Speech = "I'm gonna kill you";
        stats.BT = "Atacking";
        stats.actionComplete = true;
        stats.angry = true;
        return NodeStatus.success;
    }
}
