using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HitController : MonoBehaviour
{
    private Player _player;
    private AimController _aim;
    private bool _pressed;

    private void Start()
    {
        _aim = GetComponent<AimController>();
        _player = GetComponent<Player>();
    }

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
            _player.DispatchHit(_aim.GetAimVector());
        }
    }

    private void LateUpdate()
    {
        _pressed = false;
    }
}
