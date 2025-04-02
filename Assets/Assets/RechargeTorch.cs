using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeTorch : MonoBehaviour
{
    public GameObject ringParticle;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            resetTorch(FindObjectOfType<Torch>().GetComponent<ParticleSystem>());
            GameObject obj = Instantiate(ringParticle, other.transform.position, other.transform.rotation);
            obj.transform.SetParent(other.transform);
            Destroy(obj, 2);
        }
    }

    public void resetTorch(ParticleSystem particle)
    {
        var light = particle.lights;
        light.rangeMultiplier = Torch.resetTime;

    }
}
