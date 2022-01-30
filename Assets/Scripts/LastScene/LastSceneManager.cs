using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastSceneManager : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject girl, boy;
    [SerializeField] AudioSource musicAudioSorce;
    [SerializeField] AudioSource highwayAudioSorce;
    [SerializeField] AudioSource fatherAudioSorce;
    [SerializeField] AudioSource emergencyAudioSorce;
    [SerializeField] AudioSource policeSund;
    float volume = 0;
    [SerializeField] float volumeIncresingSpeed = 0.1f;
    [SerializeField] float emergencySoundDelay = 4f;
    [SerializeField] float fatherCriesAgainDelay = 0f;
    [SerializeField] float policeComingDelay = 0f;
    [SerializeField] float fatherCriesSound = 0f;
    [SerializeField] float textDelay = 13f;
    [SerializeField] GameObject sisHText;

    private void Awake()
    {
        musicAudioSorce.volume = 0;
        highwayAudioSorce.volume = 1;
        fatherAudioSorce.volume = 1;
        emergencyAudioSorce.volume = 1;

        if(ChooseKid.favorBoy > 0)
            Destroy(boy);
        else
        {
            Destroy(girl);
        }
    }
    private void Start()
    {
        Invoke("Play911Sound", emergencySoundDelay);
        Invoke("FatherCriesAgain", fatherCriesAgainDelay);
        Invoke("PoliceSound", emergencySoundDelay);
        Invoke("FatherCries", fatherCriesSound);
        Invoke("ShowText", textDelay);
    }
    private void Update()
    {
        if (volume <= 1)
        {
            volume += Time.deltaTime * volumeIncresingSpeed;
            //fatherAudioSorce.volume = volume;
            musicAudioSorce.volume = volume;
        }

    }
    void Play911Sound()
    {
        emergencyAudioSorce.Play();
        
    }
    void FatherCries()
    {
        fatherAudioSorce.Play();
    }
    void PoliceSound()
    {
        policeSund.Play();
    }
    void FatherCriesAgain()
    {
        fatherAudioSorce.Play();
    }
    void ShowText()
    {
        anim.Play("depressoEspresso");
    }
}
