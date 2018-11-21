using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HighscoreManager : MonoBehaviour
{

    public Dictionary<string, Dictionary<string, int>> playerScores;


    int changeCounter = 0;
    // Use this for initialization
    void Start()
    {
    }

    void Init()
    {
        if (playerScores != null)
        {
            return;
        }
        playerScores = new Dictionary<string, Dictionary<string, int>>();
    }

    public int GetScore(string username, string scoreType)
    {
        Init();

        //If dictionary doesnt contain username, AKA player is new
        if (playerScores.ContainsKey(username) == false)
        {
            return 0;
        }

        if (playerScores[username].ContainsKey(scoreType) == false)
        {
            return 0;
        }

        return playerScores[username][scoreType];
    }

    public void GetScoresFromDB()
    {

        for (int i = 0; i < PlayerPrefsX.GetStringArray("playerNamesArr").Length; i++)
        {
            SetScore(PlayerPrefsX.GetStringArray("names")[i], "Score", PlayerPrefsX.GetIntArray("Scores")[i]);
            print("playerprefs name index is " + i);
        }


        /* //..............testing for single name....................//
         PlayerPrefs.GetString("name");
         PlayerPrefs.GetInt("Score");     */           //näillä toimii!

    }

    public void SetScore(string username, string scoreType, int value)
    {
        Init();

        changeCounter++;

        if (playerScores.ContainsKey(username) == false)
        { 
            playerScores[username] = new Dictionary<string, int>();
        }
        playerScores[username][scoreType] = value;
    }

    public string ChangeScore(string username, string scoreType, int amount)
    {
        Init();

        if (playerScores.ContainsKey(username))
        {
            int currScore = GetScore(username, scoreType);
            SetScore(username, scoreType, currScore + amount);



            return username;
        }

        return null;


        /*int currScore = GetScore(username, scoreType);
        SetScore(username, scoreType, currScore + amount);*/



    }

    public string[] GetPlayerNames(string sortingScoreType)
    {
        Init();

        string[] names = playerScores.Keys.ToArray();


        return names.OrderByDescending(n => GetScore(n, sortingScoreType)).ToArray();
    }

    public int GetChangeCounter()
    {
        return changeCounter;
    }

    public void ShowDatabase()
    {
        for (int i = 0; i < PlayerPrefsX.GetStringArray("playerNamesArr").Length; i++)
        {
            Debug.Log("names from playerprefsX, index is " + i + " " + PlayerPrefsX.GetStringArray("playerNamesArr")[i]);
            Debug.Log("scores from playerprefsX, index is " + i + " " + PlayerPrefsX.GetIntArray("playerScoresArr")[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
