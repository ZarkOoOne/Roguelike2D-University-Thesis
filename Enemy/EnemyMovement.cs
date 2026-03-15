using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObjects enemyData;
    Transform player;
    void Start()
    {
#pragma warning disable CS0618 // Type or member is obsolete
        player = FindObjectOfType<PlayerMovement>().transform; //Find the player transform to move towards
#pragma warning restore CS0618 // Type or member is obsolete
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime); //Move towards the player at a certain speed
    }
}
