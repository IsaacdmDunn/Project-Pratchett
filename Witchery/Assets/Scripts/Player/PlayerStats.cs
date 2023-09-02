using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    

    [SerializeField] Slider healthBar;
    [SerializeField] Slider manaBar;
    [SerializeField] Slider staminaBar;

    [SerializeField] float invulnabilityTimer;
    [SerializeField] float invulnabilityTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (health > 100)
        {
            health -= Time.fixedDeltaTime; 
        }
        else if (health < 0)
        {
            //Debug.Log("Player is dead");
        }

        stamina += Time.fixedDeltaTime*3;

        healthBar.value = health;
        manaBar.value = mana;
        staminaBar.value = stamina;
    }

    public void TakeDamage(float damage)
    {
        if (invulnabilityTimer > invulnabilityTime)
        {

        }
    }
}
