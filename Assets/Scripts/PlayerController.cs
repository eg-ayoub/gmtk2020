using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    const float MOVE_SPEED = 100f;
    const float DASH_SPEED = 400f;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidBody;

    private Vector2 _dashSpeed;
    private bool _dashOverride = false;



    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    public void ProcessMove(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        if (!_dashOverride)
        {
            _rigidBody.velocity = _moveDirection * MOVE_SPEED;
        }
        else
        {
            _rigidBody.velocity = _dashSpeed;
        }
    }

    public void StartDash(Vector2 direction)
    {
        _dashSpeed = DASH_SPEED * direction;
        _dashOverride = true;
    }

    public void EndDash()
    {
        _dashOverride = false;
        _rigidBody.velocity = Vector3.zero;
    }
}
