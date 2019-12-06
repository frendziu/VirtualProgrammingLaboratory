using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeColor3 : MonoBehaviour
{

    private TextMeshPro LessonName;

    private void Awake()
    {
        LessonName = gameObject.GetComponent<TextMeshPro>();
    }

    public void ChangeColor()
    {
        LessonName.color = new Color32(0, 128, 0, 255);
    }
}
