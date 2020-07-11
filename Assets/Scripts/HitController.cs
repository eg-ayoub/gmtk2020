using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitController : MonoBehaviour
{

    private bool _pressed;

    public void ProcessHit(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _pressed = true;
        }
    }

    private void Update()
    {
        if (_pressed)
        {
            Debug.Log("boom");
        }
    }

    private void LateUpdate()
    {
        _pressed = false;
    }
}
