using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float score;
    public GameObject endMenu, mcq;
    public static Action<float> OnScoreChanged;
    public static Action OnGameOver;
    private void Awake()
    {
        Instance = this;
        OnGameOver = null;
        OnScoreChanged = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        OnScoreChanged += ScoreUpdate;
    }

    private void ScoreUpdate(float addScore)
    {
        score += addScore;
    }
    
}