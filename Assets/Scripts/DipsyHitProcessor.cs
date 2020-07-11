using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DipsyHitProcessor : HitProcessor
{
    public override void ProcessHit(Vector3 towards)
    {
        Debug.Log("dipsy fails");
    }
}
