using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    private float _healthAmount;

    private void Update()
    {
        FillHealthBar();
    }

    private void FillHealthBar()
    {
        _healthAmount = PlayerController.Instance.currentHealth;
        _healthAmount = Mathf.Clamp(_healthAmount, 0, 100);
        _healthBar.fillAmount = _healthAmount / 100;
    }
}
