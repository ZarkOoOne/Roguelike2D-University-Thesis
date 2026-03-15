using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class ShieldController : WeaponController
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        GameObject spawnedShield = Instantiate(weaponData.Prefab);
        spawnedShield.transform.position = transform.position; //Assign the position to be the same as this object which is parented to the player
        spawnedShield.transform.parent = transform; //Parent the shield to this object so it moves with the player
    }
}
