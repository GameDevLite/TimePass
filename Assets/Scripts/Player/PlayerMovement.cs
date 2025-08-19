using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public float moveSpeed;
    public bool isAttacking = false;

    private Vector2 _moveDirection;
    private Animator _animator;
    
    public InputActionReference moveAction;
    public InputActionReference fireAction;
    
    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }

        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    private void Update()
    {
        _moveDirection = moveAction.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
    }

    private void OnEnable()
    {
        fireAction.action.started += Fire;
    }
    
    private void OnDisable()
    {
        fireAction.action.started -= Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        _animator.SetTrigger("Attack");
    }
}
