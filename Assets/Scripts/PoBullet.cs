﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoBullet : MonoBehaviour
{
    const float BULLET_SPEED = 100f;
    private BulletPool pool;
    private int damage;
    public Vector3 dir;

    public void Init(BulletPool iPool, int iDamage, Vector3 moveDir)
    {
        pool = iPool;
        damage = iDamage;
        dir = moveDir;
        StartCoroutine(AutoKill());
    }

    void Update()
    {
        transform.Translate(dir * BULLET_SPEED * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PoEnemy"))
        {
            other.gameObject.GetComponent<EnemyLife>().TakeDamage(damage);
            StopCoroutine(AutoKill());
            pool.Release(gameObject);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyLife>().TakeDamage(damage);
            StopCoroutine(AutoKill());
            pool.Release(gameObject);
        }
        else if (other.CompareTag("Env"))
        {
            StopCoroutine(AutoKill());
            pool.Release(gameObject);
        }
    }

    IEnumerator AutoKill()
    {
        yield return new WaitForSecondsRealtime(10f);
        pool.Release(gameObject);
    }
}
