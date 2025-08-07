using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRandom : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] private float spawnRadius = 17f; // Bán kính spawn
    [SerializeField] private float spawnRate = 3f;
    [SerializeField] protected EnemyCtrl enemyCtrl;

    void Awake()
    {
        if (player == null) Debug.LogError(transform.name + "does not have player transform");
        if (enemyCtrl == null) Debug.LogError(transform.name + "does not have enemyCtrl");
    }
    void Start()
    {
        SpawnZombie();
    }

    void SpawnZombie()
    {

        if (player == null)
        {
            Debug.LogError("Player is null in ZombieRandom!");
            return;
        }

        if (ZombieSpawner.Instance == null)
        {
            Debug.LogError("ZombieSpawner.Instance is null!");
            return;
        }

        // Tạo vị trí spawn ngẫu nhiên quanh player
        Vector2 randomPosition = Random.insideUnitCircle.normalized * spawnRadius;
        Vector3 spawnPosition = new Vector3(player.position.x + randomPosition.x, player.position.y + randomPosition.y, 0f);

        // Spawn zombie
        Transform prefab = enemyCtrl.Spawner.RandomPrefab();
        Transform obj = ZombieSpawner.Instance.SpawnByPrefab(prefab, spawnPosition, Quaternion.identity);
        obj.transform.gameObject.SetActive(true);
        Invoke(nameof(SpawnZombie), spawnRate);
    }

    
}
