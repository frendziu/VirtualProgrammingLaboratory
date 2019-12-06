using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAllQuestionsPanel : MonoBehaviour
{
    public GameObject panel;
    public GameObject thePlayer;
    public bool isPlayer;
    public bool isAwaiable = false;
    public bool showGUI = true;


    public Camera FPSController;
    public Camera QuizCamera;
    public int numberOfQuiz;
    private DisplayCorrectAns displayCorrectAns;
    private SaveScore saveScore;


    int finalLessonScore = 0;

    private void Start()
    {
        displayCorrectAns = FindObjectOfType<DisplayCorrectAns>();
        saveScore = FindObjectOfType<SaveScore>();
        ChangeFlags();
    }

    private void Update()
    {
        ChangeFlags();
    }

    void ChangeFlags()
    {
        finalLessonScore = saveScore.getValueFromPlayerScoreArray(3);
        if (finalLessonScore > 2)
        {
            isAwaiable = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = true;

            if (Input.GetKeyDown(KeyCode.E) && isAwaiable && showGUI)
            {
               displayCorrectAns.PresentCorrectAns(numberOfQuiz);
                CamPosSav.MyCamPos = FPSController.transform.position;
                panel.gameObject.SetActive(true);
                QuizCamera.transform.position = CamPosSav.MyCamPos;
                Cursor.visible = true;
                thePlayer.SetActive(false);
                showGUI = false;
            }
         

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = false;
            showGUI = true;
        }
    }

    public void SubmitQuit()
    {

        panel.gameObject.SetActive(false);
        thePlayer.SetActive(true);
        Cursor.visible = false;

    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        if (isPlayer && isAwaiable && showGUI)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 300, 50), "Naciśnij E, aby zobaczyć wszyskie pytania z poprawnymi odpowiedziami");
       

    }

}
