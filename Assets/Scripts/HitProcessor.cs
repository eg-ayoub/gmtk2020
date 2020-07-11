using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HitProcessor : MonoBehaviour
{
    public abstract void ProcessHit(Vector3 towards);
}
