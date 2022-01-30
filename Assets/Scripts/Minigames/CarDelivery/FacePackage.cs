using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePackage : MonoBehaviour
{
    [SerializeField] private Color package, store;
    private SpriteRenderer _renderer;
    [SerializeField] private float turnSpeed;
    public static FacePackage current;
    public Transform closestPackage = null;
    [SerializeField] private Transform destination;

    void Awake()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Start()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(closestPackage == null)
        {
            closestPackage = destination.transform;
        }

        if(closestPackage.transform == destination.transform)
        {
            _renderer.color = store;
        }
        else
        {
            _renderer.color = package;
        }

        var dir = closestPackage.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,angle - 90), turnSpeed * Time.deltaTime);
    }
}
