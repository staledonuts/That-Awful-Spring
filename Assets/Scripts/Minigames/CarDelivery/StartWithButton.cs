using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWithButton : MonoBehaviour
{
    [SerializeField] private GameObject[] next;
    private float waitUntil;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in next)
        {
            item.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(waitUntil < 1)
            waitUntil += Time.deltaTime;
        if(Input.anyKeyDown && waitUntil > .5F)
        {
            foreach (GameObject item in next)
            {
                item.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
