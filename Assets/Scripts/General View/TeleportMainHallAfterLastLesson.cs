using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMainHallAfterLastLesson : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public bool isPlayer;
    public GameObject endPanel;
    public Camera FPSController;
    public Camera QuizCamera;

    private int finalLessonScore = 0;
    private bool isTeleported = true;
    SaveScore saveScore;

    private void Start()
    {
        saveScore = FindObjectOfType<SaveScore>();
    }

    private void Update()
    {
        finalLessonScore = saveScore.getValueFromPlayerScoreArray(3);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                isTeleported = false;
                ShowEndPanel();
            }
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = false;
            isTeleported = true;
        }
    }

    private void ShowEndPanel()
    {
        if (finalLessonScore > 7)
        {
            endPanel.SetActive(true);
            thePlayer.SetActive(false);
            Cursor.visible = true;
        }
        else { thePlayer.transform.position = teleportTarget.transform.position; }
    }

    private void OnGUI()
    {
        GUI.contentColor = Color.red;
        if (isPlayer&&isTeleported)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 150, 50), "Naciśnij E, aby opuścić kurs i wrócić do Pokoju Wyboru");
    }

    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void ReturnToGame()
    {
        endPanel.gameObject.SetActive(false);
        thePlayer.transform.position = teleportTarget.transform.position;
        thePlayer.SetActive(true);
        Cursor.visible = false;
    }
}
