using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyScriptableObjects", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObjects : ScriptableObject
{
    //Base stats for enemies
    public float maxHealth;
    public float moveSpeed;
    public float damage;
}
