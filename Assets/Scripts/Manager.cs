using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private bool spawnMusic = true, removeMusic;

    private void Awake()
    {
        // Spawn transition canvas
        GameObject instance = Instantiate(Resources.Load("UI/TransitionCanvas", typeof(GameObject))) as GameObject;
        instance.name = "TransitionCanvas";

        if(!GameObject.Find("BackgroundMusic") && spawnMusic)
        {
            GameObject music = Instantiate(Resources.Load("Global/BackgroundMusic", typeof(GameObject))) as GameObject;
            music.name = "BackgroundMusic";  
        }

        if(!GameObject.Find("PositionInScene"))
        {
            GameObject music = Instantiate(Resources.Load("Global/PositionInScene", typeof(GameObject))) as GameObject;
            music.name = "PositionInScene";  
        }

        if(removeMusic)
        {
            Destroy(GameObject.Find("BackgroundMusic"));
        }
    }
}
