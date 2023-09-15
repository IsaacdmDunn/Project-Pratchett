using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] List<GameObject> NPCs;
    [SerializeField] List<GameObject> Enviroment;
    [SerializeField] GameObject player;


    //stores mutation count for testing
    public List<int> mutationCount = new List<int> { 0,0,0,0,0,0,0,0,0,0};

    //gets NPC objects
    public List<GameObject> GetNPCs()
    {
        return NPCs;
    }

    //gets enviroment objects
    public List<GameObject> GetEnviroment()
    {
        return Enviroment;
    }
  
    //gets the player
    public GameObject GetPlayer()
    {
        return player;
    }
}
