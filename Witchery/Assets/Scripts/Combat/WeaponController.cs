using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    [SerializeField] GameObject weapon; //replace with hand 1 and 2
    [SerializeField] Collider weaponCollider; //replace with hand 1 and 2
    [SerializeField] float attackCoolDown = 1.0f;
    [SerializeField] float timer = 01111f;
    Animator anim;

    private void FixedUpdate()
    {
        anim = weapon.GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (timer > attackCoolDown)
            {
                weaponCollider = weapon.GetComponent<BoxCollider>();
                weaponCollider.enabled = true;
                SwordAttack();
            }
        }
        timer += Time.fixedDeltaTime;
        if (timer > attackCoolDown)
        {
            weaponCollider.enabled = false;
        }
    }
    void SwordAttack()
    {
        timer = 0;
        anim.SetTrigger("Attack");
        weapon.GetComponent<AudioSource>().Play();
    }

}
