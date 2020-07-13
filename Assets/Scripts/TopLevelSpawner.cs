using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLevelSpawner : MonoBehaviour
{
    [SerializeField]
    public Vector3Int[] difficultyCurve;

    [SerializeField]
    public Vector2Int finalDifficulty;

    private TopLevelEnemyPool enemyPool;

    private void Start()
    {
        enemyPool = GetComponent<TopLevelEnemyPool>();
        enemyPool.Init();
        StartCoroutine(SpawnLoop());
    }

    public void Spawn()
    {
        GameObject enemy = enemyPool.Getenemy(transform);
        enemy.GetComponent<EnemyParent>().SetParent(enemyPool);
    }

    IEnumerator SpawnLoop()
    {

        // yield return new WaitForSecondsRealtime(20);

        foreach (Vector3Int data in difficultyCurve)
        {
            float timeRecord = Time.time;
            while (Time.time - timeRecord <= data.x)
            {
                if (enemyPool.Count() < data.y)
                {
                    Spawn();
                    yield return new WaitForSecondsRealtime(data.z);
                }
                yield return new WaitForSecondsRealtime(.1f);
            }

        }

        while (true)
        {
            if (enemyPool.Count() < finalDifficulty.x)
            {
                Spawn();
                yield return new WaitForSecondsRealtime(finalDifficulty.y);
            }
            yield return new WaitForSecondsRealtime(.1f);
        }
    }


}
