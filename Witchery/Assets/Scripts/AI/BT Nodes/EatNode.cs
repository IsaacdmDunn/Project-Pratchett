using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EatNode : Node
{
    GameObject targetFood;
    NavMeshAgent agent;
    ItemPickup itemToEat;
    EnemyStats stats;
    Animator animator;
    public EatNode(Animator _animator, NavMeshAgent _agent, GameObject _targetFood, EnemyStats _stats)
    {
        targetFood = _targetFood;
        
        agent = _agent;
        stats = _stats;
        animator = _animator;
    }

    public override NodeState Evaluate()
    {
        if (itemToEat != null)
        {


            //if nearby item and its foragable then eat and return sucess
            if (itemToEat.foragable && agent.remainingDistance < 0.3f)
            {
                stats.hungerAmount -= itemToEat.Eat();

                animator.SetTrigger("Eating");
                return NodeState.success;
            }
            
        }
        
        return NodeState.failure; //behavior failed
    }

    public void SetTarget(GameObject _targetFood)
    {
        itemToEat = targetFood.gameObject.GetComponent<ItemPickup>();
        targetFood = _targetFood;
    }
}
