using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopLevelEnemyPool : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefab;

    const int START_enemy_COUNT = 5;

    private List<GameObject> _enemies;

    private bool _ready = false;

    public void Init()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError("no enemy prefab");
            return;
        }

        _enemies = new List<GameObject>(START_enemy_COUNT);
        for (int _b = 0; _b < START_enemy_COUNT; _b++)
        {
            Addenemy();
        }

        _ready = true;

    }

    public int Count()
    {
        int c = 0;
        foreach (GameObject enemy in _enemies)
        {
            if (enemy.activeSelf) c++;
        }
        return c;
    }

    public GameObject Getenemy(Transform parent)
    {
        if (!_ready)
        {
            Debug.LogError("pool not ready");
            return null;
        }

        for (int _b = 0; _b < _enemies.Count; _b++)
        {
            GameObject enemy = _enemies[_b];
            if (!enemy.activeSelf)
            {
                enemy.transform.SetParent(parent);
                enemy.transform.position = transform.position;
                enemy.SetActive(true);
                return enemy;
            }
        }

        GameObject newenemy = Addenemy();
        newenemy.transform.SetParent(parent);
        newenemy.transform.position = transform.position;
        newenemy.SetActive(true);
        return newenemy;
    }

    public void Release(GameObject enemy)
    {
        enemy.SetActive(false);
    }

    private GameObject Addenemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        enemy.transform.SetParent(transform);
        enemy.SetActive(false);

        _enemies.Add(enemy);

        return enemy;
    }

}
