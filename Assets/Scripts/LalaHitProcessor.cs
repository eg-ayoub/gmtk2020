using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LalaHitProcessor : HitProcessor
{
    public override void ProcessHit(Vector3 towards)
    {
        Debug.Log("lala dashes");
    }
}
