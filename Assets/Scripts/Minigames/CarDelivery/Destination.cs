using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Destination : MonoBehaviour
{
    private AudioSource delivered;
    [SerializeField] private AudioSource dadHa;
    [SerializeField] private TMP_Text text;
    private int packagesDelivered;

    // Start is called before the first frame update
    void Start()
    {
        delivered = GetComponent<AudioSource>();
        packagesDelivered = 0;
        text.text = $"{packagesDelivered}";
    }

    public void DeliveredPackage()
    {
        if(packagesDelivered == 3)
        {
            dadHa.Play();
        }
        delivered.PlayOneShot(delivered.clip, 1F);
        packagesDelivered++;
        text.text = $"{packagesDelivered}";
        PackageSpawner.current.SpawnNew();
    }
}
