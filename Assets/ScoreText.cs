using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private float currentCoins;
    private TextMeshProUGUI scoreText;
    void Start()
    {
        GameManager.OnScoreChanged += UpdateUI;
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = $"Score: {currentCoins}";
    }

    private void UpdateUI(float addVal)
    {
        // create DoTween to update score text
        float prevCoins = currentCoins;
        currentCoins += addVal;

        DOTween.To(() => prevCoins, x => prevCoins = x, currentCoins, 0.5f)
        .SetEase(Ease.OutQuad)
               .OnUpdate(() =>
               {
                   scoreText.text = "Score: " + prevCoins.ToString("0");
               }
               );


    }
}
