using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierDuckBehaviour : MonoBehaviour
{
    const float MOVE_REST_TIME = .5f;
    const float MOVE_TIME = 1f;
    const float MOVE_SPEED = 25;
    const float FOLLOW_THRESHOLD = 200;
    const float RUNAWAY_THRESHOLD = 100;

    const float SHOOT_REST_TIME = 1f;

    private Transform playerTransform;
    private EnemyLife _life;

    private Rigidbody2D _rigidbody;

    private BulletPool _bulletPool;

    private void Start()
    {
        _bulletPool = GetComponent<BulletPool>();
        _bulletPool.Init();
        _life = GetComponent<EnemyLife>();
        playerTransform = FindObjectOfType<Player>().transform;
        _rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine(MoveBehaviourLoop());
        StartCoroutine(ShootBehaviourLoop());
    }

    private void Shoot()
    {
        Vector2 direction = ((Vector2)(playerTransform.position - transform.position)).normalized;

        GameObject bullet = _bulletPool.GetBullet(transform.parent);
        bullet.GetComponent<Bullet>().Init(_bulletPool, direction);
    }

    private Vector2 MoveDirection()
    {
        Vector2 deltaP = (Vector2)(playerTransform.position - transform.position);

        if (deltaP.magnitude > FOLLOW_THRESHOLD)
        {
            return -deltaP.normalized;
        }
        else if (deltaP.magnitude < RUNAWAY_THRESHOLD)
        {
            return deltaP.normalized;
        }

        return Vector2.zero;
    }

    IEnumerator MoveBehaviourLoop()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(MOVE_REST_TIME);
            _rigidbody.velocity = MoveDirection() * MOVE_SPEED;

            yield return new WaitForSecondsRealtime(MOVE_TIME);
            _rigidbody.velocity = Vector2.zero;
        }
    }

    IEnumerator ShootBehaviourLoop()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(SHOOT_REST_TIME);
            for (int _ = 0; _ < 3; _++)
            {
                yield return new WaitForSecondsRealtime(.1f);
                Shoot();
            }
        }
    }


}
