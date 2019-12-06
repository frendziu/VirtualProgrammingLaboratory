using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCourse1 : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public bool isPlayer;
    private bool isOnline = true;



    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            isPlayer = true;
            if (Input.GetKeyDown(KeyCode.E) && isOnline)
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
        if (isPlayer && isOnline)
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 60, 150, 50), "Naciśnij E, aby wejść do lekcji");

    }
}
