using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTheory : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject panel;
    public GameObject panelMainView;
    public Camera QuizCamera;
          

    public void SubmitQuit()
    {
        QuizCamera.enabled = false;
        panelMainView.gameObject.SetActive(true);
        panel.gameObject.SetActive(false);
        thePlayer.SetActive(true);
        Cursor.visible = false;
    }

}
