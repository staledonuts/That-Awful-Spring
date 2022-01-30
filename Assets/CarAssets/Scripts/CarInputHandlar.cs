using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandlar : MonoBehaviour
{
    TopDownCarMovement topDownCarMovement;

    private void Awake()
    {
        topDownCarMovement = GetComponent<TopDownCarMovement>();
    }

    private void Update()
    {
        if(CountdownTimer.current.gameFinished) 
        {
            topDownCarMovement.SetInputVector(new Vector2(0, 0));
            return;
        }
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        topDownCarMovement.SetInputVector(inputVector);
    }
}
