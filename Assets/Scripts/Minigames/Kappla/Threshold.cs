using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Threshold : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    private GameObject[] kapplas;
    private float time;
    private bool _loadingScene;
    private bool inArea;

    private void Awake()
    {
        kapplas = GameObject.FindGameObjectsWithTag("Player");
    }

    private void Update()
    {
        if(MoveKappla.hookedWithOther) return;

        foreach (GameObject item in kapplas)
        {
            if(item.transform.position.y > transform.position.y)
            {
                time += Time.deltaTime;
            }
        }

        if(time > 3 && !_loadingScene)
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

        Transitions.current.FadeOut();
        yield return new WaitForSeconds(2);
        asyncLoad.allowSceneActivation = true;
    }
}
