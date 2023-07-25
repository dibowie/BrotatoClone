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
    private bool canAttack = true;

    private void Start()
    {
        PlayerController.OnPlayerAttack += PlayerController_OnPlayerAttack;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerAttack -= PlayerController_OnPlayerAttack;
    }

    private void PlayerController_OnPlayerAttack(object sender, EventArgs e)
    {
        if (canAttack)
        {
            canAttack = false;
            _weaponTransform.DOLocalMove(new Vector3(_xdirection, _ydirection, 0), _cycleTime).
                SetEase(Ease.InFlash).
                SetLoops(2, LoopType.Yoyo);
            canAttack = false;
            StartCoroutine(TweenTime());
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

    IEnumerator TweenTime()
    {
        yield return new WaitForSeconds(1); 
        canAttack = true;
    }
}
