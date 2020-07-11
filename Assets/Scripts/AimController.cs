using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimController : MonoBehaviour
{
    private Quaternion _lookDir;
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

        // _lookDir = Quaternion.LookRotation(mousePos);
        // Vector3 _dbgLookAt = _lookDir.

        mousePos = transform.InverseTransformPoint(mousePos);
        Debug.DrawRay(transform.position, 2 * mousePos.normalized);
    }
}
