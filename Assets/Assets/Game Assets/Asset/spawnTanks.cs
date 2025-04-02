using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTanks : MonoBehaviour
{
    public float min, max, countdown;
    public GameObject tanksPrefab;

    public bool outside;
    // Update is called once per frame
    void Update()
    {
         countdown -= Time.deltaTime;
         if (countdown <= 0)
         {
             if (outside == false)
             {
                 Instantiate(tanksPrefab, transform.position, transform.rotation);
                 countdown = Random.Range(min, max);
             }
         }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "outside")
            outside = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "outside")
            outside = false;
    }
}
