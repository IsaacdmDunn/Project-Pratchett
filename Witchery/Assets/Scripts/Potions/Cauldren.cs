using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cauldren : MonoBehaviour
{

    [SerializeField] public CauldrenMixture cauldrenMixture;
    [SerializeField] CauldronUI cauldronUI;
    [SerializeField] GameObject playerInvUI;
    [SerializeField] Material liquid;
    public bool flameOn = false;
    bool isStirring = false;
    bool inUse = false;

    // Start is called before the first frame update
    void Start()
    {
        liquid.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CheckFlame();
        ChangePotionColor();
        //if player is in the collider for the cauldron
        if (inUse)
        {
            //make potion if 1 unit of liquid is in cauldron
            if (Input.GetKeyDown(KeyCode.C) && cauldrenMixture.totalVolume > 1.0f)
            {
                cauldronUI.MakePotion();
            }
            //open cauldren UI
            else if (Input.GetKeyDown(KeyCode.E))
            {
                cauldronUI.gameObject.SetActive(!cauldronUI.gameObject.activeSelf);
                playerInvUI.SetActive(!playerInvUI.gameObject.activeSelf);
                cauldronUI.LockCursor();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if player is near cauldron
        if (other.tag == "Player")
        {
            inUse = true;
            
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        //if player is near cauldron
        if (other.tag == "Player")
        {
            inUse = false;
        }
    }

    //chacks if cauldron fire is on
    void CheckFlame()
    {
        if (flameOn)
        {
            //log temp increase
        }
        else
        {
            //log temp down
        }
    }

    //changes cauldron liquid go color depending on the color of mixture
    void ChangePotionColor()
    {
        if (cauldrenMixture.totalVolume > 1.0f)
        {
            liquid.color = cauldrenMixture.liquidColor;
        }
    }
}
