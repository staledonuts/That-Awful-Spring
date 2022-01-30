using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstSceneManager : MonoBehaviour
{
    [SerializeField] AudioSource musicAudioSorce;
    [SerializeField] AudioSource highwayAudioSorce;
    [SerializeField] AudioSource fatherAudioSorce;
    [SerializeField] AudioSource emergencyAudioSorce;
    float volume = 0;
    [SerializeField] private string sceneToLoad;
    [SerializeField] float volumeIncresingSpeed = 0.1f;
    [SerializeField] float emergencySoundDelay = 4f;
    [SerializeField] float textDelay = 13f;
    [SerializeField] GameObject sisHText;

    private void Awake()
    {
        musicAudioSorce.volume = 1;
        highwayAudioSorce.volume = 1;
        fatherAudioSorce.volume = 0;
        emergencyAudioSorce.volume = 1;
    }
    private void Start()
    {
        Invoke("Play911Sound", emergencySoundDelay);
        Invoke("ShowText", textDelay);
        Invoke("NextScene", textDelay + 7);
    }
    private void Update()
    {
        if(volume <= 1)
        {
            volume += Time.deltaTime * volumeIncresingSpeed;
            fatherAudioSorce.volume = volume;
        }
        
    }
    void Play911Sound()
    {
        emergencyAudioSorce.Play();
    }

    void NextScene()
    {
        StartCoroutine(LoadScene());
    }
    private IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9F)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1);
        Transitions.current.FadeOut();
        yield return new WaitForSeconds(4);
        asyncLoad.allowSceneActivation = true;
    }

    void ShowText()
    {
        sisHText.SetActive(true);
    }

}
