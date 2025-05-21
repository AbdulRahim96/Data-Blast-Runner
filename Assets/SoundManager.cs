using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private AudioSource audioSource;
    public AudioClip[] audioClips;

    private Tween tween;
    private void Awake()
    {
        instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPlay(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void OnPitch(float pitch)
    {
        audioSource.pitch += pitch;
        if(tween != null)
        {
            tween.Kill();
        }

        float timer = 1;
        tween = DOTween.To(() => timer, x => timer = x, 0, 2)
        .SetEase(Ease.OutQuad)
               .OnComplete(() =>
               {
                   audioSource.pitch = 0.9f;
               }
               );
    }
}
