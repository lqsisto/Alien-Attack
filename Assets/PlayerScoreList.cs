using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour
{

    public GameObject playerScoreEntryPrefab;
    HighscoreManager highscoreManager;
    int lastChangeCounter;


    // Use this for initialization
    void Start()
    {


        highscoreManager = FindObjectOfType<HighscoreManager>();

        lastChangeCounter = highscoreManager.GetChangeCounter();


    }

    // Update is called once per frame
    public void Update()
    {
        if (highscoreManager == null)
        {

            Debug.LogError("no manager component in game object!");
            return;
        }

        if (highscoreManager.GetChangeCounter() == lastChangeCounter)
        {
            return;
        }

        lastChangeCounter = highscoreManager.GetChangeCounter();

        while (this.transform.childCount > 0)
        {
            Transform c = this.transform.GetChild(0);
            c.SetParent(null);
            Destroy(c.gameObject);
        }

        string[] names = highscoreManager.GetPlayerNames("Score");
        print(names.Length);

        //PlayerPrefsX.SetStringArray("Highscores", names);


        for (int i = 0; i < names.Length; i++)
        {
            PlayerPrefs.SetString("name" + (i + 1), names[i]);
            PlayerPrefs.SetInt("Score" + (i + 1), highscoreManager.GetScore(names[i], "Score"));
            PlayerPrefs.SetInt("Deaths" + (i + 1), highscoreManager.GetScore(names[i], "Deaths"));
        }

            for(int i = 0; i < 5; i++)
        { 

            GameObject go = Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(transform);
            /*go.transform.Find("HS_NameText").GetComponent<Text>().text = names[i];
            go.transform.Find("HS_ScoreText").GetComponent<Text>().text = highscoreManager.GetScore(names[i], "Score").ToString();
            go.transform.Find("HS_DeathsText").GetComponent<Text>().text = highscoreManager.GetScore(names[i], "Deaths").ToString();*/

            go.transform.Find("HS_NameText").GetComponent<Text>().text = PlayerPrefsX.GetStringArray("playerNamesArr", "Name", 5)[i];
            go.transform.Find("HS_ScoreText").GetComponent<Text>().text = PlayerPrefsX.GetIntArray("playerScoresArr", 0, 5)[i].ToString();
            go.transform.Find("HS_DeathsText").GetComponent<Text>().text = PlayerPrefs.GetInt("Deaths" + (i + 1)).ToString();

        }





        /*    foreach (string name in names)
        {
            GameObject go = Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(transform);
            go.transform.Find("HS_NameText").GetComponent<Text>().text = name;
            go.transform.Find("HS_ScoreText").GetComponent<Text>().text = highscoreManager.GetScore(name, "Score").ToString();
            go.transform.Find("HS_DeathsText").GetComponent<Text>().text = highscoreManager.GetScore(name, "Deaths").ToString();




        }*/

    }


    public void RefreshScoreboard()
    {
        string[] names = highscoreManager.GetPlayerNames("Score");
        print(names.Length);

        //PlayerPrefsX.SetStringArray("Highscores", names);


        for (int i = 0; i < names.Length; i++)
        {
            PlayerPrefs.SetString("name" + (i + 1), names[i]);
            PlayerPrefs.SetInt("Score" + (i + 1), highscoreManager.GetScore(names[i], "Score"));
            PlayerPrefs.SetInt("Deaths" + (i + 1), highscoreManager.GetScore(names[i], "Deaths"));
        }

        for (int i = 0; i < PlayerPrefsX.GetStringArray("playerNamesArr").Length; i++)
        {

            GameObject go = Instantiate(playerScoreEntryPrefab);
            go.transform.SetParent(transform);
            /*go.transform.Find("HS_NameText").GetComponent<Text>().text = names[i];
            go.transform.Find("HS_ScoreText").GetComponent<Text>().text = highscoreManager.GetScore(names[i], "Score").ToString();
            go.transform.Find("HS_DeathsText").GetComponent<Text>().text = highscoreManager.GetScore(names[i], "Deaths").ToString();*/

            go.transform.Find("HS_NameText").GetComponent<Text>().text = PlayerPrefsX.GetStringArray("playerNamesArr", "Name", 5)[i];
            go.transform.Find("HS_ScoreText").GetComponent<Text>().text = PlayerPrefsX.GetIntArray("playerScoresArr", 0, 5)[i].ToString();
            go.transform.Find("HS_DeathsText").GetComponent<Text>().text = PlayerPrefs.GetInt("Deaths" + (i + 1)).ToString();

        }
    }

}
