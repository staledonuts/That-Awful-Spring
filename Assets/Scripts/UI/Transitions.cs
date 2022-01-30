using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transitions : MonoBehaviour
{
    public static Transitions current;
    private Image transitionImage;
    private float time;
    private float audioVol;
    private bool fadeOut;

    private void Awake()
    {
        current = this;
        transitionImage = GetComponent<Image>();
    }

    private void Update()
    {
        if(time < 1)
            time += Time.deltaTime / 2;
        else return;
        
        if(fadeOut)
        {
            AudioListener.volume -= Time.deltaTime;
            transitionImage.color = Color.Lerp(Color.clear, Color.black, time);
        }
        else
        {
            AudioListener.volume += Time.deltaTime;
            transitionImage.color = Color.Lerp(Color.black, Color.clear, time);
        }
    }

    public void FadeOut()
    {
        fadeOut = true;
        time = 0;
    }
}
