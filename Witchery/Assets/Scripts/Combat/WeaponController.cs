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
    

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        anim = weapon.GetComponent<Animator>();

        if (comboCounter == 3 || timer > comboResetTimer)
        {
            comboCounter = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (timer > attackCoolDown)
            {
                weaponCollider = weapon.GetComponent<BoxCollider>();
                weaponCollider.enabled = true;
                SwordAttack();
            }
        }
        else if (timer > attackCoolDown)
        {
            weaponCollider.enabled = false;
        }
        
    }
    void SwordAttack()
    {
        timer = 0;

        
        anim.SetInteger("Combo", comboCounter);
        anim.SetTrigger("Attack");
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
        
        weapon.GetComponent<AudioSource>().Play();
        comboCounter++;

        
    }

}
