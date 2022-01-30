using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private KeyCode keyOverride;
    [SerializeField] private SpriteRenderer buttonPrompt;
    private Animator _doorAnimator;
    private AudioSource _doorSound;
    private Animator _buttonPromptAnimation;
    private float _distanceToDoor = 1.5F;
    private float _promptTime;

    private Transform _doorTransform, _playerTransform;

    public static bool _loadingScene;
    private bool _spawnedButtonPrompt;
    private bool _closeToDoor => Vector2.Distance(_doorTransform.position, _playerTransform.position) < _distanceToDoor;
    private bool _playerPressedButton => Input.GetButtonDown("Fire2") || Input.GetKey(keyOverride);

    private void Awake()
    {
        _loadingScene = false;
        _doorSound = GetComponent<AudioSource>();
        _doorAnimator = GetComponent<Animator>();
        _doorTransform = this.transform;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _buttonPromptAnimation = buttonPrompt.GetComponent<Animator>();
    }

    private void Update ()
    {
        if(_closeToDoor)
        {
            if(_promptTime < 1)
                _promptTime += Time.deltaTime * 5;
            buttonPrompt.color = Color.Lerp(Color.clear, Color.white, _promptTime);
        }
        else
        {
            if(_promptTime > 0)
                _promptTime -= Time.deltaTime * 5;
            buttonPrompt.color = Color.Lerp(Color.clear, Color.white, _promptTime);
        }

        if(_closeToDoor && _playerPressedButton && !_loadingScene)
        {
            _loadingScene = true;
            // Play animation
            _doorSound.Play();
            _doorAnimator.Play("DoorOpen");
            _buttonPromptAnimation.Play("Pushittothelimit");
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
        yield return new WaitForSeconds(2);
        asyncLoad.allowSceneActivation = true;
    }
}