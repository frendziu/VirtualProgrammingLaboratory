using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ending : MonoBehaviour
{
    public TextMeshPro finalText;
    public TextMeshPro text1;
    public TextMeshPro text2;
    public TextMeshPro text3;

    SaveScore saveScore;
    int finalLessonScore;

    private void Awake()
    {
        saveScore = FindObjectOfType<SaveScore>();
    }

    private void Update()
    {
        finalLessonScore = saveScore.getValueFromPlayerScoreArray(3);
        if (finalLessonScore > 7)
        {
            text1.enabled = true;
            text2.enabled = true;
            text3.enabled = true;
            finalText.text = "4. Po ukończeniu wszystkich lekcji uzyskałeś"; 
            text1.text = " dostęp do wszystkich pytań wraz z odpowiedziami.";
            text2.text = "Powróć do lekcji i wykonaj akcje przy kanapie, aby";
            text3.text = " poznać wszystkie pytania i poprawne odpowiedzi do nich.";
        }
    }

   
}
