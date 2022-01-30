using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseKid : MonoBehaviour
{
    private string sceneToLoad;
    [SerializeField] private GameObject prompt;
    public static ChooseKid current;
    public static int favorBoy;
    public static string previousGender;
    public static int levelsPlayed;
    private bool _loadingScene;

    void Awake()
    {
        current = this;
    }

    public void showPrompt(string _sceneToLoad)
    {
        sceneToLoad = _sceneToLoad;
        prompt.SetActive(true);
    }

    public void Girl()
    {
        previousGender = "Girl";
        favorBoy--;
        if(!_loadingScene)
        {
            _loadingScene = true;
            StartCoroutine(LoadScene());
        }
    }

    public void Boy()
    {
        previousGender = "Boy";
        favorBoy++;
        if(!_loadingScene)
        {
            _loadingScene = true;
            StartCoroutine(LoadScene());
        }
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
        levelsPlayed++;
        yield return new WaitForSeconds(2);
        asyncLoad.allowSceneActivation = true;
    }
}
