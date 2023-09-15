using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BehaviourTree : MonoBehaviour
{
    public Node topNode = null;
    public GA ga = null;

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
    
    //flee behaviour
    public FleeNode flee = null;

    //social behaviour
    public TalkNode talkToTarget = null;


    //Reference knowledge
    [SerializeField] public ResourceManager resourceManager;
    public List<GameObject> potentialTargetCharacters;
    GameObject targetCharacter = null;
    GameObject targetFood = null;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] NPCStats stats;
    int layerMask = 1 << 6;
    int targetID = 0;
    Animator animator;
    public int timer = 1200;
    
    //on start 
    void Awake()
    {
        animator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        stats.resourceManager = resourceManager;

        //creates list of possible target NPCs and picks random initial target
        List<GameObject> npcs = resourceManager.GetNPCs();
        foreach (GameObject npc in npcs)
        {
            potentialTargetCharacters.Add(npc);
        }
        targetID = Random.RandomRange(0, potentialTargetCharacters.Count);
        targetCharacter = potentialTargetCharacters[targetID];

        //sets food target
        GetClosestFood();

        //gets AI nav mesh
        agent = GetComponent<NavMeshAgent>();

        //creates and initises new adaptive behavour tree
        ga = new GA();
        ga.behaviorTree = this;
        ConstructBT();
        ga.initGenome();

        
    }

    //create behaviour tree
    void ConstructBT()
    {
        //idle behavior
        idle = new IdleNode(animator, agent, stats);
        
        //eating behavior
        hunger = new HungerNode(stats);
        flee = new FleeNode(animator, agent, targetCharacter.transform, stats);
        walkToFood = new WalkNode(animator, agent, targetFood.transform, stats);
        eat = new EatNode(animator, agent, targetFood.gameObject, stats);
        eatingSQC = new Sequence(new List<Node> {hunger, walkToFood, eat });
        

        //attacking behavior
        searchForPlayer = new DetectionNode(this.transform, stats, layerMask, targetCharacter);
        walkToTarget = new WalkNode(animator, agent, targetCharacter.transform, stats); 
        attackTarget = new AttackNode(animator, stats);
        attackingSQC = new Sequence(new List<Node> {searchForPlayer, walkToTarget, attackTarget});

        //talking behaviour
        talkToTarget = new TalkNode(animator, agent, targetCharacter.transform, stats);

        //creates new list of usable genes
        ga.NodeList.Add(attackingSQC);
        ga.NodeList.Add(eatingSQC);
        ga.NodeList.Add(idle);
        ga.NodeList.Add(flee);
        ga.NodeList.Add(talkToTarget);
        ga.NodeList.Add(walkToTarget);

        //sets behaviours in tree to genome data
        topNode = new Selector(ga.genome);

    }

    // update call every frame
    private void FixedUpdate()
    {
        SetTargetCharacter(); 

        //resets the target charactor/ food for beahviours
        walkToFood.SetTarget(targetFood.transform);
        walkToTarget.SetTarget(targetCharacter.transform);

        talkToTarget.SetTarget(targetCharacter.transform);
        eat.SetTarget(targetFood.gameObject);
        searchForPlayer.SetTarget(targetCharacter);
        flee.SetTarget(targetCharacter.transform);
        GetClosestFood();

        //if NPC is tramatised then start mutation
        if (stats.traumatized)
        {
            ga.Mutation();
            stats.traumatized = false;
        }

        //recreate tree with updated behaviours
        topNode = new Selector(ga.genome);
        topNode.RunBehaviour();

    }

    //gets a random target character
    void SetTargetCharacter()
    {
        timer--;
        if (timer < 0)
        {
            targetID = Random.RandomRange(0, potentialTargetCharacters.Count);
            timer = 1200;
        }
        targetCharacter = potentialTargetCharacters[targetID];
    }

    //gets closes food using distance
    void GetClosestFood()
    {
        float dist;
        float bestDistance = 100000;
        foreach (GameObject enviromenalObj in resourceManager.GetEnviroment())
        {
            if (enviromenalObj.GetComponent<ItemPickup>().foragable)
            {
                dist = Vector3.Distance(enviromenalObj.transform.position, this.gameObject.transform.position);
                if (dist < bestDistance)
                {
                    bestDistance = dist;
                    targetFood = enviromenalObj;
                }
            }
            
        }
    }

    //if attacking NPC collides with this NPC then NPC is traumatised 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetCharacter.tag && targetCharacter.GetComponent<NPCStats>().angry)
        {
            targetCharacter.GetComponent<NPCStats>().angry = false;
            other.GetComponent<NPCStats>().awarenessAmount = 0;
            stats.traumatized = true;
        }
    }
}
