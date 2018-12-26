using System.Collections;
using System.Collections.Generic;
using Luminosity.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

	//Main Canvas
	GameObject IngameCanvas;

	//Panels
	GameObject IngameUIPanel;
	public GameObject pausemenuCanvas;

	//ingameUIPanel children
	public GameObject ScoreText;
	public GameObject CoinText;

	GameObject pausemenuPanel;
	GameObject GameoverPanel;
	GameObject LevelCompletedPanel;
	GameObject SaveScorePanel;
	protected GameObject countdownPanel;

	//Countdownpanel children
	protected static Text countdownText;
	GameObject pauseBtnFrame;
	Button resumeBtn;
	Button mainmenuBtn;

	//Pausemenupanel children
	public bool start_Countdown;
	public bool gamePaused = false;
	float secondsToWait;
	GameObject pausedText;
	public GameObject buttonFrame;
	public Text timerText;
	float timerTime;
	int continueGameWait = 3;

	//Script References
	Timer timer;

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
		countdownText = countdownPanel.transform.Find ("TimerText").GetComponent<Text> ();

		InitializePausemenu ();

		Debug.Log ("Ui elements found, activating Timer panel!");

		timer = GetComponent<Timer> ();
		StartCoroutine (Countdown(3));
	}

	//--------------------------------------------------------Pausemenu-------------------------------------------------------//
	#region pausemenu
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

	public void PauseGame ()
	{
		pausemenuPanel.SetActive (true);
		gamePaused = true;
		timerText.gameObject.SetActive (false);
		pauseBtnFrame.SetActive (true);
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

	#endregion

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

	public void ToggleCountdownPanel ()
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

	public IEnumerator Countdown (int countdownSecs)
	{
		print ("inside timer");
		PausemenuController.gamePaused = true;
		while (countdownSecs > 0)
		{
			countdownText.text = countdownSecs.ToString ();
			yield return new WaitForSecondsRealtime (1);
			countdownSecs--;
		}
		PausemenuController.gamePaused = false;
		ToggleCountdownPanel ();
	}

}