using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinsTrigger : MonoBehaviour
{

    public UnityEvent trigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            trigger.Invoke();
    }
}
