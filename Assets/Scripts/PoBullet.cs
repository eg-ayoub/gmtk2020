using System.Collections;
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
            pool.Release(gameObject);
        }
    }

    // private void OnDrawGizmos()
    // {
    //     Gizmos.DrawSphere(transform.position, 10);
    // }
}
