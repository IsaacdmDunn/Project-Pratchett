using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
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
    public TalkNode talkToTarget = null;
    public AttackNode attackTarget = null;

    public FleeNode flee = null;

    public List<GameObject> potentialTargetCharacters;

    //Reference knowledge
    [SerializeField] ResourceManager resourceManager;
    GameObject targetCharacter = null;
    GameObject targetFood = null;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] EnemyStats stats;
    int layerMask = 1 << 6;

    Animator animator;

    public int timer = 600;

    void Awake()
    {
        
        animator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();

        List<GameObject> npcs = resourceManager.GetNPCs();
        foreach (GameObject npc in npcs)
        {
            if(npc.tag == "MainNPC")
            {
                potentialTargetCharacters.Add(npc);
            }
        }
        potentialTargetCharacters.Add(resourceManager.GetPlayer());
        GetClosestCharacter();
        GetClosestFood();
        agent = GetComponent<NavMeshAgent>();
        ga = new GA();
        ga.behaviorTree = this;
        
        ConstructBT();
        ga.initGenome();

        stats.resourceManager = resourceManager;
    }

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
        searchForPlayer = new DetectionNode(this.transform, stats, layerMask, resourceManager.GetNPCs(), resourceManager.GetPlayer());
        walkToTarget = new WalkNode(animator, agent, targetCharacter.transform, stats); //targets player for now
        talkToTarget = new TalkNode(animator, agent, targetCharacter.transform, stats); //targets player for now
        attackTarget = new AttackNode(animator, stats);
        attackingSQC = new Sequence(new List<Node> {searchForPlayer, walkToTarget, attackTarget});
        ga.NodeList.Add(attackingSQC);
        ga.NodeList.Add(eatingSQC);
        ga.NodeList.Add(idle);
        ga.NodeList.Add(flee);
        ga.NodeList.Add(eatingSQC);
        ga.NodeList.Add(idle);
        //starting node in BT
        //topNode = new Selector(new List<Node> { attackingSQC, eatingSQC, idle});



        topNode = new Selector(ga.genome);

    }

    //NEED BETTER WAY --- DONT CALL EVERY UPDATE
    private void FixedUpdate()
    {
        walkToFood.SetTarget(targetFood.transform);
        walkToTarget.SetTarget(targetCharacter.transform);
        eat.SetTarget(targetFood.gameObject);
        searchForPlayer.SetTarget(potentialTargetCharacters);
        GetClosestCharacter();
        GetClosestFood();
        topNode.Evaluate();

        if (stats.traumatized)
        {
            ga.Mutation();
            stats.traumatized = false;
        }

        
        
    }

    void GetClosestCharacter()
    {
        List<GameObject> npcs = resourceManager.GetNPCs();
        foreach (GameObject npc in npcs)
        {
            if (npc.tag == "MainNPC")
            {
                potentialTargetCharacters.Add(npc);
            }
        }

        float dist;
        float bestDistance = 100000;
        foreach (GameObject character in potentialTargetCharacters)
        {
            dist = Vector3.Distance(character.transform.position, this.gameObject.transform.position);
            if (dist < bestDistance)
            {
                bestDistance = dist;
                targetCharacter = character;
            }
        }
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetCharacter.tag)
        {
            targetCharacter.GetComponent<Stats>().TakeDamage(5);
        }
    }
}
