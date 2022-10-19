using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] GameObject weapon; //replace with hand 1 and 2
    [SerializeField] Collider weaponCollider; //replace with hand 1 and 2
    [SerializeField] float attackCoolDown = 1.0f;
    [SerializeField] float timer = 01111f;
    [SerializeField] PlayerStats stats;
    int comboCounter = 0;
    float comboResetTimer = 1f;
    float staminaUse = 15f;
    Animator anim;
    

    private void Update()
    {
        timer += Time.fixedDeltaTime;

        anim = weapon.GetComponent<Animator>();

        //if combo complete or player took to long to continue combo then reset combo
        if (comboCounter == 3 || timer > comboResetTimer)
        {
            comboCounter = 0;
        }

        //if attack button is pressed
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //check if attack cooldown is finished
            if (timer > attackCoolDown)
            {
                weaponCollider = weapon.GetComponent<BoxCollider>();
                weaponCollider.enabled = true;
                SwordAttack();
            }
        }
        //attack finished
        else if (timer > attackCoolDown)
        {
            weaponCollider.enabled = false;
        }
        
    }

    //attack being made
    void SwordAttack()
    {
        timer = 0;

        //set animation triggers
        anim.SetInteger("Combo", comboCounter);
        anim.SetTrigger("Attack");

        //effects and sounds of combo move
        switch (comboCounter)
        {
            case 0:
                
                weapon.GetComponent<AudioSource>().pitch = 1f;
                stats.stamina -= staminaUse;
                break;
            case 1:
                weapon.GetComponent<AudioSource>().pitch = 0.7f;
                stats.stamina -= staminaUse;

                break;
            case 2:
                weapon.GetComponent<AudioSource>().pitch = 1.3f;
                stats.stamina -= staminaUse * 1.5f;
                break;
        }
        
        //play sound
        weapon.GetComponent<AudioSource>().Play();
        comboCounter++;

        
    }

}
