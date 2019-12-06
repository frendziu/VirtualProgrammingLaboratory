using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTeleportSpotsOffline : MonoBehaviour
{

   public GameObject teleportLesson2;
   public GameObject teleportLesson3;
   public GameObject teleportLesson4;

    private void Start()
    {
        teleportLesson2.SetActive(false);
        teleportLesson3.SetActive(false);
        teleportLesson4.SetActive(false);
    }
}
