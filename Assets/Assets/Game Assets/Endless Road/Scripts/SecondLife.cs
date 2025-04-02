using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondLife : MonoBehaviour
{

    public GameObject secondCar;
    public Transform secondCarPos;
    public bool _continue;
    public GameObject[] allObjects;
    public Slider adButton;
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }


    // Update is called once per frame
    public void secondChance()
    {
        
        Instantiate(secondCar, secondCarPos.position, Quaternion.identity);
        Time.timeScale = 1;
    }
    public void FixedUpdate()
    {
        adButton.value -= 1 * Time.deltaTime;
        if(adButton.value <= 0)
        {
            Destroy(adButton.gameObject);
        }

        


        allObjects = GameObject.FindGameObjectsWithTag("Bricks");
        for (int i = 0; i < allObjects.Length; i++)
        {
            DestroyImmediate(allObjects[i]);
        }
    }
    public void addingScore()
    {
        Debug.Log("score is added");
     //   playServices.AddScoreToLeaderboard();
    }

}
