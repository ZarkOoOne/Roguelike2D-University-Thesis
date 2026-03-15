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
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds); //Destroy the melee weapon after a certain amount of seconds to prevent cluttering the scene
    }

}