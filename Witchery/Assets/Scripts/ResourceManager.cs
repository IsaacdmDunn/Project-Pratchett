using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    [SerializeField] List<GameObject> NPCs;
    [SerializeField] List<GameObject> Enviroment;
    [SerializeField] GameObject player;

    bool updateRequired= false;
    public List<int> mutationCount = new List<int> { 0,0,0,0,0,0,0,0,0,0};

    

    private void LateUpdate()
    {
        updateRequired = false;
    }

    
   

   

    public List<GameObject> GetNPCs()
    {
        return NPCs;
    }

    public List<GameObject> GetEnviroment()
    {
        return Enviroment;
    }
  
    public GameObject GetPlayer()
    {
        return player;
    }

    void SaveArea()
    {

    }

    void LoadArea()
    {

    }
}
