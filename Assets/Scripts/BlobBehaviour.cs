using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBehaviour : MonoBehaviour
{
    const float REST_TIME = .5f;
    const float MOVE_TIME = 1.5f;
    const float MOVE_SPEED = 25;
    Transform playerTransform;
    // Vector2 velocity;

    private EnemyLife _life;
    private BlobPool pool;

    private Rigidbody2D _rigidbody;

    public void Init(int hp, BlobPool iPool)
    {
        pool = iPool;
        _life = GetComponent<EnemyLife>();
        _life.SetHP(hp);
        _rigidbody = GetComponent<Rigidbody2D>();
        playerTransform = FindObjectOfType<Player>().transform;
        StartCoroutine(BehaviourLoop());
    }

    private void Update()
    {
        if (_life.GetHP() == 0)
        {
            pool.Release(gameObject);
        }
        // transform.Translate(((Vector2)(playerTransform.position - transform.position)).normalized * velocity * Time.deltaTime);
    }

    IEnumerator BehaviourLoop()
    {
        while (true)
        {
            _rigidbody.velocity = ((Vector2)(playerTransform.position - transform.position)).normalized * MOVE_SPEED;
            yield return new WaitForSecondsRealtime(MOVE_TIME);

            _rigidbody.velocity = Vector2.zero;
            yield return new WaitForSecondsRealtime(REST_TIME);
        }
    }
}
