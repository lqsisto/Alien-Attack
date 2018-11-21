using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Luminosity.IO;

public class GameOver_Menu_Controller : MonoBehaviour {

    public Canvas GameOver_Menu;

	// Use this for initialization
	void Start () {
		
        if(GameOver_Menu.gameObject.activeInHierarchy == true)
        {
            GameOver_Menu.gameObject.SetActive(false);
        }
	}

    private void Update()
    {
        if(InputManager.GetKeyDown(KeyCode.A))
        {
            ShowGameOverMenu();
        }
    }

    public void ShowGameOverMenu()
    {
        GameOver_Menu.gameObject.SetActive(true);
    }

    public void HideGameOverMenu()
    {
        GameOver_Menu.gameObject.SetActive(false);
    }

}
