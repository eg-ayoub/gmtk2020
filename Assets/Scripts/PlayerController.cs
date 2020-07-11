using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    const float MOVE_SPEED = 100f;
    private Vector2 _moveDirection;
    private Rigidbody2D _rigidBody;


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
        _rigidBody.velocity = _moveDirection * MOVE_SPEED;
    }
}
