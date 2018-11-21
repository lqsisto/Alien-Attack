using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScoreManager : MonoBehaviour
{

    int playerScore;
    // Use this for initialization
    void Start()
    {


    }

    public void SaveScore()
    {


        playerScore = TextController.points;
        PlayerPrefs.SetInt("playerScore", playerScore);
        PlayerPrefs.Save();

    }

    public void GetScore()
    {
        TextController.points = PlayerPrefs.GetInt("playerScore");
    }
        
   
}
