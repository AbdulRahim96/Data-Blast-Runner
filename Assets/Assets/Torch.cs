using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{

    public ParticleSystem lightParticle;
    public static float lightIntensity = 0.01f;
    public static float particleIntensity;
    public static float resetTime = 10;
    public static float resetSize;


    void Start()
    {
        resetTime = lightParticle.lights.rangeMultiplier;
    }

    void FixedUpdate()
    {
        var lights = lightParticle.lights;
        lights.rangeMultiplier -= lightIntensity;
        lightParticle.startSize = lights.rangeMultiplier / 12.7f;
    }
}
