using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] public float health = 100;
    [SerializeField] public float mana = 100;
    [SerializeField] public float stamina = 100;

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
