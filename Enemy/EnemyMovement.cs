using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    public float moveSpeed;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform; //Find the player transform to move towards
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime); //Move towards the player at a certain speed
    }
}
