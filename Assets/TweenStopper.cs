using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DG.Tweening.DOTweenAnimation;

public class TweenStopper : DestroyTrigger
{
    private float defaultZ;
    public float zMove = 0.5f;

    private void Start()
    {
        defaultZ = transform.position.z;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(destroyTag))
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zMove);

        base.OnTriggerEnter(other);
    }

    

    public void ResetPosition()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, defaultZ);
    }
}
