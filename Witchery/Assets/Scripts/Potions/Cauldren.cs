using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldren : MonoBehaviour
{

    [SerializeField] public CauldrenMixture cauldrenMixture;
    [SerializeField] Material liquid;
    public bool flameOn = false;
    bool isStirring = false;
    bool inUse = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flameOn)
        {
            //log temp increase
        }
        else
        {
            //log temp down
        }

        liquid.color = cauldrenMixture.liquidColor;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                //open potion menu
            }
        }   
    }
}
