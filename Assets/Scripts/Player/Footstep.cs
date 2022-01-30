using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private float footstepVolume, footstepInterval;
    [SerializeField] private AudioClip[] woodFootsteps;
    private int currentFootstep;
    private float moving;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if(x != 0)
        {
            moving += Time.deltaTime / footstepInterval;
            if(moving >= 1)
            {
                audioSource.pitch = Random.Range(0.8F, 1.5F);
                audioSource.PlayOneShot(woodFootsteps[currentFootstep], footstepVolume);
                currentFootstep++;
                if(currentFootstep >= woodFootsteps.Length)
                {
                    currentFootstep = 0;
                }
                moving = 0;
            }
        }
    }
}
