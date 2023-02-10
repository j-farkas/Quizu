using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Quiz Question", fileName="New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2,6)]
    [SerializeField] string question = "Enter New Question Text Here";
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;

    public string GetQuestion(){
        return question;
    }

    public string getAnswer(int i)
    {
        return answers[i];
    }

    public int getCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
}
