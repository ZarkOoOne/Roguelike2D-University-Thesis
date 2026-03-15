using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

/// <summary>
/// Base script for all weapon controllers
/// </summary>
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    float currentCooldown;
  

    protected PlayerMovement pm;

    protected virtual void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        pm = FindObjectOfType<PlayerMovement>();
#pragma warning restore CS0618 // Type or member is obsolete
        currentCooldown = weaponData.CooldownDuration; //At the start set the current cooldown to be the cooldown duration
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0f) //once the cooldown becomes 0, attack
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration; //reset the cooldown
    }
}
