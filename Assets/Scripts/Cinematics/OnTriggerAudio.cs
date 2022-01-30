using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OnTriggerAudio : MonoBehaviour
{
    private AudioSource audioToPlay;
    [SerializeField] private AudioSource driving;

    void Awake()
    {
        audioToPlay = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            driving.Stop();
            audioToPlay.Play();
        }   
    }
}
