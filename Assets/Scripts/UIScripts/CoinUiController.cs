using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUiController : MonoBehaviour {

    //------------------Below are variables for showing coins on canvas------------------------------------------//

    public static int coins = 0;           //The points the player gets for killing enemies
    string stringCoins;                    //Same thing but in String
    public Text uiCoins;                   //Canvas' text field



	// Use this for initialization
	void Start () {
		 //------------------Below is code for showing coins on canvas------------------------------------------//

        
         uiCoins.text = "Score: " + coins.ToString();      //Convert int points into String

	}
	
	// Update is called once per frame
	void Update () {
		 //------------------Below is code for showing coins on canvas------------------------------------------//

        
	}
}
