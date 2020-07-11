using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinkyHitScanner : MonoBehaviour
{

    private bool _ready = true;

    private HashSet<GameObject> enemies;

    public void Hit()
    {
        StartCoroutine(HitCoroutine());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!_ready && other.CompareTag("TinkyEnemy"))
        {
            Debug.Log("1 hit");
            enemies.Add(other.gameObject);
        }
    }

    IEnumerator HitCoroutine()
    {
        _ready = false;
        enemies = new HashSet<GameObject>();
        yield return new WaitForSecondsRealtime(.1f);
        foreach (GameObject enemy in enemies)
        {
            enemy.GetComponent<EnemyLife>().TakeDamage(1);
        }
        enemies.Clear();
        _ready = true;
        yield return null;
    }
}
