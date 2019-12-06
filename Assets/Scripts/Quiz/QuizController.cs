using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    private QuestionCollection questionCollection;
    private QuizQuestion currentQuestion;
    private UIController uiController;

    [SerializeField]
    private float delayBetweenQuestions = 2f;

    private bool resetIterator = false;
    private int iterator = 0;
    private bool oneTime = false;

    private QuizQuestion[] helpArray;


    private void Awake()
    {
 
        questionCollection = FindObjectOfType<QuestionCollection>();
        uiController = FindObjectOfType<UIController>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
       
        if (resetIterator)
        {
            iterator = 0;

        }
        
    }

    public void PresentQuestion(int lessonNumber)
    {
        helpArray = questionCollection.ReturnMatchedQuestionArray(lessonNumber);
        PresentQuestion1();


    }

    private void PresentQuestion1()
    {
        currentQuestion = questionCollection.GetUnaskedQuestion(helpArray);
        uiController.SetupUIForQuestion(currentQuestion);
    }

    public void SubmitAnswer(int answerNumber)
    {
 
        bool isCorrect = answerNumber == currentQuestion.CorrectAnswer;
        uiController.HandleSubmittedAnswer(isCorrect);
        resetIterator = false;
        iterator++;
        if(iterator<10)
        {
            StartCoroutine(ShowNextQuestionAfterDelay());
        }
        else
        {
            uiController.FinishQuiz();
           
        }
        
    }

    private IEnumerator ShowNextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(delayBetweenQuestions);
        PresentQuestion1();
    }

    public void ResetIterator()
    {
        resetIterator = true;
    }

 
  

}

