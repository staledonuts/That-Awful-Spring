using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUncontrolable : MonoBehaviour
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(speed < 15)
        {
            speed += Time.deltaTime;
        }
                    transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.right, speed * Time.deltaTime);
    }
}
