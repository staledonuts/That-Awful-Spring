using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    private TMP_Text _text;
    [SerializeField] private string story;
    [SerializeField] private float speed;
    [SerializeField] private bool removeAfterEnd;
    [SerializeField] private GameObject nextObject;

    private void Awake()
    {
        _text = this.GetComponent<TMP_Text>();
    }

    private void Start()
    {
        StartCoroutine(Talk());
    }

    private IEnumerator Talk ()
    {
        _text.text = "";
        foreach (char c in story)
        {
            _text.text += c;
            yield return new WaitForSeconds(speed);
        }
        yield return new WaitForSeconds(2);
        nextObject.SetActive(true);
        this.gameObject.SetActive(!removeAfterEnd);
    }
}
