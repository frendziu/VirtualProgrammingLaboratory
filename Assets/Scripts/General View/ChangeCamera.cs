using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Camera FPSController;
    public Camera QuizCamera;

    public void ShowQuizView()
    {
        FPSController.enabled = false;
        QuizCamera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        FPSController.enabled = true;
        QuizCamera.enabled = false;
    }
}
