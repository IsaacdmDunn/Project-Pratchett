using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionEffect : MonoBehaviour
{
    [SerializeField] float potentcy;
    [SerializeField] float effectLength;
    [SerializeField] Effect effect;
    enum Effect
    {
        None,
        HealthRegen,
        ManaRegen,
        DamageIncrease,
    }
}
