using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoHitProcessor : HitProcessor
{
    private BulletPool _bulletPool;

    private void Start()
    {
        _bulletPool = GetComponent<BulletPool>();
        _bulletPool.Init();
    }

    public override void ProcessHit(Vector3 towards)
    {
        Debug.Log("po shoots !");
        GameObject bullet = _bulletPool.GetBullet(transform.parent.parent);
        bullet.GetComponent<PoBullet>().Init(_bulletPool, 1, towards);
    }
}
