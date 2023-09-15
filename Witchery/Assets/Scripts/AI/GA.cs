using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//genetic algorithm
public class GA : MonoBehaviour
{
    public List<Node> genome = new List<Node>(); 
    public int mutationRate = 10;
    public int initGeneCount = 5;
    public BehaviourTree behaviorTree;
    int treeDepth;
    int maxTreeDepth = 4;
    public List<Node> NodeList = new List<Node>();


    //initises genome with behaviours
    public void initGenome()
    {
        //basic starting behaviours orders as attack sequence, eating sequence and idle behaviours
        genome = new List<Node> { NodeList[0], NodeList[1], NodeList[2] };

        
    }

    //adds new gene within composite nodes
    void AddGene(int i, List<Node> list)
    {
        //increase behavaviour tree search depth
        treeDepth++;

        //add node in composite
        int nodeID = Random.Range(0, NodeList.Count);
        list.Add(NodeList[nodeID]);
        if (list[i].GetType() == typeof(Sequence) || list[i].GetType() == typeof(Selector))
        {
            //seach child nodes with in tree depth limit
            int i2 = 0;
            while (i2 < Random.Range(0, 5) && treeDepth < maxTreeDepth)
            {
                //recursive add gene
                AddGene(i2, list[i].nodes);
                i2++;
            }

        }
    }

    //causes mutation in genome
    public void Mutation()
    {
        int ran = Random.Range(0, mutationRate + 1);
        //check each gene in genome
        for (int i = 0; i < genome.Count; i++)
        {
            //chance to swap randome gene out
            ran = Random.Range(0, mutationRate + 1);
            if (ran == mutationRate)
            {
                int mutationGeneID = Random.Range(0, NodeList.Count);
                behaviorTree.resourceManager.mutationCount[mutationGeneID] += 1;
                Debug.Log("mutation! " + mutationGeneID + " mutation count: " + behaviorTree.resourceManager.mutationCount[mutationGeneID]);
                genome[i] = NodeList[mutationGeneID];
            }

            //chance to swap gene in depth
            ran = Random.Range(0, mutationRate + 1);
            if (ran == mutationRate)
            {
                AddGene(i, genome);
                treeDepth = 0;
            }
        }

        //add or remove behaviours
        ran = Random.Range(0, mutationRate + 1);
        if (ran == mutationRate)
        {
            //randomly chooses to add or remove genes from genome
            int mutationGeneID = Random.Range(0, NodeList.Count);
            int or = Random.Range(0, 2);
            switch (or)
            {
                case 0:
                    int rand = Random.Range(0, genome.Count);
                    genome.RemoveAt(rand);
                    break;
                case 1:
                    genome.Insert(Random.Range(0, genome.Count), NodeList[mutationGeneID]);
                    break;
            }
        }
    }

    
}
