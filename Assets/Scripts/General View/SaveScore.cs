using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour
{
    public int[] playerScoreArray;

    private void Start()
    {
        playerScoreArray = new int[4];
       
    }


    private void Awake()
    {

    }

   
    public void SaveStats(int val)
    {
        playerScoreArray[val] = UIController.playerStats;

    }

    public void setPlayerScoreArray(int[] array)
    {
        for (int i = 0; i < 4; i++)
        {
            playerScoreArray[i] = array[i];
        }
    }

    public void DisplayScore(int val)
    {
        Debug.Log("wynik z kursu");

        Debug.Log(playerScoreArray[val]);

    }

    public int[] getPlayerScoreArray()
    {
        return playerScoreArray;
    }

    public int getValueFromPlayerScoreArray(int val)
    {
        return playerScoreArray[val];
    }




}
