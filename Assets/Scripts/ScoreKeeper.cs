using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int correctAnswers = 0;
    int QuestionsSeen = 0;


    public int getCorrectAnswers()
    {
        return correctAnswers;
    }

    public void incrementCorrectAnswers()
    {
        correctAnswers++;
    }

    public int getQuestionsSeen()
    {
        return QuestionsSeen;
    }

    public void incrementQuestionsSeen()
    {
        QuestionsSeen++;
    }

    public int calculateScore()
    {
        return Mathf.RoundToInt((float)correctAnswers / (float)QuestionsSeen * 100);
    }
}
