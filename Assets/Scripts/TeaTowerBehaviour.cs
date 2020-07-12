using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaTowerBehaviour : MonoBehaviour
{

    private BulletPool _bulletPool;

    private EnemyLife _life;

    const float REST_TIME = 5f;
    const int BULLET_COUNT = 30;

    private void Start()
    {
        _bulletPool = GetComponent<BulletPool>();
        _bulletPool.Init();
        _life = GetComponent<EnemyLife>();
        StartCoroutine(BehaviourLoop());
    }

    public void Shoot()
    {
        GameObject bullet = _bulletPool.GetBullet(transform);

        bullet.GetComponent<Bullet>().Init(_bulletPool, Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * transform.right);
    }

    IEnumerator BehaviourLoop()
    {
        while (true)
        {
            _life.MakeInvulnerable();
            yield return new WaitForSecondsRealtime(REST_TIME);

            _life.MakeVulnerable();
            for (int i = 0; i < BULLET_COUNT; i++)
            {
                Shoot();
                yield return new WaitForSecondsRealtime(.05f);
            }

        }
    }

}
