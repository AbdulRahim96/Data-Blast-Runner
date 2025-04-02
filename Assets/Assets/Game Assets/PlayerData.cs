using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public static int myCoins;
    public Text coinText;
    public GameObject errorBox;
    public GameObject rewardMenu;
    void Start()
    {
        myCoins = PlayerPrefs.GetInt("myCoins", 0);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = myCoins.ToString("0");
    }

    void errerMessage(string text)
    {
        GameObject obj;
        obj = Instantiate(errorBox, transform.position, transform.rotation);
        obj.GetComponentInChildren<Text>().text = text;
        Destroy(obj, 2);
    }

    public static void showMessage(string text)
    {
        PlayerData msg = FindObjectOfType<PlayerData>();
        msg.errerMessage(text);
    }

    public void reward()
    {
        GameObject obj = Instantiate(rewardMenu, transform.position, transform.rotation);
        Destroy(obj, 2);
    }
}
