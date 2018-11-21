using System.Collections;
using System.Collections.Generic;
using Luminosity.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
	public static GameManager instance = null;
	public GameObject eventSystem;
	public GameObject inputManager;
	public GameObject mainmenuSoundManager;
	PausemenuController pausemenuController;
	MainmenuController mainmenuController;

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

	void OnSceneLoaded (Scene scene, LoadSceneMode mode)
	{
		switch (scene.buildIndex)
		{
			case 0:
				
				mainmenuController = GetComponent<MainmenuController>();
				mainmenuController.InitializeMainMenuController();

				if (!GameObject.FindObjectOfType<InputManager> ())
				{
					GameObject i = Instantiate (inputManager, Vector3.zero, Quaternion.identity);
				}
				if (!GameObject.FindObjectOfType<Luminosity.IO.StandaloneInputModule> ())
				{
					GameObject e = Instantiate (eventSystem, Vector3.zero, Quaternion.identity);
				}
				if(!GameObject.FindObjectOfType<AudioSource>())
				{
					Instantiate(mainmenuSoundManager, Vector3.zero, Quaternion.identity);
				}
				break;

			case 1:
				UIController.FindLevelComponents();
				Timer.StartTimer (3);
				break;
		}
	}
}