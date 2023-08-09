using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA : MonoBehaviour
{
    public List<int> genome;
    public float mutationRate;

    public List<Node> NodeList = new List<Node>();
    public Sequence node = null;
    public Node node1 = new Sequence(null);
    public Sequence node2 = new Sequence(null);
    public Sequence node3 = new Sequence(null);

    public void initGenome()
    {
        node = new Sequence(null);
        NodeList.Add(node);
        Debug.Log(NodeList.Count);
    }

    public void Start()
    {
        
    }
}
