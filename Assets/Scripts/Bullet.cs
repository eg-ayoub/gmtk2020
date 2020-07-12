using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    const float BULLET_SPEED = 100f;
    private BulletPool pool;
    // public Vector3 dir;

    // private Rigidbody2D _rb;

    public void Init(BulletPool iPool, Vector3 dir)
    {
        GetComponent<Rigidbody2D>().velocity = dir * BULLET_SPEED;
        // this.dir = dir;
        pool = iPool;
        StartCoroutine(AutoKill());
    }

    private void Update()
    {
        // transform.Translate(dir * BULLET_SPEED * Time.deltaTime);
        // transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerHealth"))
        {
            StopCoroutine(AutoKill());
            FindObjectOfType<PlayerLife>().TakeDamage();
            pool.Release(gameObject);
        }
        else if (other.CompareTag("Player"))
        {
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
