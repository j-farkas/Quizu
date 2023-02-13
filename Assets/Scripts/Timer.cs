using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 5f;
    [SerializeField] float timeToShowCorrectAnswer = 5f;

    public bool isAnsweringQuestion = false;
    public bool loadNextQuestion;
    public bool Answered = false;
    public float fillFraction;
    public float timerValue;

    void Update()
    {
        updateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void updateTimer()
    {
        timerValue -= Time.deltaTime;

        if(timerValue >= 0)
        {
            fillFraction = isAnsweringQuestion ? fillFraction = timerValue / timeToCompleteQuestion : fillFraction = timerValue / timeToShowCorrectAnswer;
        }
        else
        {
            timerValue = isAnsweringQuestion ? timerValue = timeToShowCorrectAnswer : timerValue = timeToCompleteQuestion;
            isAnsweringQuestion = !isAnsweringQuestion;
            if(isAnsweringQuestion)
            {
                loadNextQuestion = true;
            }
        }
    }
}
