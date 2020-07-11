using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public void SetDirection(Vector3 direction)
    {
        transform.localPosition = 20 * direction;

        float angle = Mathf.Rad2Deg * (direction.y < 0 ? -1 : 1) * Mathf.Acos(direction.x);
        // float angle = -145 + Mathf.Rad2Deg * Mathf.Acos(direction.x);
        // angle = angle < 0 ? angle + 360 : angle;

        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}
