using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainmenuController : MonoBehaviour {

    GameObject singleplayerMenu;
    GameObject highScoreMenu;
    GameObject mainmenuShader;

    Animator menuAnimator;
	// Use this for initialization
	public void Start () {
        menuAnimator = GetComponent<Animator>();

        singleplayerMenu = GameObject.Find("SingleplayerMenu");
        highScoreMenu = GameObject.Find("HighscoreMenu");
        mainmenuShader = GameObject.Find("MainmenuShader");


        if (mainmenuShader.activeInHierarchy == true)
        {
            mainmenuShader.SetActive(false);
        }
	}
    public void ShowLevelSelectMenu()
    {
        menuAnimator.SetBool("ShowLevelselectMenu", true);
    }

    public void HideLevelselectMenu()
    {
        menuAnimator.SetBool("ShowLevelselectMenu", false);
    }

    public void ShowHighscoreMenu()
    {
        menuAnimator.SetBool("ShowHighscoreMenu", true);
    }
    public void HideHighscoreMenu()
    {
        menuAnimator.SetBool("ShowHighscoreMenu", false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartlevelOne()
    {
        SceneManager.LoadScene("Level 1");
    }

}
