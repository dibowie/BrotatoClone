using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        Coin.OnCoinCollect += OnCoinCollect;
    }

    private void OnCoinCollect(object sender, EventArgs e)
    {
        score++;
        
    }

    private void Update()
    {
        UpdateScoreText();
    }

    private void OnDisable()
    {
        Coin.OnCoinCollect -= OnCoinCollect;
    }
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
    
}
