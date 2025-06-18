using UnityEngine;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    public GameObject SpawnEnemy;
    public float RepeatInterval = 3f;
    public int MaxEnemies = 10;

    public Transform[] SpawnPoints;              // 4���� ���� ���� ��ġ
    public float[] SpawnRanges;                  // �� ���� ����Ʈ�� ���� (��: [10, 20, 5, 15])

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    void Start()
    {
        if (RepeatInterval > 0)
        {
            InvokeRepeating("TrySpawnEnemy", 0f, RepeatInterval);
        }
    }

    void TrySpawnEnemy()
    {
        // ���� �� ����
        spawnedEnemies.RemoveAll(enemy => enemy == null);

        if (spawnedEnemies.Count >= MaxEnemies)
            return;

        if (SpawnEnemy != null && SpawnPoints.Length > 0 && SpawnPoints.Length == SpawnRanges.Length)
        {
            // ������ �ε��� ����
            int index = Random.Range(0, SpawnPoints.Length);
            Transform basePoint = SpawnPoints[index];
            float range = SpawnRanges[index];

            // ���� ��ġ �ֺ����� ���� ��ġ ���
            float offsetX = Random.Range(-range, range);
            float offsetZ = Random.Range(-range, range);
            Vector3 spawnPos = new Vector3(
                basePoint.position.x + offsetX,
                basePoint.position.y,               // �ʿ� �� y ����
                basePoint.position.z + offsetZ
            );

            // ���� �� ���
            GameObject newEnemy = Instantiate(SpawnEnemy, spawnPos, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
        }
    }
}
