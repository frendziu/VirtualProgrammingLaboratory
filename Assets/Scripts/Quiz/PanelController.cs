using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private Text questionText;

    
    [SerializeField]
    private Text[] answersText;

    [SerializeField]
    private Text correctQuestionText;

    public void SetupUIForQuestion(QuizQuestion question)
    {
        questionText.text = question.Question;

        for (int i = 0; i < question.Answers.Length; i++)
        {
            answersText[i].GetComponentInChildren<Text>().text = i+1+"). "+question.Answers[i];
            answersText[i].gameObject.SetActive(true);
        }

        for (int i = question.Answers.Length; i < answersText.Length; i++)
        {
            answersText[i].gameObject.SetActive(false);
        }

        correctQuestionText.text = question.CorrectAnswer+1+"). "+ question.Answers[question.CorrectAnswer];
    }
}
