using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    public void changeScene(int val)
    {
        SceneManager.LoadScene(val);
    }

    public void Restart()
    {
        int num = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(num);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
