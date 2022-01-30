using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitLog : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private GameObject credits;
    private AudioSource audioToPlay;

    void Awake()
    {
        audioToPlay = this.GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Invoke("WaitForCredits", .1F);
        }   
    }

    void WaitForCredits()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
