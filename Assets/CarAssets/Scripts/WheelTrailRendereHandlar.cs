using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTrailRendereHandlar : MonoBehaviour
{
    TopDownCarMovement topDownCarMovement;
    TrailRenderer trailRenderer;

    void Awake()
    {
        topDownCarMovement = GetComponentInParent<TopDownCarMovement>();
        trailRenderer = GetComponent<TrailRenderer>();

        trailRenderer.emitting = false;
    }

    private void Update()
    {
        //If the car tires are screeching then we'll emitt a trail
        if (topDownCarMovement.IsTireScreeching(out float lateralVelocity, out bool isBraking))
            trailRenderer.emitting = true;
        else trailRenderer.emitting = false;    
    }
}
