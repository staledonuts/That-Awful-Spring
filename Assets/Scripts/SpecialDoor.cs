using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialDoor : MonoBehaviour
{
    [SerializeField] private GameObject doorInteract, doorNonInteract;

    void Start()
    {
        if(ChooseKid.levelsPlayed >= 4)
        {
            doorInteract.SetActive(true);
            doorNonInteract.SetActive(false);
        }
        else
        {
            doorNonInteract.SetActive(true);
            doorInteract.SetActive(false);
        }
    }
}
