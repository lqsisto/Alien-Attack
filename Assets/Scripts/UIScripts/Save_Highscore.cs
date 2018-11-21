using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Save_Highscore : MonoBehaviour
{

    public int playerScore = 0;
    public static int playerDeaths;
    public static string playerName;

    InputField playerNameInput;

    HighscoreManager highscoreManager;

    // Use this for initialization
    void Start()
    {
        

        playerNameInput = GetComponent<InputField>();

        highscoreManager = GameObject.Find("HighscoreManager").GetComponent<HighscoreManager>();

    }


    string SavePlayerName()
    {
        return playerNameInput.text;
    }

    public void SaveHighscore()
    {

        bool pressed = false;

        //if (playerName == null && !pressed)
        // {
        playerName = SavePlayerName();
        print("player name is " + playerName);
        pressed = true;
        //}
        playerScore = 78;
        highscoreManager.SetScore(playerName, "Score",playerScore);
        print("playerscore save highscore is " + playerScore);

        /*PlayerPrefs.SetString("name" + (i + 1), highscoreManager.playerScores.Keys.ToArray()[i]);
        PlayerPrefs.SetInt("Score" + (i + 1), highscoreManager.GetScore(highscoreManager.playerScores.Keys.ToArray()[i], "Score"));
        PlayerPrefs.Save();*/


        /*for (int i = 0; i < highscoreManager.playerScores.Keys.ToArray().Length; i++)
        {
            PlayerPrefs.SetString("name" + i, highscoreManager.playerScores.Keys.ToArray()[i]);
            PlayerPrefs.SetInt("Score" + i, highscoreManager.GetScore(highscoreManager.playerScores.Keys.ToArray()[i], "Score"));
        }*/

    }



    public void PurgeDatabase()
    {

        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        print("Database purged!");
    }


    public void Exit()
    {
        PlayerPrefs.Save();
        Debug.Break();
    }

    public void MainMenu()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {

    }



}
