using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

/// <summary>
/// Base script for all melee weapon behaviours
/// </summary>
public class MeleeWeaponBehaviour : MonoBehaviour
{
    public WeaponScriptableObject weaponData;
    public float destroyAfterSeconds;

    //Current stats
    protected float currnetDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    void Awake()
    {
        currnetDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }   
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds); //Destroy the melee weapon after a certain amount of seconds to prevent cluttering the scene
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy")) //If the melee weapon collides with an enemy, damage the enemy
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currnetDamage);
        }
    }

}