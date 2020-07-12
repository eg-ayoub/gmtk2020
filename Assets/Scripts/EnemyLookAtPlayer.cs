using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookAtPlayer : MonoBehaviour
{
    private Transform playerTranform;
    void Start()
    {
        playerTranform = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        float direction = (playerTranform.position - transform.position).x;

        transform.localScale = new Vector3(direction > 0 ? -1 : 1, 1, 1);
    }
}
