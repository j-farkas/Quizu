using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
   
    void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void showFinalScore()
    {
        finalScoreText.text = "Congratulations!\nYou got a score of " + scoreKeeper.calculateScore() + "%";
    }

}
