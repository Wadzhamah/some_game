using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text timerText;

    static private DateTime currentTime;
    private float secondTime = 0;

    public static DateTime CurrentTime { get => currentTime; set => currentTime = value; }

    void Update()
    {
        timerText.text = currentTime.ToString("t");

        secondTime += Time.deltaTime;
        if (secondTime >= 1)
        {
            currentTime = currentTime.AddMinutes(1);
            secondTime = 0;
        }
    }
}
