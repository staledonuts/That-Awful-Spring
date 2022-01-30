using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource thisAudio;
    private float volume;
    [SerializeField] private float volumeSet;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        thisAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(volume < volumeSet)
        {
            volume += Time.deltaTime / 25;
            thisAudio.volume = volume;
        }
    }
}
