using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackNode : Node
{
    Animator animator;
    public AttackNode(Animator _animator)
    {
        animator = _animator;
    }

    public override NodeState Evaluate()
    {
        animator.SetTrigger("Attacking");

        return NodeState.success;
    }
}
