using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : Node
{
    Animator animator;
    EnemyStats stats;
    public AttackNode(Animator _animator, EnemyStats _stats)
    {
        animator = _animator;
        stats = _stats;
    }

    public override NodeStatus RunBehaviour()
    {

        //allows NPC attack collision to function
        animator.SetTrigger("Attacking");
        stats.Speech = "I'm gonna kill you";
        stats.BT = "Atacking";
        stats.actionComplete = true;
        stats.angry = true;
        return NodeStatus.success;
    }
}
