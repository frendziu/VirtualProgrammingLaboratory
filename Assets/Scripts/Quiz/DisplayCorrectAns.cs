using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayCorrectAns : MonoBehaviour
{
    private QuizQuestion[] helpArray;

   private QuestionCollection questionCollection;

    private QuizQuestion currentQuestion;
    private PanelController panelController;
    [SerializeField]
    private float delayBetweenQuestions = 1f;

    private void Start()
    {
        questionCollection = FindObjectOfType<QuestionCollection>();
        panelController = FindObjectOfType<PanelController>();
    }

    public void PresentCorrectAns(int lessonNumber)
    {
        helpArray = questionCollection.ReturnMatchedQuestionArray(lessonNumber);
        PresentAllQuestions1();
    }

    private void PresentAllQuestions1()
    {
        currentQuestion = questionCollection.GetUnaskedQuestion(helpArray);
        panelController.SetupUIForQuestion(currentQuestion);
    }

    public void ShowNext()
    {
        StartCoroutine(ShowNextQuestionAfterDelay());
    }

    private IEnumerator ShowNextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenQuestions);
        PresentAllQuestions1();
    }
}
