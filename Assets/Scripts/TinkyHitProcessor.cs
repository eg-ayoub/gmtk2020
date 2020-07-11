using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinkyHitProcessor : HitProcessor
{
    public override void ProcessHit(Vector3 towards)
    {
        Debug.Log("tinky hits!");
    }
}
