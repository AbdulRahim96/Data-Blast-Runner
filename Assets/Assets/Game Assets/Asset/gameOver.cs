using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public Text totalScore, totalCoins;
    public Text highest;
    // Start is called before the first frame update
    void Start()
    {
        totalScore.text = "Total Score: " + Score.score.ToString("0");
        totalCoins.text = "Total Coins: " + Score.coins.ToString("0");
        if (Score.score >= PlayerPrefs.GetFloat("highest", 0))
        {
            highest.text = "New high score";
            PlayerPrefs.SetFloat("highest", Score.score);
        }
        else
            highest.text = "Personal best - " + PlayerPrefs.GetFloat("highest").ToString("0");
    }

    public void saveCoins()
    {
        int coins = PlayerPrefs.GetInt("myCoins");
        int totalCoinsEarned = Score.coins;
        int newCoins = coins + totalCoinsEarned;
        PlayerPrefs.SetInt("myCoins", newCoins);
    }

    public void Continue()
    {
        FindObjectOfType<Player>().Continue();
        slide.count -= 1;
        Destroy(gameObject);
    }
}
