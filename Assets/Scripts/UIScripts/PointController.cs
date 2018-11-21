using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointController : MonoBehaviour
{

    public static int points = 0;           //The points the player gets for killing enemies
    string stringPoints;                    //Same thing but in String
    public Text uiPoints;                   //Canvas' text field

    // Use this for initialization
    public void Start()
    {
        uiPoints.text = "Score: " + points.ToString();      //Convert int points into String



    }

    // Update is called once per frame
    void Update()
    {

        uiPoints.text = "Score \n" + points.ToString();     //Display the points on Canvas

    }

}
