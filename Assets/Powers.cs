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
    public ParticleSystem effect;
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
        effect.Play();
        effect.GetComponent<AudioSource>().Play();
        animator.SetBool("invehicle", true);
        GetComponent<Player>().jumpHeight = 6;
        yield return new WaitForSeconds(duration);

        onRun.Invoke();
        effect.Play();
        animator.SetBool("invehicle", false);
        GetComponent<Player>().jumpHeight = 3;

    }
}
