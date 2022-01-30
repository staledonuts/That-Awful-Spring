using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawner : MonoBehaviour
{
    public static PackageSpawner current;
    [SerializeField] private float bounds;
    [SerializeField] private GameObject packagePrefab;

    void Awake()
    {
        current = this;
    }

    void Start()
    {
        SpawnNew();
    }

    public void SpawnNew()
    {
        Vector3 spawnableArea = new Vector3(Random.Range(-bounds, bounds), Random.Range(-bounds, bounds));
        var package = Instantiate(packagePrefab, spawnableArea, Quaternion.identity);
        FacePackage.current.closestPackage = package.transform;
    }
}
