using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderSwitcherGameobj : MonoBehaviour
{
    [SerializeField] private GameObject girl, boy;

    // Start is called before the first frame update
    void Start()
    {
        if(ChooseKid.previousGender == "Girl")
        {
            girl.SetActive(true);
            boy.SetActive(false);
        }
        else
        {
            girl.SetActive(false);
            boy.SetActive(true);
        }
    }
}
