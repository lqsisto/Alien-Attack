using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController
{

	//Main Canvas
	static GameObject IngameCanvas;

	//Panels
	static GameObject IngameUIPanel;
	public GameObject pausemenuCanvas;

	//ingameUIPanel children
	public static GameObject ScoreText;
	public static GameObject CoinText;

	static GameObject PausemenuPanel;
	static GameObject GameoverPanel;
	static GameObject LevelCompletedPanel;
	static GameObject SaveScorePanel;
	static GameObject countdownPanel;

	//Countdownpanel children
	public static GameObject TimerText;

	public bool start_Countdown;
	public static bool gamePaused;
	float currCountdownValue;
	public GameObject paused;
	public GameObject buttonFrame;
	public Text timerText;
	float timer;

	public static void FindLevelComponents ()
	{
		//Find all uicomponents
		//Remember to add dontdestroyonload component to menuelements so level 2 wont bring any problems!

		//Main Canvas
		IngameCanvas = GameObject.FindGameObjectWithTag ("IngameCanvas");

		//Panels
		IngameUIPanel = IngameCanvas.transform.Find ("IngameUIPanel").gameObject;
		PausemenuPanel = IngameCanvas.transform.Find ("PausemenuPanel").gameObject;
		GameoverPanel = IngameCanvas.transform.Find ("GameOverPanel").gameObject;
		LevelCompletedPanel = IngameCanvas.transform.Find ("LevelCompletedPanel").gameObject;
		SaveScorePanel = IngameCanvas.transform.Find ("SaveScorePanel").gameObject;
		countdownPanel = IngameCanvas.transform.Find ("CountdownPanel").gameObject;

		//ingameUIPanel children
		ScoreText = IngameUIPanel.transform.Find ("ScoreAndCoins").transform.Find ("ScoreText").gameObject;
		CoinText = IngameUIPanel.transform.Find ("ScoreAndCoins").transform.Find ("CoinText").gameObject;

		//Countdownpanel children
		TimerText = countdownPanel.transform.Find ("TimerText").gameObject;

		InitializePausemenu();

		Debug.Log ("Ui elements found, activating Timer panel!");
	}

	private static void InitializePausemenu ()
	{
		// if (timerText.gameObject.activeInHierarchy)
		// {
		// 	timerText.gameObject.SetActive (false);
		// }
		if (PausemenuPanel.activeInHierarchy)
		{
			PausemenuPanel.SetActive (false);
		}
	}

	public void ResumeGame ()
	{
		paused.SetActive (false);
		buttonFrame.SetActive (false);
		timerText.gameObject.SetActive (true);
		start_Countdown = true;
		// timerText.text = continueGameWait.ToString ();
		// StartCountdown ();
	}

	public void QuitGame ()
	{
		Application.Quit ();
		Debug.Break ();
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