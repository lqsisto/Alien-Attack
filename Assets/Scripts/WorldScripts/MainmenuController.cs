using System.Collections;
using System.Collections.Generic;
using MoreTags;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuController : MonoBehaviour
{

    GameObject singleplayerMenu;
    GameObject highScoreMenu;
    GameObject mainmenuShader;

    Button newgameButton;
    Button levelselectButton;
    Button highscoreButton;
    Button exitButton;

    Animator menuAnimator;
    // Use this for initialization
    public void InitializeMainMenuController ()
    {
        menuAnimator = GetComponent<Animator> ();

        

        newgameButton.onClick.AddListener (StartlevelOne);
        levelselectButton.onClick.AddListener (ShowLevelSelectMenu);
        highscoreButton.onClick.AddListener (ShowHighscoreMenu);

        singleplayerMenu = GameObject.Find ("SingleplayerMenu");
        highScoreMenu = GameObject.Find ("HighscoreMenu");
        mainmenuShader = GameObject.Find ("MainmenuShader");

        if (mainmenuShader.activeInHierarchy == true)
        {
            mainmenuShader.SetActive (false);
        }
    }
    public void ShowLevelSelectMenu ()
    {
        menuAnimator.SetBool ("ShowLevelselectMenu", true);
    }

    public void HideLevelselectMenu ()
    {
        menuAnimator.SetBool ("ShowLevelselectMenu", false);
    }

    public void ShowHighscoreMenu ()
    {
        menuAnimator.SetBool ("ShowHighscoreMenu", true);
    }
    public void HideHighscoreMenu ()
    {
        menuAnimator.SetBool ("ShowHighscoreMenu", false);
    }

    public void Exit ()
    {
        Application.Quit ();
    }

    public void StartlevelOne ()
    {
        SceneManager.LoadScene ("Level 1");
    }

}