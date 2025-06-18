using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPool enemyPool; // EnemyPool�� �ν����Ϳ��� ����
    public Transform spawnPoint; // ���ϴ� ���� ��ġ
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
