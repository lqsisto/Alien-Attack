using System.Collections;
using System.Collections.Generic;
using Enemy;
using Luminosity.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	[SerializeField] GameObject eventSystem;
	[SerializeField] GameObject inputManager;
	[SerializeField] GameObject mainmenuSoundManager;
	[SerializeField] MainmenuController mainmenuController;
	PausemenuController pausemenuController;
	EnemySpawnController enemySpawnCtrl;
	protected UIController uiController;
	private bool keyPressed = false;

	private void Awake ()
	{
		switch (SceneManager.GetActiveScene ().buildIndex)
		{
			case 0:
				if (instance == null)
				{
					instance = this;
				}
				else if (instance != this)
				{
					Destroy (gameObject);
				}

				InstantiateMainmenuItems ();

				mainmenuController = GameObject.FindObjectOfType<MainmenuController> ();
				mainmenuController.InitializeMainMenuController ();
				break;
			case 1:
				uiController = GameObject.FindObjectOfType<UIController> ();
				uiController.FindLevelComponents ();

				enemySpawnCtrl = GameObject.FindObjectOfType<EnemySpawnController> ();
				enemySpawnCtrl.InitializeEnemySpawn ();
				break;
		}
	}

	protected virtual void Update ()
	{
		// if (uiController.gamePaused)
		// {
		// 	Time.timeScale = 0;
		// }
		// else
		// {
		// 	Time.timeScale = 1;
		// }

		if (InputManager.GetKeyDown (KeyCode.P) && !keyPressed)
		{
			Time.timeScale = 0;
			uiController.PauseGame ();
		}
	}

	private void InstantiateMainmenuItems ()
	{
		if (!GameObject.FindObjectOfType<InputManager> ())
		{
			GameObject i = Instantiate (inputManager, Vector3.zero, Quaternion.identity);
		}
		if (!GameObject.FindObjectOfType<Luminosity.IO.StandaloneInputModule> ())
		{
			GameObject e = Instantiate (eventSystem, Vector3.zero, Quaternion.identity);
		}
		if (!GameObject.FindObjectOfType<AudioSource> ())
		{
			Instantiate (mainmenuSoundManager, Vector3.zero, Quaternion.identity);
		}
		if (!GameObject.FindObjectOfType<MainmenuController> ())
		{
			Instantiate (mainmenuController, Vector3.zero, Quaternion.identity);
		}
	}

	// void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	// {
	// 	switch (scene.buildIndex)
	// 	{
	// 		case 0:

	// 			InstantiateMainmenuItems ();

	// 			mainmenuController = GameObject.FindObjectOfType<MainmenuController> ();
	// 			mainmenuController.InitializeMainMenuController ();

	// 			break;

	// case 1:
	// 	uiController = GameObject.FindObjectOfType<UIController> ();
	// 	uiController.FindLevelComponents ();
	// 	if (!gameObject.GetComponent<Timer> ())
	// 	{
	// 		gameObject.AddComponent<Timer> ();
	// 	}
	// 	StartCoroutine (GetComponent<Timer> ().Countdown (3));

	// 	enemySpawnCtrl = GameObject.FindObjectOfType<EnemySpawnController> ();
	// 	enemySpawnCtrl.InitializeEnemySpawn ();
	// 	break;
	// 	}
	// }
}