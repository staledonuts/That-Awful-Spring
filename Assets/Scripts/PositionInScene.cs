using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PositionInScene : MonoBehaviour
{
    private Transform player;
    private string sceneName;
    private int toUpdate;
    [SerializeField] private List<sceneClass> allScenes;

    void LevelWasLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        sceneName = scene.buildIndex.ToString();
        
        if(GameObject.FindGameObjectWithTag("Player").transform)
            player = GameObject.FindGameObjectWithTag("Player").transform;
        else return;

        for(int i = 0; i < allScenes.Count; i++)
        {
            sceneClass currentScene = allScenes[i];
            if(currentScene.scene == sceneName)
            {
                player.position = currentScene.position;
                toUpdate = i;
                return;
            }
        }
        sceneClass newScene = new sceneClass();
        newScene.scene = sceneName;
        allScenes.Add(newScene);
        toUpdate = allScenes.Count - 1;
    }

    void Update()
    { 
        if(player == null || Door._loadingScene || allScenes.Count <= 0){}
        else
        {
            allScenes[toUpdate].position = player.position;
        }
    }

    void Awake()
    {
        SceneManager.sceneLoaded += LevelWasLoaded;
        DontDestroyOnLoad(gameObject);
    }
}

[System.Serializable]
class sceneClass
{
    public string scene;
    public Vector2 position;
}
