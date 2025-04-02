using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rewardCoins : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(10, 100);
        text.text = "x" + random.ToString("0");

        PlayerData.myCoins += random;
        PlayerPrefs.SetInt("myCoins", PlayerData.myCoins);
    }

}
