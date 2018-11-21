using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletedMenuController : MonoBehaviour {

    public Canvas LevelCompletedMenuCanvas;
    public Canvas SaveScoreCanvas;
    PlayerScoreManager playerScoreManager;

    public int nextLevelIndex;

	// Use this for initialization
	void Start () {

        playerScoreManager = GameObject.Find("HighscoreManager").GetComponent <PlayerScoreManager>();


        if (SaveScoreCanvas.gameObject.activeInHierarchy == true)
        {
            SaveScoreCanvas.gameObject.SetActive(false);
        }

        if (LevelCompletedMenuCanvas.gameObject.activeInHierarchy == true)
        {
            LevelCompletedMenuCanvas .gameObject.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EnableNextLevelMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (SaveScoreCanvas.gameObject.activeInHierarchy == false)
            {
                playerScoreManager.SaveScore();
                SaveScoreCanvas.gameObject.SetActive(true);
            }

            print("last level completed");
        }
        else
        {

            if (LevelCompletedMenuCanvas.gameObject.activeInHierarchy == false)
            {
                LevelCompletedMenuCanvas.gameObject.SetActive(true);
                playerScoreManager.SaveScore();


            }
            else
            {
                print("Menu already open!");
            }
        }
    }


    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }



}
