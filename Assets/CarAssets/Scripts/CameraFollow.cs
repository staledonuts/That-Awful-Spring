using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject thingsToFollow;

    void LateUpdate()
    {
        transform.position = thingsToFollow.transform.position + new Vector3(0, 6f, -20);
    }
}
