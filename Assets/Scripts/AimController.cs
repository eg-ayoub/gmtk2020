using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimController : MonoBehaviour
{
    private Vector3 _lookDir;
    private ArrowController _arrow;

    private void Start()
    {
        _arrow = GetComponentInChildren<ArrowController>();
    }

    private void FixedUpdate()
    {
        Mouse mouse = Mouse.current;
        if (mouse == null)
        {
            Debug.LogError("no mouse!");
            return;
        }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(mouse.position.ReadValue());
        mousePos.z = 0;
        mousePos = transform.InverseTransformPoint(mousePos);

        _lookDir = mousePos;

        // Debug.DrawRay(transform.position, 5 * mousePos.normalized);
        _arrow.SetDirection(mousePos.normalized);
    }

    public Vector3 GetAimVector()
    {
        return _lookDir.normalized;
    }
}
