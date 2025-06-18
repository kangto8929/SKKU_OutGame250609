using UnityEngine;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
    public GameObject SpawnEnemy;
    public float RepeatInterval = 3f;
    public int MaxEnemies = 10;

    public Transform[] SpawnPoints;              // 4개의 기준 스폰 위치
    public float[] SpawnRanges;                  // 각 스폰 포인트별 범위 (예: [10, 20, 5, 15])

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
        // 죽은 적 정리
        spawnedEnemies.RemoveAll(enemy => enemy == null);

        if (spawnedEnemies.Count >= MaxEnemies)
            return;

        if (SpawnEnemy != null && SpawnPoints.Length > 0 && SpawnPoints.Length == SpawnRanges.Length)
        {
            // 랜덤한 인덱스 선택
            int index = Random.Range(0, SpawnPoints.Length);
            Transform basePoint = SpawnPoints[index];
            float range = SpawnRanges[index];

            // 기준 위치 주변으로 랜덤 위치 계산
            float offsetX = Random.Range(-range, range);
            float offsetZ = Random.Range(-range, range);
            Vector3 spawnPos = new Vector3(
                basePoint.position.x + offsetX,
                basePoint.position.y,               // 필요 시 y 고정
                basePoint.position.z + offsetZ
            );

            // 생성 및 등록
            GameObject newEnemy = Instantiate(SpawnEnemy, spawnPos, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
        }
    }
}
