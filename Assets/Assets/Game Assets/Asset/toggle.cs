using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle : MonoBehaviour
{
    //   public GameObject toggleOn;
    //  public GameObject toggleOff;

    public AudioSource audio;
    public Toggle button;
    private bool flag;

    private void Awake()
    {
        if(PlayerPrefs.GetInt("music", 1) == 1)
            button.isOn = true;
        else
        {
            button.isOn = false;
            audio.enabled = false;
        }
    }
    public void _toggle(bool value)
    {
        flag = value;
        if(flag == true)
        {
            PlayerPrefs.SetInt("music", 1);
            audio.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            audio.enabled = false;
        }
    }
}
