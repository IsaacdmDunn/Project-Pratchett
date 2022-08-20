using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Node topNode = null;

    //idle behaviors
    public IdleNode idle = null;

    //feeding behaviors
    public Sequence eatingSQC = null;
    public HungerNode hunger = null;
    public WalkNode walkToFood = null;
    public EatNode eat = null;

    //aggressive behaviors
    public Sequence attackingSQC = null;
    public DetectionNode searchForPlayer = null;
    public WalkNode walkToTarget = null;
    public AttackNode attackTarget = null;



    //Reference knowledge
    [SerializeField] Transform targetCharacter;
    [SerializeField] Transform targetFood;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] EnemyStats stats;
    int layerMask = 1 << 6;
    


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        ConstructBT();
    }

    void ConstructBT()
    {
        //idle behavior
        idle = new IdleNode(agent);
   
        //eating behavior
        hunger = new HungerNode(stats);
        walkToFood = new WalkNode(agent, targetFood);
        eat = new EatNode(agent, targetFood, stats);
        eatingSQC = new Sequence(new List<Node> {hunger, walkToFood, eat});
        
        //attacking behavior
        searchForPlayer = new DetectionNode(this.transform, stats, layerMask, targetCharacter);
        walkToTarget = new WalkNode(agent, targetCharacter); //targets player for now
        attackTarget = new AttackNode();
        attackingSQC = new Sequence(new List<Node> {searchForPlayer, walkToTarget, attackTarget});
     
        //starting node in BT
        topNode = new Selector(new List<Node> { attackingSQC, eatingSQC, idle});

    }

    //NEED BETTER WAY --- DONT CALL EVERY UPDATE
    private void FixedUpdate()
    {
        
        topNode.Evaluate();
    }
}
