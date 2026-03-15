using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    Transform player;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; //Find the player transform to move towards
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.moveSpeed * Time.deltaTime); //Move towards the player at a certain speed
    }
}
