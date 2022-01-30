using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCarCrash : MonoBehaviour
{
    [SerializeField] private Transform car;
    private Transform _camera;
    private bool track;

    void Awake()
    {
        _camera = this.GetComponent<Transform>();
    }

    void Update()
    {
        if(car.position.x >= _camera.position.x)
        {
            track = true;
        }

        if(track)
            _camera.position = new Vector3(car.position.x, _camera.position.y, -10);
    }
}
