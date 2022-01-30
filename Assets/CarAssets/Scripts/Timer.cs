using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timerImage;

    float maxTimeFill = 1;
    float minTimeFill = 0;
    public float timeDecresingSpeed = 10;
    private void Awake()
    {
        timerImage.fillAmount = 1f;
    }
    private void Update()
    {
        if(timerImage.fillAmount > minTimeFill)
        timerImage.fillAmount -= Time.deltaTime / timeDecresingSpeed;
    }
}
