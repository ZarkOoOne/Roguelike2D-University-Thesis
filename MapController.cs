using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOptimizerDistance; //Must be greater than the length and width of the tilemap
    float optimizerDistance;
    float optimizerCooldown;
    public float optimizerCooldownTime;

    [System.Obsolete]
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunckChecker();
        ChunkOptimizer();
    }

    void ChunckChecker()
    {

        if (!currentChunk)
        {
            return;
        }

        if (pm.moveDir.x > 0 && pm.moveDir.y == 0) //Right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y == 0) //Left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.y > 0 && pm.moveDir.x == 0) //Up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.y < 0 && pm.moveDir.x == 0) //Down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0) //Up-Right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("UpRight").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("UpRight").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0) //Up-Left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("UpLeft").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("UpLeft").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0) //Down-Right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownRight").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("DownRight").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0) //Down-Left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("DownLeft").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("DownLeft").position;
                SpawnChunk();
            }
        }

    }

    void SpawnChunk()
    {
        int randomIndex = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[randomIndex], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }
    
    void ChunkOptimizer()
    {
        optimizerCooldown -= Time.deltaTime;
        
        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownTime;
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            optimizerDistance = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (optimizerDistance > maxOptimizerDistance)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}
