using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyController : MonoBehaviour
{

    private GameObject _target;
    [SerializeField] private float _enemyMoveSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 moveDirection;

    private int _enemyMaxHealth = 2;
    private int _enemyCurrentHealth;
    
    [SerializeField] private float _strength;
    [SerializeField] private float _duration;

    private Vector2 _initialScale;
    [SerializeField] private GameObject goldPrefab;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _initialScale = transform.localScale;
        _enemyCurrentHealth = _enemyMaxHealth;
    }

    private void Update()
    {
        EnemyMoveDirection();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(moveDirection.x, moveDirection.y) * _enemyMoveSpeed * Time.fixedDeltaTime;
    }

    private void EnemyMoveDirection()
    {
        Vector3 direction = (PlayerController.Instance.transform.position - transform.position).normalized;
        moveDirection = direction;
    }
    
    public void TakeDamage(int damage)
    {
        _enemyCurrentHealth -= damage;
        transform.DOShakeScale(_duration, _strength).OnComplete(() => ResetScale());
        
        if (_enemyCurrentHealth <= 0)
        {
            StartCoroutine(DeadRoutine());
        }
    }
    
    private void ResetScale()
    {
        transform.localScale = _initialScale;
    }

    private IEnumerator DeadRoutine()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
        MakeGold();
    }

    private void MakeGold()
    {
        Instantiate(goldPrefab, transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PlayerController.Instance)
        {
            PlayerController.Instance.TakeDamage(1);
        }
    }
}
