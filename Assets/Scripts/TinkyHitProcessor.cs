using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinkyHitProcessor : HitProcessor
{

    TinkyHitScanner _hitScanner;

    private void Start()
    {
        _hitScanner = GetComponentInChildren<TinkyHitScanner>();
    }

    public override void ProcessHit(Vector3 towards)
    {
        _hitScanner.gameObject.SetActive(true);
        _hitScanner.Hit();
        Debug.Log("tinky hits!");
    }
}
