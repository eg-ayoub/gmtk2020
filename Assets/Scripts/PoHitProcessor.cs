using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoHitProcessor : HitProcessor
{
    private BulletPool _bulletPool;

    private int _counter;

    private float lastHit;

    private void Start()
    {
        _bulletPool = GetComponent<BulletPool>();
        _bulletPool.Init();
    }

    public override void ProcessHit(Vector3 towards)
    {
        Debug.Log("po shoots !");

        _counter++;
        lastHit = Time.time;
        ProcessMiss(ref towards);

        GameObject bullet = _bulletPool.GetBullet(transform.parent.parent, transform.position);
        bullet.GetComponent<PoBullet>().Init(_bulletPool, 1, towards);
    }

    public void ProcessMiss(ref Vector3 aimVector)
    {
        float missWindow = 0;
        if (_counter > 4)
        {
            missWindow = 45 * Mathf.InverseLerp(4, 8, _counter);
            float deltaAngle = Random.Range(-missWindow, missWindow);

            // float x = Mathf.Cos(Mathf.Deg2Rad * deltaAngle) * aimVector.x - Mathf.Sin(Mathf.Deg2Rad * deltaAngle) * aimVector.y;
            // float y = Mathf.Sin(Mathf.Deg2Rad * deltaAngle) * aimVector.x + Mathf.Cos(Mathf.Deg2Rad * deltaAngle) * aimVector.y;
            aimVector = Quaternion.Euler(0, 0, deltaAngle) * aimVector;
        }
    }

    private void Update()
    {
        if (Time.time - lastHit > 1)
        {
            _counter = 0;
        }
    }
}
