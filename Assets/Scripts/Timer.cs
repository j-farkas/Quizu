using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool isAnsweringQuestion = false;
    float timerValue;

    void Update()
    {
        updateTimer();
    }

    void updateTimer()
    {
        timerValue -= Time.deltaTime;

        if(timerValue <= 0)
        {
            timerValue = isAnsweringQuestion ? timerValue = timeToCompleteQuestion : timerValue = timeToShowCorrectAnswer;
            isAnsweringQuestion = !isAnsweringQuestion;

        }
        Debug.Log(timerValue);
    }
}
