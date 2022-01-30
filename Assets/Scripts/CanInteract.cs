using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanInteract : MonoBehaviour
{
    private UnityEngine.Rendering.Universal.Light2D lightinscene;
    private bool increase;
    private float intensity;

    void Awake()
    {
        lightinscene = GetComponent<UnityEngine.Rendering.Universal.Light2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(increase)
        {
            intensity += Time.deltaTime;
            if(intensity > 1)
            {
                increase = false;
            }
        }
        else
        {
            intensity -= Time.deltaTime;
            if(intensity < 0)
            {
                increase = true;
            }
        }

        lightinscene.intensity = intensity;
    }
}
