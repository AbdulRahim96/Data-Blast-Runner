using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Icons : MonoBehaviour
{
    public RespawnObjects respawnObjects;
    public float _speed;
    public float points = 10;

    public void Collect(Transform Player)
    {
        Transform parent = transform.parent;
        transform.SetParent(Player);
        Vector3 initialPos = transform.position;
        transform.DOLocalMove(Vector3.zero, _speed)
            .SetEase(Ease.Linear)
            .OnComplete(
            () =>
            {
                Player.GetComponent<ParticleSystem>().Play();
                respawnObjects.respawn(gameObject);
                transform.SetParent(parent);
                transform.position = initialPos;
                gameObject.SetActive(false);
                GameManager.OnScoreChanged?.Invoke(points);
                SoundManager.instance.OnPlay(0);
                 SoundManager.instance.OnPitch(0.03f);
            });
    }
}
