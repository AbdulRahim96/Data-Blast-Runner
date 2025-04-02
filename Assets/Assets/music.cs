using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public AudioClip[] audios;
    public AudioSource source;
    void Start()
    {
        int random;
        random = Random.Range(0, audios.Length);
        source.clip = audios[random];
        source.Play();
    }


}
