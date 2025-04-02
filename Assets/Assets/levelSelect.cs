using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelSelect : MonoBehaviour
{
    public int index = 0;
    public GameObject[] levels;
    public string[] names;
    public Text text;

    private void Start()
    {
        for (int i = 0; i < levels.Length; i++)
            levels[i].SetActive(false);
        index = 0;
        levels[index].SetActive(true);
        text.text = names[index];
    }
    public void selectionNext()
    {
        if (index != levels.Length - 1)
        {
            levels[index].SetActive(false);
            index++;
            levels[index].SetActive(true);
            text.text = names[index];
        }
    }

    public void selectionPrevious()
    {
        if (index != 0)
        {
            levels[index].SetActive(false);
            index -= 1;
            levels[index].SetActive(true);
            text.text = names[index];
        }
    }

    public void startLevel()
    {
        SceneManager.LoadScene(index + 1);
    }
}
