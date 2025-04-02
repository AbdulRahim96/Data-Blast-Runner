using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockables : MonoBehaviour
{
    public string productID;

    public void OnEnable()
    {
        gameObject.SetActive(!PlayerPrefs.HasKey(productID));
    }

    public void purchase(int amount)
    {
        
        if (amount > PlayerData.myCoins)
        {
            PlayerData.showMessage("Insufficient Amount");
        }
        else
        {
            PlayerData.myCoins -= amount;
            PlayerPrefs.SetInt("myCoins", PlayerData.myCoins);
            PlayerPrefs.SetString(productID, "1");
            OnEnable();
            Debug.Log(productID + " has been purchased with the amount of " + amount);
        }
    }
}
