using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParent : MonoBehaviour
{
    private TopLevelEnemyPool parent;

    public void SetParent(TopLevelEnemyPool iParent)
    {
        parent = iParent;
    }

    public TopLevelEnemyPool GetParent()
    {
        return parent;
    }
}
