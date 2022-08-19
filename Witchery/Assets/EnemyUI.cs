using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Slider hunger;
    [SerializeField] EnemyStats stats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hunger.value = stats.hungerAmount;
    }
}
