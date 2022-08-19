using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EatNode : Node
{
    Transform targetFood;
    NavMeshAgent agent;
    ItemPickup itemToEat;
    EnemyStats stats;
    public EatNode(NavMeshAgent _agent, Transform _targetFood, EnemyStats _stats)
    {
        targetFood = _targetFood;
        itemToEat = targetFood.gameObject.GetComponent<ItemPickup>();
        agent = _agent;
        stats = _stats;
    }

    public override NodeState Evaluate()
    {
        Debug.Log("eated");
        if (itemToEat.foragable && agent.remainingDistance < 0.3f)
        {
            itemToEat.Forage();
            stats.hungerAmount -= 30;
            return NodeState.success;
        }

        return NodeState.failure;
    }
}
