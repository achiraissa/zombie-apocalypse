using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;            // The enemy prefab to spawn
    public Transform spawnPoint;              // The spawn point for the enemy
    public float spawnInterval = 2f;          // The time interval between spawns
    public float movementRange = 10f;         // The range of random movement

    private float spawnTimer = 0f;            // Timer for tracking spawn intervals

    private void Update()
    {
        spawnTimer += Time.fixedDeltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is not assigned.");
            return;
        }

        if (spawnPoint == null)
        {
            Debug.LogError("Spawn point is not assigned.");
            return;
        }

        // Instantiate the enemy prefab at the spawn point
        GameObject enemyObject = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Get the NavMeshAgent component from the spawned enemy
        NavMeshAgent enemyAgent = enemyObject.GetComponent<NavMeshAgent>();

        if (enemyAgent != null)
        {
            // Set the random destination for the enemy within the movement range
            Vector3 randomDestination;
            if (RandomPoint(spawnPoint.position, movementRange, out randomDestination))
            {
                enemyAgent.SetDestination(randomDestination);
            }
        }
        else
        {
            Debug.LogWarning("NavMeshAgent component not found on spawned enemy object.");
        }
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
}
