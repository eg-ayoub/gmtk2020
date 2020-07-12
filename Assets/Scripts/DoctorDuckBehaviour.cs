using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorDuckBehaviour : MonoBehaviour
{

    [SerializeField]
    public Transform leftShooter;

    [SerializeField]
    public Transform rightShooter;

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

    private void Update()
    {
        if (_life.GetHP() <= 0)
        {
            GetComponent<EnemyParent>().GetParent().Release(gameObject);
            _life.SetHP(1);
        }
    }

    private void Shoot()
    {
        Vector2 direction = ((Vector2)(playerTransform.position - transform.position)).normalized;

        Vector3 shootPos = direction.x < 0 ? leftShooter.position : rightShooter.position;

        GameObject bullet = _bulletPool.GetBullet(transform.parent, shootPos);
        bullet.GetComponent<Bullet>().Init(_bulletPool, direction);

        GetComponent<AudioSource>().Play();
    }

    private Vector2 MoveDirection()
    {
        Vector2 deltaP = (Vector2)(playerTransform.position - transform.position);

        if (deltaP.magnitude > FOLLOW_THRESHOLD)
        {
            return deltaP.normalized;
        }
        else if (deltaP.magnitude < RUNAWAY_THRESHOLD)
        {
            return -deltaP.normalized;
        }

        return Vector2.zero;
    }

    IEnumerator MoveBehaviourLoop()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(MOVE_REST_TIME);
            GetComponent<Animator>().SetTrigger("Run");
            _rigidbody.velocity = MoveDirection() * MOVE_SPEED;

            yield return new WaitForSecondsRealtime(MOVE_TIME);
            GetComponent<Animator>().SetTrigger("Stop");
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
