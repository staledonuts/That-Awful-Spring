using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackagePickup : MonoBehaviour
{
    private AudioSource pickup;
    private bool hasPackage;

    void Awake()
    {
        pickup = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Package"))
        {
            pickup.PlayOneShot(pickup.clip, 1F);
            hasPackage = true;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Destination") && hasPackage)
        {
            other.GetComponent<Destination>().DeliveredPackage();
            hasPackage = false;
        }
    }
}
