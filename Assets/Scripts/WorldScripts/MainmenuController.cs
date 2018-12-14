using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainmenuController : MonoBehaviour
{
    GameObject mainmenuCanvas;
    GameObject singleplayerMenu;
    GameObject levelselectPanel;
    GameObject highScoreMenu;
    GameObject mainmenuShader;

    //Mainmenu Buttons
    Button newgameButton;
    Button levelselectButton;
    Button highscoreButton;
    Button exitButton;

    //Levelselectpanel Buttons
    Button HideLevelselectPanelButton;

    //Highscoremenu Buttons
    Button HidehighscorepanelButton;

    Animator menuAnimator;

    // Use this for initialization
    public void InitializeMainMenuController ()
    {
        mainmenuCanvas = GameObject.Find("MainmenuCanvas");

        menuAnimator = mainmenuCanvas.GetComponent<Animator> ();

        singleplayerMenu = GameObject.Find ("SingleplayerMenu");
        levelselectPanel = GameObject.Find ("LevelselectPanel");
        highScoreMenu = GameObject.Find ("HighscorePanel");
        mainmenuShader = GameObject.Find ("MainmenuShader");

        //Find Mainmenu Buttons and add functions to them.
        GameObject mm_BtnFrame = GameObject.Find ("MainmenuCanvas").transform.Find ("MainmenuPanel").transform.Find ("BtnFrame").gameObject;

        newgameButton = mm_BtnFrame.transform.Find ("NewGameButton").GetComponent<Button> ();
        levelselectButton = mm_BtnFrame.transform.Find ("LevelSelectButton").GetComponent<Button> ();
        highscoreButton = mm_BtnFrame.transform.Find ("HighscoreButton").GetComponent<Button> ();
        exitButton = mm_BtnFrame.transform.Find ("ExitButton").GetComponent<Button> ();

        newgameButton.onClick.AddListener (StartlevelOne);
        levelselectButton.onClick.AddListener (ShowLevelSelectMenu);
        highscoreButton.onClick.AddListener (ShowHighscoreMenu);
        exitButton.onClick.AddListener (Exit);

        //Find Levelselectpanel buttons and add functions to them
        HideLevelselectPanelButton = levelselectPanel.transform.Find ("BtnFrame").transform.Find ("ReturnButton").GetComponent<Button> ();
        HideLevelselectPanelButton.onClick.AddListener (HideLevelselectMenu);

        //Find Highscorepanel Buttons and add functions to them
        HidehighscorepanelButton = highScoreMenu.transform.Find ("ReturnButton").GetComponent<Button> ();
        HidehighscorepanelButton.onClick.AddListener (HideHighscoreMenu);

        print ("onclick initialized!");

        if (mainmenuShader.activeInHierarchy == true)
        {
            mainmenuShader.SetActive (false);
        }
    }



    #region Animations
    public void ShowLevelSelectMenu ()
    {
        menuAnimator.SetBool ("ShowLevelselectPanel", true);
    }

    public void HideLevelselectMenu ()
    {
        menuAnimator.SetBool ("ShowLevelselectPanel", false);
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
        Debug.Break ();
    }

    public void StartlevelOne ()
    {
        SceneManager.LoadScene ("Level 1");
    }
    #endregion

}