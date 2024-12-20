using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = false;
    public float gameTime = 0;
    public bool isTimeOver = false;
    public float displayTime = 0;

    float times = 0;
    public float f_time = 0;
    float x = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (isCountDown)
        {
            displayTime = gameTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTimeOver)
        {
            times += Time.deltaTime;

            f_time = times - x;

            if (isCountDown)
            {
                displayTime = gameTime - times;
                if (displayTime <= 0.0f)
                {
                    displayTime = 0.0f;
                    isTimeOver = true;
                }
                
            }
            else
            {
                displayTime = times;
                if (displayTime >= gameTime)
                {
                    displayTime = gameTime;
                    isTimeOver = true;
                }
            }

            x = times;
        }
        else
        {
            f_time = 0;
        }
    }
}
