using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTween : MonoBehaviour
{
    public Tween movingTween;

    private void OnDestroy()
    {
        if (movingTween != null)
        {
            movingTween.Kill();
        }
    }
}
