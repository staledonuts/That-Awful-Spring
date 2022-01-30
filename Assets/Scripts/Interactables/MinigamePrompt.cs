using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigamePrompt : MonoBehaviour
{
    [SerializeField] private SpriteRenderer buttonPrompt;
    private AudioSource _doorSound;
    private float _distanceToDoor = 1.5F;
    private float _promptTime;

    private Transform _doorTransform, _playerTransform;

    public static bool _loadingScene;
    private bool _spawnedButtonPrompt;
    private bool _closeToDoor => Vector2.Distance(_doorTransform.position, _playerTransform.position) < _distanceToDoor;
    private bool _playerPressedButton => Input.GetButtonDown("Fire2");

    private void Awake()
    {
        _loadingScene = false;
        _doorSound = GetComponent<AudioSource>();
        _doorTransform = this.transform;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
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
            ChooseKid.current.showPrompt(minigameName);
        }
    }
}