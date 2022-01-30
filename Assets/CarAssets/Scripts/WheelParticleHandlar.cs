using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelParticleHandlar : MonoBehaviour
{
    float particleEmissionRate = 0;

    TopDownCarMovement topDownCarMovement;

    ParticleSystem particleSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;

    private void Awake()
    {
        topDownCarMovement = GetComponentInParent<TopDownCarMovement>();

        particleSystemSmoke = GetComponent<ParticleSystem>();

        particleSystemEmissionModule = particleSystemSmoke.emission;

        particleSystemEmissionModule.rateOverTime = 0;
    }

    private void Update()
    {
        //Reduce the particles over time.
        particleEmissionRate = Mathf.Lerp(particleEmissionRate, 0, Time.deltaTime * 5);
        particleSystemEmissionModule.rateOverTime = particleEmissionRate;

        if(topDownCarMovement.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            //If the car tires are screeching then we'll emitt smoke. If the player is braking then emitt a lot of smoke.
            if (isBraking)
                particleEmissionRate = 30;
            else particleEmissionRate = Mathf.Abs(lateralVelocity) * 2;
        }

    }
}
