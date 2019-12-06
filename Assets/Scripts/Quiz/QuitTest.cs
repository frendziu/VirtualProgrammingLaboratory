using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTest : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject panel;
    public Camera FPSController;
    public Camera QuizCamera;

    private QuizController quizController;

    private void Awake()
    {
        quizController = FindObjectOfType<QuizController>();
    }
    public void SubmitQuit()
    {
        QuizCamera.enabled = false;
        panel.gameObject.SetActive(false);
        thePlayer.SetActive(true);
        Cursor.visible = false;
        quizController.ResetIterator();
       
    }
}


 
