using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    private AudioSource won;
    public static CountdownTimer current;
    [SerializeField] private string sceneToLoad;
    public bool gameFinished;
    private GameObject next;
    private bool _loadingScene;
    private float secondsLeft = 60;
    private TMP_Text timerText;

    void Awake()
    {
        won = GetComponent<AudioSource>();
        current = this;
    }

    void Start()
    {
        timerText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if(secondsLeft > 0)
            secondsLeft -= Time.deltaTime;
        else if(!_loadingScene)
        {
            _loadingScene = true;
            StartCoroutine(LoadScene());
            gameFinished = true;
        }
        
        timerText.text = $"{(int)secondsLeft}s";
    }
    private IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;

        while (asyncLoad.progress < 0.9F)
        {
            yield return null;
        }

        won.Play();
        yield return new WaitForSeconds(3);
        Transitions.current.FadeOut();
        yield return new WaitForSeconds(2);
        asyncLoad.allowSceneActivation = true;
    }
}
