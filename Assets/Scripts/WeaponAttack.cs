using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private float _xdirection;
    [SerializeField] private float _ydirection;
    [SerializeField] private float _cycleTime;
    [SerializeField] private Transform _weaponTransform;
    [SerializeField] private int _damageAmount;
    
    
    
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.T))
        {
            _weaponTransform.DOLocalMove(new Vector3(_xdirection,_ydirection,0), _cycleTime).SetEase(Ease.InFlash).SetLoops(2, LoopType.Yoyo);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("hit");

            EnemyController enemyController = other.GetComponent<EnemyController>();
            enemyController.TakeDamage(_damageAmount);
        }
    }
}
