using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputController _input;
    [SerializeField] private AnimationController _animation;
    
    
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private float _moveSpeed;
    private bool isFacingRight;
    

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FlipController();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    private void PlayerMove()
    {
        _rigidbody.MovePosition(_rigidbody.position + _input.InputDirection * _moveSpeed * Time.fixedDeltaTime);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f,180f,0f);
    }
    private void FlipController()
    {
        if (_input.InputDirection.x < 0 && isFacingRight)
        {
             Flip();
        }
        else if (_input.InputDirection.x > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    private void Attack()
    { 
        _animation.SetAttackAnimation();
    }
}
