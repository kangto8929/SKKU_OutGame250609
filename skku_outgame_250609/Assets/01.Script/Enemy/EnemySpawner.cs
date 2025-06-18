using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool; // EnemyPool을 인스펙터에서 연결
    public Transform spawnPoint; // 원하는 스폰 위치
    public float spawnInterval = 3f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            GameObject enemy = enemyPool.GetEnemy();
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
        }
    }
}
