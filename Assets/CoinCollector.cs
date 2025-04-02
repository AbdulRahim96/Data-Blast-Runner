using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "coin")
        {
            other.gameObject.GetComponent<Icons>().Collect(transform);
        }
    }
}
