using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;
        StartCoroutine(pausing(0));
        Debug.Log("Pause");
    }

    private void OnDisable()
    {
        Time.timeScale = 1.2f;
        StartCoroutine(pausing(1.2f));
        Debug.Log("UnPause");
    }
    IEnumerator pausing(float n)
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = n;
    }
}
