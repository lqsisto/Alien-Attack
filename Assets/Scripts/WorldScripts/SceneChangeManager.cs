using System.Collections;
using System.Collections.Generic;
using Luminosity.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChangeManager : MonoBehaviour
{
	public static SceneChangeManager instance = null;
	public GameObject inputManager;
	public GameObject eventSystem;
	PausemenuController pausemenuController;

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

				if (!GameObject.FindObjectOfType<InputManager> ())
				{
					GameObject i = Instantiate (inputManager, Vector3.zero, Quaternion.identity);
				}
				if (!GameObject.FindObjectOfType<Luminosity.IO.StandaloneInputModule> ())
				{
					GameObject e = Instantiate (eventSystem, Vector3.zero, Quaternion.identity);
				}
				break;

			case 1:
				Timer.StartTimer(3);
				break;
		}
	}
}