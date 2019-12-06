using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenTheory : MonoBehaviour
{

    public GameObject panel;
    public GameObject panelMainView;

    public GameObject thePlayer;
    public bool isPlayer;

    public Camera FPSController;
    public Camera QuizCamera;

    private CamPosSav CamPosSav;

    public bool isOpen = true;
    public int theoryNumber;
    private string lessonName;
    public int lessonNumber;

    Load load;

    private void Awake()
    {
        load = FindObjectOfType<Load>();
    }

    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = true;

            if (Input.GetKeyDown(KeyCode.E)&& isOpen)
            {
                QuizCamera.enabled = true;
                matchTheoryToLesson(lessonNumber);
                isOpen = false;
                load.PopulateText(theoryNumber);
                CamPosSav.MyCamPos = FPSController.transform.position;
                panel.gameObject.SetActive(true);
                QuizCamera.transform.position = CamPosSav.MyCamPos;
                Cursor.visible = true;
                thePlayer.SetActive(false);

            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = false;
            isOpen = true;
        }
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        if (isPlayer&& isOpen)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 150, 50), "Naciśnij E aby otworzyć teorie");
    }

    private void matchTheoryToLesson(int lessonNumber)
    { 
        
        
        if(lessonNumber==0)
        {
            load.LoadTheoryData("Język CPP - podstawy.");
        }
        else if(lessonNumber==1)
        {
            load.LoadTheoryData("Instrukcje warunkowe oraz pętle.");
        }
        else if (lessonNumber == 2)
        {
            load.LoadTheoryData("Funkcje w języku C++.");
        }
        else if (lessonNumber == 3)
        {
            load.LoadTheoryData("Tablice statyczne oraz dynamiczne.");
        }
        else if (lessonNumber == 4)
        {
            load.LoadTheoryData("Programowanie obiektowe w języku C++.");
        }
    }
   


}
