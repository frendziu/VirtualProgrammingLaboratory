using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using System;
using System.Xml;

public class QuestionCollection : MonoBehaviour
{
    //public TextAsset XmlQuestions1;
    //public TextAsset XmlQuestions2;
    //public TextAsset XmlQuestions3;
    //public TextAsset XmlQuestions4;
    //public TextAsset XmlQuestions5;
    private QuizQuestion[] allQuestionsLesson1;
    private QuizQuestion[] allQuestionsLesson2Xml;
    private QuizQuestion[] allQuestionsLesson3Xml;
    private QuizQuestion[] allQuestionsLesson4Xml;
    private QuizQuestion[] allQuestionsLesson5Xml;


    private void Start()
    {
       
    }


    private void Awake()
    {

        LoadallQuestions();
    }

    private void LoadallQuestions()
    {
  

        XmlSerializer serializer = new XmlSerializer(typeof(QuizQuestion[]));
       using (StreamReader streamReader1 = new StreamReader("Questions.xml"))
       {
            allQuestionsLesson1 = (QuizQuestion[])serializer.Deserialize(streamReader1);
       }
        using (StreamReader streamReader2 = new StreamReader("Questions2.xml"))
        {
            allQuestionsLesson2Xml = (QuizQuestion[])serializer.Deserialize(streamReader2);
        }
        using (StreamReader streamReader3 = new StreamReader("Questions3.xml"))
        {
            allQuestionsLesson3Xml = (QuizQuestion[])serializer.Deserialize(streamReader3);
        }
        using (StreamReader streamReader4 = new StreamReader("Questions4.xml"))
        {
            allQuestionsLesson4Xml = (QuizQuestion[])serializer.Deserialize(streamReader4);
        }
        using (StreamReader streamReader5 = new StreamReader("Questions5.xml"))
        {
            allQuestionsLesson5Xml = (QuizQuestion[])serializer.Deserialize(streamReader5);
        }



    }

    

    public QuizQuestion[] ReturnMatchedQuestionArray(int lessonNumber)
    {

        if (lessonNumber == 0)
        {
            return allQuestionsLesson1;
        }
        else if (lessonNumber == 1)
        {
            return allQuestionsLesson2Xml;
        }
        else if (lessonNumber == 2)
        {
            return allQuestionsLesson3Xml;
        }
        else if (lessonNumber == 3)
        {
            return allQuestionsLesson4Xml;
        }
        else
        {
            return allQuestionsLesson5Xml;
        }

    }

    public QuizQuestion GetUnaskedQuestion(QuizQuestion[] array)
    {
        ResetQuestionsIfAllHaveBeenAsked(array);

        var question = array
            .Where(t => t.Asked == false)
            .OrderBy(t => UnityEngine.Random.Range(0, int.MaxValue))
            .FirstOrDefault();

        question.Asked = true;
        return question;
    }

    public QuizQuestion GetAllQuestions(QuizQuestion[] array)
    {
        ResetQuestionsIfAllHaveBeenShowed(array);

        var question = array
            .Where(t => t.Showed == false)
            .OrderBy(t => UnityEngine.Random.Range(0, int.MaxValue))
            .FirstOrDefault();

        question.Asked = true;
        return question;
    }


    private void ResetQuestionsIfAllHaveBeenAsked(QuizQuestion[] array)
    {
        if (array.Any(t => t.Asked == false) == false)
        {
            ResetQuestions(array);
        }
    }

    private void ResetQuestionsIfAllHaveBeenShowed(QuizQuestion[] array)
    {
        if (array.Any(t => t.Showed == false) == false)
        {
            ResetQuestions2(array);
        }
    }

    private void ResetQuestions(QuizQuestion[] array)
    {
        foreach (var question in array)
            question.Asked = false;
    }

    private void ResetQuestions2(QuizQuestion[] array)
    {
        foreach (var question in array)
            question.Showed = false;
    }



}