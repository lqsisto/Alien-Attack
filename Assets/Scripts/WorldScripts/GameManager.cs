using System.Collections;
using System.Collections.Generic;
using Luminosity.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	public GameObject eventSystem;
	public GameObject inputManager;
	public GameObject mainmenuSoundManager;
	PausemenuController pausemenuController;
	public MainmenuController mainmenuController;
	protected static Text countdownText;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}
		SceneManager.sceneLoaded += OnSceneLoaded;

	}

	private void Update()
	{
		if(PausemenuController.gamePaused)
		{
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	void InstantiateMainmenuItems ()
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

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		switch (scene.buildIndex)
		{
			case 0:

				InstantiateMainmenuItems ();

				mainmenuController = GameObject.FindObjectOfType<MainmenuController> ();
				mainmenuController.InitializeMainMenuController ();

				break;

			case 1:
				UIController.FindLevelComponents ();
				if(!gameObject.GetComponent<Timer>())
				{
				gameObject.AddComponent<Timer>();
				}
				StartCoroutine (GetComponent<Timer>().Countdown (3));
				break;
		}
	}
}