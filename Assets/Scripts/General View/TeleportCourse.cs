using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleportCourse : MonoBehaviour
{

    public Transform teleportTarget;
    public GameObject thePlayer;
    public bool isPlayer;
    private bool isOnline = false;

    SaveScore saveScore;
    ChangeCourseColor changeCourseColor;
    ChangeColor2 changeColor;
    ChangeColor3 changeColor1;

    private int scoreValue;
    public int prevLessonID;
  

    private void Awake()
    {
        saveScore = FindObjectOfType<SaveScore>();
        changeCourseColor = FindObjectOfType<ChangeCourseColor>();
        changeColor = FindObjectOfType<ChangeColor2>();
        changeColor1 = FindObjectOfType<ChangeColor3>();
    }

    private void Update()
    {
        MakeCourseOnline();
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag.Equals("Player"))
        {
            isPlayer = true;
            if(Input.GetKeyDown(KeyCode.E)&&isOnline)
            {
                thePlayer.transform.position = teleportTarget.transform.position;
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = false;
        }
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        if (isPlayer&&isOnline)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 150, 50),  "Naciśnij E, aby wejść do lekcji");
        else if(isPlayer)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 150, 50), "Kurs zablokowany");
    }
    
    private void MakeCourseOnline()
    {
        scoreValue = saveScore.getValueFromPlayerScoreArray(prevLessonID);
        if(scoreValue>7)
        {
            isOnline = true;
            if(prevLessonID == 0)
            {
                changeCourseColor.ChangeColor();
            }
            else if(prevLessonID ==1)
            {
                changeColor.ChangeColor();
            }
            else if (prevLessonID == 2)
            {
                changeColor1.ChangeColor();
            }
        }
    }
   
}
