using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour {
    public static int points = 0;           //The points the player gets for killing enemies
    string stringPoints;                    //Same thing but in String
    public Text uiPoints;                   //Canvas' text field

	public static int coins = 0;           //The coins the player gets for killing enemies
    string stringCoins;                    //Same thing but in String
    public Text uiCoins;                   //Canvas' text field

	public static int waves = 1;		   //Same thing in waves
	string stringWaves;
	public Text uiWaves;

	public static int enemiesLeft;
	string stringenemiesLeft;
	public Text uiEnemiesLeft;

	// Use this for initialization
	void Start () {
		        uiPoints.text = "Score: " + points.ToString();      //Convert int points into String
				uiCoins.text = "Coins: " + coins.ToString();        //Convert int coins into String
				uiWaves.text = "Wave " + waves.ToString();			//Convert int waves into string
				uiEnemiesLeft.text = "Enemies left \n" + enemiesLeft.ToString(); //Same thing
	}
	
	// Update is called once per frame
	void Update () {
		        uiPoints.text = "Score \n" + points.ToString();     //Display the points on Canvas
				uiCoins.text = "Coins \n" + coins.ToString();     //Display the coins on Canvas
				uiWaves.text = "Wave " + waves.ToString();
				uiEnemiesLeft.text = "Enemies left \n" + enemiesLeft.ToString(); //Same thing
	}
}
