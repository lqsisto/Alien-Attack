using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeating_background : MonoBehaviour
{


    public float scrollSpeed;   //the speed that the sprote moves
    public float speedModifier;
    public float tileSize;      //Either the X- or Y-Coordinate of the sprite; depends the direciton it's moving
    public float fixTheSize = 1;    //if for some reason you need to modify the length of the sprite you can do it here

    private Vector3 startPosition;  //This is the sprite's start position

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {

        float newPosition = Mathf.Repeat(Time.time * scrollSpeed * speedModifier, tileSize * fixTheSize);           //This line repeats the sprite

        transform.position = startPosition + Vector3.down * newPosition;                            //Moves the sprite into certain direction. Modify the Vector3 value to move it to different direction
    }
}