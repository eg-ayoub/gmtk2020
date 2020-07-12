using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobQueenBehaviour : MonoBehaviour
{

    const float REST_TIME = .5f;
    const float MOVE_TIME = 1.5f;
    const float MOVE_SPEED = 25;
    const float RUNAWAY_THRESHOLD = 100;
    Transform playerTransform;

    private EnemyLife _life;

    private BlobPool poBlobPool;
    private BlobPool tinkyBlobPool;
    private BlobPool lalaBlobPool;

    private Rigidbody2D _rigidbody;

    private void Start()
    {

        _life = GetComponent<EnemyLife>();
        playerTransform = FindObjectOfType<Player>().transform;
        _rigidbody = GetComponent<Rigidbody2D>();

        poBlobPool = transform.GetChild(0).GetComponent<BlobPool>();
        tinkyBlobPool = transform.GetChild(1).GetComponent<BlobPool>();
        lalaBlobPool = transform.GetChild(2).GetComponent<BlobPool>();

        poBlobPool.Init();
        tinkyBlobPool.Init();
        lalaBlobPool.Init();

        StartCoroutine(BehaviourLoop());
    }

    private void Update()
    {
        if (_life.GetHP() <= 0)
        {
            GetComponent<EnemyParent>().GetParent().Release(gameObject);
            _life.SetHP(10);
        }
        // transform.Translate(velocity * Time.deltaTime);
    }

    IEnumerator BehaviourLoop()
    {
        while (true)
        {
            _rigidbody.velocity = NextMoveDirection() * MOVE_SPEED;
            Spawn();
            yield return new WaitForSecondsRealtime(MOVE_TIME);

            _rigidbody.velocity = Vector2.zero;
            yield return new WaitForSecondsRealtime(REST_TIME);
        }
    }

    private Vector2 NextMoveDirection()
    {
        Vector2 deltaPosition = ((Vector2)(playerTransform.position - transform.position));

        if (deltaPosition.magnitude <= RUNAWAY_THRESHOLD)
        {
            return deltaPosition.normalized;
        }
        else
        {
            return Quaternion.Euler(0, 0, Random.Range(0f, 360f)) * Vector2.right;
        }

    }

    public void Spawn()
    {
        int which = Random.Range(0, 3);
        GameObject blob = WhichPool(which).GetBlob(transform.parent);
        blob.GetComponent<BlobBehaviour>().Init(WhichPool(which));
    }

    private BlobPool WhichPool(int index)
    {
        if (index == 0)
        {
            return poBlobPool;
        }
        else if (index == 1)
        {
            return tinkyBlobPool;
        }
        else
        {
            return lalaBlobPool;
        }
    }

}
