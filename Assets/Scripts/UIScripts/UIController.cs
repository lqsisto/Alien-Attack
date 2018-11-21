using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController
{

	//Main Canvas
	static GameObject IngameCanvas;

	//Panels
	static GameObject IngameUIPanel;

	//ingameUIPanel children

	public static GameObject ScoreText;
	public static GameObject CoinText;

	static GameObject PausemenuPanel;
	static GameObject GameoverPanel;
	static GameObject LevelCompletedPanel;
	static GameObject SaveScorePanel;
	static GameObject CountdownPanel;

	//Countdownpanel children
	public static GameObject TimerText;

	public static void FindMainmenuComponents ()
	{

	}

	public static void FindLevelComponents ()
	{
		//Find all uicomponents
		//Remember to add dontdestroyonload component to menuelements so level 2 wont bring any problems!

		//Main Canvas
		IngameCanvas = GameObject.FindGameObjectWithTag ("IngameCanvas");

		//Panels
		IngameUIPanel = IngameCanvas.transform.Find ("IngameUIPanel").gameObject;

		//ingameUIPanel children
		ScoreText = IngameUIPanel.transform.Find ("ScoreAndCoins").transform.Find ("ScoreText").gameObject;
		CoinText = IngameUIPanel.transform.Find ("ScoreAndCoins").transform.Find("CoinText").gameObject;

		PausemenuPanel = IngameCanvas.transform.Find ("PausemenuPanel").gameObject;
		GameoverPanel = IngameCanvas.transform.Find ("GameOverPanel").gameObject;
		LevelCompletedPanel = IngameCanvas.transform.Find ("LevelCompletedPanel").gameObject;
		SaveScorePanel = IngameCanvas.transform.Find ("SaveScorePanel").gameObject;
		CountdownPanel = IngameCanvas.transform.Find ("CountdownPanel").gameObject;

		//Countdownpanel children
		TimerText = CountdownPanel.transform.Find ("TimerText").gameObject;

		Debug.Log ("Ui elements found");
	}
}