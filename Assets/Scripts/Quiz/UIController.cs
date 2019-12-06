using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UIController : MonoBehaviour
{
    [SerializeField]
    private Text questionText;
    [SerializeField]
    private Button[] answerButtons;

    [SerializeField]
    private GameObject correctAnswerPopup;
    [SerializeField]
    private GameObject wrongAnswerPopup;

    [SerializeField]
    private Text playerScore;


    [SerializeField]
    private GameObject resultPopup;
    [SerializeField]
    private GameObject questionPanel;

    public static int playerStats = 0;
    private int defScore = 0;
    public static int questionNumberVal = 1;
    private int defQuetionNumber = 1;


    private int[] randomNumbers;

    private void Start()
    {
        
    }

    public void SetupUIForQuestion(QuizQuestion question)
    {
 
        questionPanel.SetActive(true);

        correctAnswerPopup.SetActive(false);
        wrongAnswerPopup.SetActive(false);
        resultPopup.SetActive(false);
        questionText.text = question.Question;
        for (int i = 0; i < question.Answers.Length; i++)
        {
           answerButtons[i].GetComponentInChildren<Text>().text = question.Answers[i];
            answerButtons[i].gameObject.SetActive(true);
        }

        for (int i = question.Answers.Length; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
    }

    public void HandleSubmittedAnswer(bool isCorrect)
    {
        ToggleAnswerButtons(false);
        if (isCorrect)
        {
            playerStats++;
            SetPlayerStats(playerStats);
            ShowCorrectAnswerPopup();
        }
        else
        {
            ShowWrongAnswerPopup();
        }

    }

    private void ToggleAnswerButtons(bool value)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(value);
        }
    }

    private void ShowCorrectAnswerPopup()
    {
        correctAnswerPopup.SetActive(true);
    }

    private void ShowWrongAnswerPopup()
    {
        wrongAnswerPopup.SetActive(true);
    }

    public void FinishQuiz()
    {
        correctAnswerPopup.SetActive(false);
        wrongAnswerPopup.SetActive(false);
        questionPanel.SetActive(false);
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
        questionPanel.SetActive(false);
        resultPopup.SetActive(true);
        

    }


    private void SetPlayerStats(int playerSt)
    {
        playerScore.text = playerSt + "/10";
    }

   
    public void ResetPlayerStats()
    {
        playerStats = defScore;
    }

    public void ResetScoreGUI()
    {
        playerScore.text = defScore + "/10";
    }


    public void ResetNumberOfQuestion()
    {
        questionNumberVal = defQuetionNumber;
    }
   
}
