using System.Collections;
using System.Collections.Generic;
using Luminosity.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : GameManager
{

	//Main Canvas
	static GameObject IngameCanvas;

	//Panels
	static GameObject IngameUIPanel;
	public GameObject pausemenuCanvas;

	//ingameUIPanel children
	public static GameObject ScoreText;
	public static GameObject CoinText;

	static GameObject pausemenuPanel;
	static GameObject GameoverPanel;
	static GameObject LevelCompletedPanel;
	static GameObject SaveScorePanel;
	static GameObject countdownPanel;

	//Countdownpanel children
	public static GameObject TimerText;
	static GameObject pauseBtnFrame;
	static Button resumeBtn;
	static Button mainmenuBtn;

	//Pausemenupanel children
	public static bool start_Countdown;
	public static bool gamePaused = false;
	float secondsToWait;
	GameObject pausedText;
	public GameObject buttonFrame;
	public static Text timerText;
	float timer;
	int continueGameWait = 3;

	public void FindLevelComponents ()
	{
		//Find all uicomponents
		//TODO Remember to add dontdestroyonload component to menuelements so level 2 wont bring any problems!

		//Main Canvas
		IngameCanvas = GameObject.FindGameObjectWithTag ("IngameCanvas");

		//Panels
		IngameUIPanel = IngameCanvas.transform.Find ("IngameUIPanel").gameObject;
		pausemenuPanel = IngameCanvas.transform.Find ("PausemenuPanel").gameObject;
		GameoverPanel = IngameCanvas.transform.Find ("GameOverPanel").gameObject;
		LevelCompletedPanel = IngameCanvas.transform.Find ("LevelCompletedPanel").gameObject;
		SaveScorePanel = IngameCanvas.transform.Find ("SaveScorePanel").gameObject;
		countdownPanel = IngameCanvas.transform.Find ("CountdownPanel").gameObject;

		//ingameUIPanel children
		ScoreText = IngameUIPanel.transform.Find ("ScoreAndCoins").transform.Find ("ScoreText").gameObject;
		CoinText = IngameUIPanel.transform.Find ("ScoreAndCoins").transform.Find ("CoinText").gameObject;

		//Pausemenupanel children
		pauseBtnFrame = pausemenuPanel.transform.Find ("ButtonFrame").gameObject;
		resumeBtn = pauseBtnFrame.transform.Find ("ResumeButton").GetComponent<Button> ();
		mainmenuBtn = pauseBtnFrame.transform.Find ("MainmenuButton").GetComponent<Button> ();
		//TODO possibly add quit game button
		timerText = pausemenuPanel.transform.Find ("TimerText").GetComponent<Text> ();
		pausedText = pausemenuPanel.transform.Find ("PausedText").gameObject;

		//Countdownpanel children
		TimerText = countdownPanel.transform.Find ("TimerText").gameObject;

		InitializePausemenu ();

		Debug.Log ("Ui elements found, activating Timer panel!");
	}

	//--------------------------------------------------------Pausemenu-------------------------------------------------------//
	protected void InitializePausemenu ()
	{
		resumeBtn.onClick.AddListener (ResumeGame);
		mainmenuBtn.onClick.AddListener (BackToMainmenu);

		if (timerText.gameObject.activeInHierarchy)
		{
			timerText.gameObject.SetActive (false);
		}
		if (pausemenuPanel.activeInHierarchy)
		{
			pausemenuPanel.SetActive (false);
		}
	}

	public static void PauseGame ()
	{
		pausemenuPanel.SetActive (true);
		gamePaused = true;
		if (timerText.gameObject.activeInHierarchy)
		{
			timerText.gameObject.SetActive (false);
		}
	}

	public void ResumeGame ()
	{
		pausedText.SetActive (false);
		pauseBtnFrame.SetActive (false);
		timerText.gameObject.SetActive (true);
		timerText.text = continueGameWait.ToString ();
		StartCoroutine (StartCountdownCoroutine (continueGameWait));
	}

	void BackToMainmenu ()
	{
		SceneManager.LoadScene (0, LoadSceneMode.Single);
	}

	public void QuitGame ()
	{
		Application.Quit ();
		Debug.Break ();
	}

	public IEnumerator StartCountdownCoroutine (int secondsToWait)
	{
		while (secondsToWait > 0)
		{
			Debug.Log ("Countdown: " + secondsToWait);
			yield return new WaitForSecondsRealtime (1);
			secondsToWait--;
			timerText.text = secondsToWait.ToString ();
		}

		Time.timeScale = 1;
		pausedText.SetActive (true);
		gamePaused = false;
		timerText.gameObject.SetActive (true);
		if (pausemenuPanel.activeInHierarchy)
		{
			pausemenuPanel.SetActive (false);
		}

	}

	public static void ToggleCountdownPanel ()
	{
		if (!countdownPanel.activeInHierarchy)
		{
			countdownPanel.SetActive (true);
		}
		else
		{
			countdownPanel.SetActive (false);
		}
	}

}