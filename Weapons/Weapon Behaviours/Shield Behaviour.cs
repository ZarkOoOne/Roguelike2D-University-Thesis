using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class ShieldBehaviour : MeleeWeaponBehaviour
{
    List<GameObject> markedEnemies;

    protected override void Start()
    {
        base.Start();
        markedEnemies = new List<GameObject>(); //List of enemies that have been hit by the shield so they dont get hit multiple times
    }

    protected override void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy") && !markedEnemies.Contains(col.gameObject)) //If the shield collides with an enemy and the enemy has not been hit by the shield already, damage the enemy
        {
            EnemyStats enemy = col.GetComponent<EnemyStats>();
            enemy.TakeDamage(currnetDamage);

            markedEnemies.Add(col.gameObject); //Add the enemy to the list of marked enemies
        }
    }
 
}
