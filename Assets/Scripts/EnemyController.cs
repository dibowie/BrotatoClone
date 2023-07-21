using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyController : MonoBehaviour
{
    
    [SerializeField] private Transform _target;
    [SerializeField] private float _enemyMoveSpeed;
    private Rigidbody2D _rigidbody;

    private int _enemyMaxHealth = 10;
    private int _enemyCurrentHealth;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _enemyCurrentHealth = _enemyMaxHealth;
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position,_enemyMoveSpeed*Time.fixedDeltaTime);
    }
    
    public void TakeDamage(int damage)
    {
        _enemyCurrentHealth -= damage;
        if (_enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
