using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TimerScript : MonoBehaviour
{

    float currentTime = 0;
    float startingTime = 60;

    [SerializeField]
    TextMeshProUGUI timerText;

    public bool IsStarted = false;
    public bool IsEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsStarted) return;
        currentTime -= 1* Time.deltaTime;
        timerText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            IsEnd = true;
        }
    }
}
