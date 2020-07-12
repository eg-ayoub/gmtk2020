using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunisherDuckBehaviour : MonoBehaviour
{

    [SerializeField]
    Transform leftShooter;

    [SerializeField]
    Transform rightShooter;

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
        Vector2 baseDirection = ((Vector2)(playerTransform.position - transform.position)).normalized;

        Vector3 shootPos = baseDirection.x > 0 ? leftShooter.position : rightShooter.position;

        for (int _a = 0; _a < 5; _a++)
        {
            float angle = Mathf.Lerp(-45, 45, (float)_a / 4);
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;

            GameObject bullet = _bulletPool.GetBullet(transform.parent, shootPos);
            bullet.GetComponent<Bullet>().Init(_bulletPool, direction);
        }

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
            Shoot();
        }
    }


}
