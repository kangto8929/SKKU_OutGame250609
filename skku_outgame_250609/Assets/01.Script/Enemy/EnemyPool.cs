using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int poolSize = 10;
    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(enemyPrefab);
            obj.SetActive(false);
            enemyPool.Enqueue(obj);
        }
    }

    public GameObject GetEnemy()
    {
        if (enemyPool.Count > 0)
        {
            GameObject obj = enemyPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            // 풀에 남은 객체가 없으면 새로 생성 (선택 사항)
            GameObject obj = Instantiate(enemyPrefab);
            return obj;
        }
    }

    public void ReturnEnemy(GameObject obj)
    {
        obj.SetActive(false);
        enemyPool.Enqueue(obj);
    }
}
