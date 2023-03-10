using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;

    [Header("Button Colors")]
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Scoring")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("ProgressBar")]
    [SerializeField] Slider progressBar;

    public bool isComplete;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        getNextQuestion();
        progressBar.maxValue = questions.Count;
        progressBar.minValue = 0;
        progressBar.value = 0;
    }

    void Update() {
        timerImage.fillAmount = timer.fillFraction;
        if(timer.timerValue <= .01 && timer.isAnsweringQuestion)
        {
            OnAnswerSelected(69);
        }
        if(timer.loadNextQuestion)
        {
            getNextQuestion();
            timer.loadNextQuestion = false;
        }
        
        
    }

    void getNextQuestion()
    {
        Debug.Log(questions.Count);
        if(questions.Count >= 0)
        {
            setButtonState();
            setDefaultButtonSprites();
            GetRandomQuestion();
            DisplayQuestion();
        }else{
            Debug.Log("Game's Over");
        }

    }

    void GetRandomQuestion()
    {
        int i = Random.Range(0,questions.Count);
        currentQuestion = questions[i];
    }

    void setDefaultButtonSprites()
    {
        answerButtons[correctAnswerIndex].GetComponent<Image>().sprite = defaultAnswerSprite;
    }

    void DisplayQuestion()
    {
        questionText.text = currentQuestion.GetQuestion();

        for(int i = 0; i < answerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.getAnswer(i);
        }
    }

    void setButtonState()
    {
        for(int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponent<Button>().interactable = !answerButtons[i].GetComponent<Button>().interactable;
        }

    }

    public void OnAnswerSelected(int i)
    {
        Image buttonImage;
        Debug.Log(progressBar.value + " Of " + progressBar.maxValue);
        correctAnswerIndex = currentQuestion.getCorrectAnswerIndex();
        scoreKeeper.incrementQuestionsSeen();
        if(i == correctAnswerIndex)
        {
            questionText.text = "Correct";
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            scoreKeeper.incrementCorrectAnswers();
        }else 
        {
            questionText.text = "The correct answer was: "+ currentQuestion.getAnswer(correctAnswerIndex);
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        setButtonState();
        timer.Answered = true;
        timer.CancelTimer();
        questions.Remove(currentQuestion);
        scoreText.text = "Score: " + scoreKeeper.calculateScore() + "%";
        if(progressBar.value+1 == progressBar.maxValue)
        {
            isComplete = true;
        }else{
        progressBar.value++;
        }

    }

}
