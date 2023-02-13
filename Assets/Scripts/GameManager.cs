using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz quiz;
    WinScreen endScreen;

    void Start()
    {
        quiz = FindObjectOfType<Quiz>();
        endScreen = FindObjectOfType<WinScreen>();

        quiz.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);

    }

    void endGame()
    {
       
            quiz.gameObject.SetActive(false);
            endScreen.gameObject.SetActive(true);
    }
    void Update()
    {
         if (quiz.isComplete)
        {
            endGame();
        }
    }

    public void onReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().BuildIndex);
    }
}
