using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyScriptableObjects", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObjects : ScriptableObject
{
    public GameObject prefab;
    public float maxHealth;
    public float moveSpeed;
    public float damage;
}
