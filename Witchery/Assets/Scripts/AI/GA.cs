using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GA : MonoBehaviour
{
    public List<int> genome;
    public float mutationRate;

    public List<Node> NodeList = new List<Node>();
    public Sequence node = new Sequence(null);

    public void Start()
    {
        NodeList.Add(node);
        Debug.Log(NodeList.Count);
    }
}
