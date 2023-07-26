using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Singleton<PlayerController>
{
    public static event EventHandler OnPlayerAttack;
    
    [SerializeField] private InputController _input;
    [SerializeField] private AnimationController _animation;
    
    
    private Rigidbody2D _rigidbody;
    
    [SerializeField] private float _moveSpeed;
    private bool isFacingRight;
    
    private float areaRadius = 2f;
    [SerializeField] private LayerMask targetLayerMask;

   // public int currentHealth { get; private set; } 
    private int maxHealth = 100;
    public int currentHealth;


    protected override void Awake()
    {
        base.Awake();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        FlipController();
        if (Input.GetKeyDown(KeyCode.T))
        {
            Attack();
        }
        DetectEnemyInArea();
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

    private void DetectEnemyInArea()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, areaRadius, targetLayerMask);

        foreach (var collider in colliders)
        {
            if (collider.gameObject.CompareTag("Enemy"))
            {
                Attack();
                OnPlayerAttack?.Invoke(this,EventArgs.Empty);
            }
            
        }
    }
    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
