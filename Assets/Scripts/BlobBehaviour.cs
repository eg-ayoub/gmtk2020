using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobBehaviour : MonoBehaviour
{
    const float REST_TIME = .5f;
    const float MOVE_TIME = 1.5f;
    const float MOVE_SPEED = 25;
    Transform playerTransform;
    float velocity;

    private void Start()
    {
        playerTransform = FindObjectOfType<Player>().transform;
        StartCoroutine(BehaviourLoop());
    }

    private void Update()
    {
        transform.Translate(((Vector2)(playerTransform.position - transform.position)).normalized * velocity * Time.deltaTime);
    }

    IEnumerator BehaviourLoop()
    {
        while (true)
        {
            velocity = MOVE_SPEED;
            yield return new WaitForSecondsRealtime(MOVE_TIME);

            velocity = 0;
            yield return new WaitForSecondsRealtime(REST_TIME);
        }
    }
}
