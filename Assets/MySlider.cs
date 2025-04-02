using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MySlider : MonoBehaviour
{
    private Slider slider;
    public float targetValue;
    public float targetIncreaseBy = 100;
    
    void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = targetValue;
    }

    private void Start()
    {
        GameManager.OnScoreChanged += UpdateSlider;
    }

    private void UpdateSlider(float val)
    {
        slider.value++;
        if (slider.value >= targetValue)
        {
            targetValue += targetIncreaseBy;
            GameManager.Instance.mcq.SetActive(true);
            slider.maxValue = targetValue;
            slider.value = 0;
        }
    }
}
