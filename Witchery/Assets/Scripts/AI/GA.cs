using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA : MonoBehaviour
{
    public List<Node> genome = new List<Node>(); 
    public int mutationRate = 10;
    public int initGeneCount = 3;
    public EnemyBehavior behaviorTree;

    public List<Node> NodeList = new List<Node>();


    //initises genome with behaviours
    public void initGenome()
    {
        for (int i = 0; i < initGeneCount; i++)
        {
            int nodeID = Random.Range(0, NodeList.Count);
            genome.Add(NodeList[nodeID]);
        }
    }

    //causes mutation in genome
    public void Mutation()
    {
        
        for (int i = 0; i < genome.Count; i++)
        {
            int ran = Random.Range(0, mutationRate + 1);
            Debug.Log(ran);
            if (ran == mutationRate)
            {
                int mutationGeneID = Random.Range(0, NodeList.Count);
                Debug.Log("mutation! " + ran);
                genome[i] = NodeList[mutationGeneID];
            }
        }

        //add or remove behaviours
        int ran2 = Random.Range(0, mutationRate + 1);
        if (ran2 == mutationRate)
        {
            int mutationGeneID = Random.Range(0, NodeList.Count);
            int or = Random.Range(0, 2);
            switch (or)
            {
                case 0:
                    genome.RemoveAt(Random.Range(0, genome.Count));
                    break;
                case 1:
                    genome.Insert(Random.Range(0, genome.Count), NodeList[mutationGeneID]);
                    break;
            }
            
            
        }
    }
}
