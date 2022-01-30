using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractiveObjectManager : MonoBehaviour
{
    public static InteractiveObjectManager current;
    [SerializeField] private GameObject box;
    [SerializeField] TMP_Text text;
    private AudioSource interactSound;
    [SerializeField] private AudioClip interact, talk;
    private string story;

    private void Awake()
    {
        interactSound = GetComponent<AudioSource>();
        current = this;
    }

    public void Interact(string _story)
    {
        StopAllCoroutines();
        box.SetActive(true);
        interactSound.PlayOneShot(interact, 1F);
        text.text = "*";
        story = _story;
        StartCoroutine(Talk());
    }

    private IEnumerator Talk ()
    {
        text.text = "";
        foreach (char c in story)
        {
            interactSound.pitch = Random.Range(0.8F, 1.2F);
            interactSound.PlayOneShot(talk, 1F);
            text.text += c;
            yield return new WaitForSeconds(0.05F);
        }
        yield return new WaitForSeconds(2);
        box.SetActive(false);
    }
}
