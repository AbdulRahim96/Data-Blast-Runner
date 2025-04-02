using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Powers : MonoBehaviour
{
    private Animator animator;
    public float duration = 10;
    public UnityEvent onBike, onRun;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    [Button("Activate Bike")]
    public void ActivateBike()
    {
        StartCoroutine(OnBike());
    }

    IEnumerator OnBike()
    {
        onBike.Invoke();
        animator.SetBool("invehicle", true);
        yield return new WaitForSeconds(duration);

        onRun.Invoke();
        animator.SetBool("invehicle", false);

    }
}
