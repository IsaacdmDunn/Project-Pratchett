using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//node for eating
public class EatNode : Node
{
    GameObject targetFood;
    NavMeshAgent agent;
    ItemPickup itemToEat;
    NPCStats stats;
    Animator animator;

    //constructor
    public EatNode(Animator _animator, NavMeshAgent _agent, GameObject _targetFood, NPCStats _stats)
    {
        targetFood = _targetFood;
        
        agent = _agent;
        stats = _stats;
        animator = _animator;
    }

    //runs beahviour
    public override NodeStatus RunBehaviour()
    {
        //if food is edible
        if (itemToEat != null)
        {
            //if nearby item and its foragable then eat and return sucess
            if (itemToEat.foragable && agent.remainingDistance < 0.3f)
            {
                stats.hungerAmount -= itemToEat.Eat();

                animator.SetTrigger("Eating");
                return NodeStatus.success;
            }
            
        }
        //food was not eaten return fail
        return NodeStatus.failure; 
    }

    //sets new food target
    public void SetTarget(GameObject _targetFood)
    {
        itemToEat = targetFood.gameObject.GetComponent<ItemPickup>();
        targetFood = _targetFood;
    }
}
