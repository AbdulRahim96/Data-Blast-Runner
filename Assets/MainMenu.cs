using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Transform targetPoint;
    public ParticleSystem groundEffect;
    public Camera_Orbit virtualCamera;
    public void Play()
    {
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        player.DOMove(targetPoint.position, 0.1f)
            .SetDelay(0.5f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                player.GetComponent<Animator>().Play("Action pose");
                groundEffect.Play();
                virtualCamera.ShakeCamera(5);
            });

        transform.DOMove(transform.position, 1.5f)
            .OnComplete(() =>
            {
                player.GetComponent<Player>().enabled = true;
                gameObject.SetActive(false);
            });
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
