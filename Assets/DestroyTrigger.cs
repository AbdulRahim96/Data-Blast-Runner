using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTrigger : MonoBehaviour
{
    public string destroyTag = "Obstacles";
    public DestroyType destroyType;
    public enum DestroyType
    {
        Destroy,
        Stop
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(destroyTag))
        {
            if (destroyType == DestroyType.Stop)
                other.gameObject.GetComponent<MovingTween>().movingTween.Pause();
            else
                Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.CompareTag(destroyTag))
        {
            if (destroyType == DestroyType.Stop)
                obj.GetComponent<MovingTween>().movingTween.Play();
        }
    }
}
