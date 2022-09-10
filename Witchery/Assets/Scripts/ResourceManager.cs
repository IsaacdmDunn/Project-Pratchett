using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    [SerializeField] List<GameObject> Cauldrons;
    [SerializeField] List<GameObject> Storage;
    [SerializeField] List<GameObject> NPCs;
    [SerializeField] List<GameObject> Enemies;
    [SerializeField] List<GameObject> Enviroment;
    [SerializeField] GameObject player;

    [SerializeField] float activeDistance = 10f;
    [SerializeField] float optimisingDistance = 15f;
    bool updateRequired= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAllEnemies();
        CheckAllNPCs();
    }

    private void LateUpdate()
    {
        updateRequired = false;
    }

    void CheckAllEnemies()
    {
        foreach (GameObject enemy in Enemies)
        {
            float dist = Vector3.Distance(enemy.transform.position, player.transform.position);
            if (dist > activeDistance)
            {
                enemy.SetActive(false);
            }
            else
            {
                enemy.SetActive(true);
            }
        }
    }

    void CheckAllNPCs()
    {
        foreach (GameObject NPC in NPCs)
        {
            float dist = Vector3.Distance(NPC.transform.position, player.transform.position);
            if (dist > activeDistance)
            {
                NPC.SetActive(false);
            }
            else
            {
                NPC.SetActive(true);
            }
        }
    }

    public List<GameObject> GetEnemies()
    {
        return Enemies;
    }

    public List<GameObject> GetEnviroment()
    {
        return Enviroment;
    }
    public List<GameObject> GetNPCs()
    {
        return NPCs;
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
