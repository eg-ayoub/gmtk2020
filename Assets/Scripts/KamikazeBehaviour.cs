﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeBehaviour : MonoBehaviour
{
    const float REST_TIME = 1.5f;
    const float DASH_TIME = 1f;
    const float DASH_SPEED = 400f;

    private Transform playerTranform;
    private Rigidbody2D _rigidbody;

    private EnemyLife _life;
    int lastHP;

    private void Start()
    {
        _life = GetComponent<EnemyLife>();
        _rigidbody = GetComponent<Rigidbody2D>();
        playerTranform = FindObjectOfType<Player>().transform;
        StartCoroutine(BehaviourLoop());
        lastHP = _life.GetHP();
    }

    private void Update()
    {
        if (_life.GetHP() <= 0)
        {
            GetComponent<EnemyParent>().GetParent().Release(gameObject);
            _life.SetHP(1);
        }
        if (_life.GetHP() < lastHP)
        {
            GetComponent<Animator>().SetTrigger("Hit");
            lastHP = _life.GetHP();
        }
    }

    private IEnumerator BehaviourLoop()
    {
        while (true)
        {
            _rigidbody.velocity = Vector3.zero;
            yield return new WaitForSecondsRealtime(REST_TIME);

            Vector3 direction = (playerTranform.position - transform.position).normalized;
            _rigidbody.velocity = DASH_SPEED * direction;
            yield return new WaitForSecondsRealtime(DASH_TIME);
        }
    }
}
