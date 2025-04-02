using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static Action<int> onPlay;
    public static Action<float> onPitch;
    private AudioSource audioSource;
    public AudioClip[] audioClips;

    private Tween tween;
    private void Awake()
    {
        onPlay = null;
        onPitch = null;
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        onPlay += OnPlay;
        onPitch += OnPitch;
    }

    private void OnPlay(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    private void OnPitch(float pitch)
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
