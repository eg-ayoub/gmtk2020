using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LalaHitProcessor : HitProcessor
{
    LalaHitScanner _hitScanner;
    PlayerController _controller;

    private int _counter;

    private float lastHit;

    private PlayerAnimator _animator;

    private bool _ready = true;

    private void OnEnable()
    {
        _ready = true;
        // Debug.Log("lala comes to the rescue");
    }

    private void Start()
    {
        _hitScanner = GetComponentInChildren<LalaHitScanner>();
        _controller = GetComponentInParent<PlayerController>();
        _animator = GetComponentInParent<PlayerAnimator>();
    }

    public override void ProcessHit(Vector3 towards)
    {
        if (_ready)
        {
            Debug.Log("lala dashes");
            StartCoroutine(Dash(towards));
        }

    }

    private IEnumerator Dash(Vector3 dashDir)
    {
        _ready = false;
        _hitScanner.StartHits();

        _counter++;
        lastHit = Time.time;
        ProcessMiss(ref dashDir);

        _controller.StartDash(dashDir);
        _animator.Attack();
        PlayAudio();
        yield return new WaitForSecondsRealtime(.25f);
        _controller.EndDash();
        // have to process dash ?
        foreach (GameObject enemy in _hitScanner.EndHits())
        {
            enemy.GetComponent<EnemyLife>().TakeDamage(2);
        }
        _ready = true;
        yield return null;
    }

    public void ProcessMiss(ref Vector3 dashDir)
    {
        float missWindow = 0;
        if (_counter > 4)
        {
            missWindow = 45 * Mathf.InverseLerp(2, 4, _counter);
            float deltaAngle = Random.Range(-missWindow, missWindow);

            // float x = Mathf.Cos(Mathf.Deg2Rad * deltaAngle) * aimVector.x - Mathf.Sin(Mathf.Deg2Rad * deltaAngle) * aimVector.y;
            // float y = Mathf.Sin(Mathf.Deg2Rad * deltaAngle) * aimVector.x + Mathf.Cos(Mathf.Deg2Rad * deltaAngle) * aimVector.y;
            dashDir = Quaternion.Euler(0, 0, deltaAngle) * dashDir;
        }
    }

    private void Update()
    {
        if (Time.time - lastHit > 3)
        {
            _counter = 0;
        }
    }
}
