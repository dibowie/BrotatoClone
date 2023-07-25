using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int _enemyCount;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Vector2 _minPosition;
    [SerializeField] private Vector2 _maxPosition;
    

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            Vector2 randomPosition = GetRandomPosition();
            
            var enemy = Instantiate(_enemyPrefab,randomPosition,Quaternion.identity);
        }
    }
    
    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(_minPosition.x, _maxPosition.x);
        float y = Random.Range(_minPosition.y, _maxPosition.y);
        return new Vector2(x, y);
    }
}
