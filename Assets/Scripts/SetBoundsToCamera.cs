using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBoundsToCamera : MonoBehaviour
{

    void Start()
    {
        EdgeCollider2D edge = GetComponent<EdgeCollider2D>();

        Camera cam = Camera.main;

        Vector2 topleft = cam.ViewportToWorldPoint(new Vector3(0, 0));
        Vector2 topright = cam.ViewportToWorldPoint(new Vector3(1, 0));
        Vector2 bottomleft = cam.ViewportToWorldPoint(new Vector3(0, 1));
        Vector2 bottomright = cam.ViewportToWorldPoint(new Vector3(1, 1));

        Vector2[] points = { topleft, topright, bottomright, bottomleft, topleft };

        edge.points = points;

    }

}
