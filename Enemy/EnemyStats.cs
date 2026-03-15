using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;

    //Current Stats
    float currentMoveSpeed;
    float currentHealth;
    float currentDamage;

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed; //Set the current move speed to the base move speed at the start
        currentHealth = enemyData.MaxHealth; //Set the current health to the max health at the start
        currentDamage = enemyData.Damage; //Set the current damage to the base damage at the start
    }

    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg; //Subtract the damage from the current health
        if (currentHealth <= 0) //If the health is less than or equal to 0 then destroy the enemy
        {
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
    
}
