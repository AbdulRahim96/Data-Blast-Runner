using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    public Transform startPoint;
    public Transform currentPos;

    public AudioClip[] audios;
    public AudioSource source, coinSource;

    public static float audioPitch = 1, countdown;
    public float  multiplier = 1, nextLevel = 2, currentLevel = 1;
    public static float score, addPoints, coinMultiplier = 0.1f;
    public static int coins;

    public Text scoreUI, multiplierText, coinsText;
    public Slider multiplierSlider;
    public float tempCion;
    //  public int random;

       private void Awake()
       {
        addPoints = 0;
        countdown = 0;
        coinMultiplier = 0.1f;
        multiplierSlider.minValue = multiplier;
        multiplierSlider.maxValue = nextLevel;
        audioPitch = 1;
        coins = 0;
        //AdsManager.isMenu = false;
       }

    void FixedUpdate()
    {
        

        currentPos = GameObject.FindGameObjectWithTag("Player").transform;

        score = (Vector3.Distance(startPoint.position, currentPos.position)) + (addPoints * currentLevel);
        scoreUI.text = score.ToString("0");

        coinSource.pitch = audioPitch;
        tempCion = coinMultiplier;

        multiplierText.text = "x" + currentLevel.ToString("0");
        multiplierSlider.value = Mathf.Lerp(multiplierSlider.value, multiplier, 0.1f);
        multiplier += 0.01f * Time.deltaTime;
        coinsText.text = "x" + coins.ToString("0");


        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                multiplier += coinMultiplier;
                coinMultiplier = 0.1f;
                audioPitch = 1;
            }
        }

        if (multiplier >= nextLevel)
        {
            nextLevel *= 1.5f;
            multiplierSlider.minValue = multiplier;
            multiplierSlider.maxValue = nextLevel;
            currentLevel++;

        }
    }

    
    
}
