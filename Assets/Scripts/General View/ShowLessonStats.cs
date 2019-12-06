using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowLessonStats : MonoBehaviour
{

    [SerializeField] TextMeshPro quizScore;

    private SaveScore saveScore;

    private int[] playerScoreArray;
    [SerializeField]
    public int boardID;


    private void Start()
    {
        saveScore = FindObjectOfType<SaveScore>();
        SetQuizScore(boardID);
    } 

    private void Update()
    {
        SetQuizScore(boardID);
     
    }
    private void SetQuizScore(int board)
    {
        playerScoreArray = saveScore.getPlayerScoreArray();

        quizScore.text = playerScoreArray[board] + "/10";
    }


}
