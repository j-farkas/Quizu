using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
        TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        buttonText.text = question.getAnswer(i);
        }
    }

    public void OnAnswerSelected(int i)
    {
        Image buttonImage;
        if(i == question.getCorrectAnswerIndex())
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }else 
        {
            questionText.text = "The correct answer was: "+ question.getAnswer(correctAnswerIndex);
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
    }

}
