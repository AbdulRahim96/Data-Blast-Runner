using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bats : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject batParticle;
    public float DestroyTime = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject obj = Instantiate(batParticle, spawnPoint.position, spawnPoint.rotation);
            Destroy(obj, DestroyTime);
        }
    }
}
