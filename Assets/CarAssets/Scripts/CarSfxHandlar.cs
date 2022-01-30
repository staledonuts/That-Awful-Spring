using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CarSfxHandlar : MonoBehaviour
{
    [Header("Mixers")]
    public AudioMixer audioMixer;

    [Header("Audio Sources")]
    public AudioSource tiresScreechingAudioSource;
    public AudioSource engineAudioSource;
    public AudioSource carHitAudioSource;

    float desiredEnginePitch = 0.5f;
    float tireScreenPitch = 0.5f;

    TopDownCarMovement topDownCarMovement;

    private void Awake()
    {
        topDownCarMovement = GetComponentInParent<TopDownCarMovement>();
    }

    private void Start()
    {
        audioMixer.SetFloat("SFXVolume", 0.5f);
    }

    private void Update()
    {
        UpdateEngineSFX();
        UpdateTiresScreechingSFX();
    }

    void UpdateEngineSFX()
    {
        //Handle Engine SFX
        float velocityMagnitude = topDownCarMovement.GetVelocityMagnitude();

        //Increase the engine volume as the car goes faster
        float desiredEngineVolume = velocityMagnitude * 0.05f;

        //But keep a minimum level so its playes even if the car is idle
        desiredEngineVolume = Mathf.Clamp(desiredEngineVolume, 0.2f, 1.0f);

        engineAudioSource.volume = Mathf.Lerp(engineAudioSource.volume, desiredEngineVolume, Time.deltaTime * 10);

        //To add more variation to the engine sound we also change the pitch
        desiredEnginePitch = velocityMagnitude * 0.2f;
        desiredEnginePitch = Mathf.Clamp(desiredEnginePitch, 0.2f, 1.0f);
        engineAudioSource.pitch = Mathf.Lerp(engineAudioSource.pitch, desiredEnginePitch, Time.deltaTime * 1.5f);
    }

    void UpdateTiresScreechingSFX()
    {
        //Handle tire screeching SFX
        if (topDownCarMovement.IsTireScreeching(out float leteralVelocity, out bool isBraking))
        {
            //If the car is braking we want the tire screech to be louder and also change the pitch
            if (isBraking)
            {
                tiresScreechingAudioSource.volume = Mathf.Lerp(tiresScreechingAudioSource.volume, 1.0f, Time.deltaTime * 10);
                tireScreenPitch = Mathf.Lerp(tireScreenPitch, 0.5f, Time.deltaTime * 10);
            }
            else
            {
                //If we are not braking we still want to play this streech sound if the player is drifting
                tiresScreechingAudioSource.volume = Mathf.Abs(leteralVelocity) * 0.05f;
                tireScreenPitch = Mathf.Abs(leteralVelocity) * 0.1f;
            }
        }
        //Fade out the tire screech SFX if we are not screeching.
        else tiresScreechingAudioSource.volume = Mathf.Lerp(tiresScreechingAudioSource.volume, 0, Time.deltaTime * 10);
            
    }
     Slider sliderBar;
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        //Get the relative velocity of the collision
        float relativeVelocity = collision2D.relativeVelocity.magnitude;

        float volume = relativeVelocity * 0.1f;

        carHitAudioSource.pitch = Random.Range(0.95f, 1.05f);
        carHitAudioSource.volume = volume;

        if (!carHitAudioSource.isPlaying)
            carHitAudioSource.Play();

        if (sliderBar.value > 0)
            sliderBar.value -= relativeVelocity / 2;
        Debug.Log(relativeVelocity);

        if (sliderBar.value <= 0)
            Debug.Log("Game Over");
    }
}
