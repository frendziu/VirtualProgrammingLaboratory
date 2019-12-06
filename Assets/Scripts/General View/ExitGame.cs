using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public bool isPlayer;
    public GameObject Player;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                QuitGame();

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
        if (isPlayer)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 150, 50), "Naciśnij E aby zakończyć grę");
    }

    private void QuitGame()
    {
        Application.Quit();
        Debug.Log("exit");
    }
}
