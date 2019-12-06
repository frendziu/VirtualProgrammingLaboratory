using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuizQuestion
{
    public string Question { get; set; }
    public string[] Answers { get; set; }
    public int CorrectAnswer { get; set; }

    public bool Asked { get; set; }

    public bool Showed { get; set; }
}