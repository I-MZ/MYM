using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling: MonoBehaviour
{
    public Transform minuteHand;

    public float rotationSpeed = 6;

    private void Update() 
    {
        float angle = rotationSpeed * Time.deltaTime;
        minuteHand.Rotate(0, 0, angle);
    }
}
