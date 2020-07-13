using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinkyHitScanner : MonoBehaviour
{

    private PlayerController _controller;

    private bool _ready = true;

    private HashSet<GameObject> enemies;

    private PlayerAnimator _animator;

    private void Start()
    {
        _controller = GetComponentInParent<PlayerController>();
        _animator = GetComponentInParent<PlayerAnimator>();
    }

    public void Hit()
    {
        StartCoroutine(HitCoroutine());
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!_ready && other.CompareTag("TinkyEnemy"))
        {
            enemies.Add(other.gameObject);
        }
        else if (!_ready && other.CompareTag("Enemy"))
        {
            enemies.Add(other.gameObject);
        }
    }

    IEnumerator HitCoroutine()
    {
        _ready = false;
        enemies = new HashSet<GameObject>();
        _controller.LockMove();
        _animator.Attack();
        GetComponentInParent<TinkyHitProcessor>().PlayAudio();
        yield return new WaitForSecondsRealtime(.15f);
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                enemy.GetComponent<EnemyLife>().TakeDamage(3);
            }
        }
        enemies.Clear();
        _controller.UnlockMove();
        _ready = true;
        yield return null;
    }
}
