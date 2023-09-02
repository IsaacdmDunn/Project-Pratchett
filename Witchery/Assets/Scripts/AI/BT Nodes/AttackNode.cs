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

    public override NodeState Evaluate()
    {
        animator.SetTrigger("Attacking");
        stats.Speech = "I'm gonna kill you";
        stats.BT = "Atacking";
        return NodeState.success;
    }
}
