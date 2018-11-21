using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;

namespace Player
{

    public class PlayerController : MonoBehaviour
    {

        public GameObject player; //player
        public Rigidbody2D playerRB; //player's rigidbody
        public float movingUpSpeed; //player's speed
        public Vector3 mousePos; //this is the postion player moves
        public Vector3 start; //starting position

        public GameObject bullet; //bullet GameObject
        public float bulletSpeed = 1000; //Bullet's speed
        public GameObject leftWall;
        public GameObject rightWall;
        public static int startHealth = 6;
        public static int currentHealth;

        PlayerHealthController playerHealthController;
        public PausemenuController pauseMenuController;

        int isColliding;

        GameObject gunShot;

        //bool destroyBullet = true;
        // Use this for initialization
        void Start ()
        {
            currentHealth = startHealth;

            //Start position is mouse position
            start = transform.position;
            mousePos = transform.position;

            player = GameObject.Find ("Player"); //player GameObject
            playerRB = gameObject.GetComponent<Rigidbody2D> (); //Player's Rigidbody

            rightWall = GameObject.Find ("BGShaderRight");
            leftWall = GameObject.Find ("BGShaderLeft");

            playerHealthController = GameObject.Find ("GameController").GetComponent<PlayerHealthController> ();

            //Cursor.visible = false;

            gunShot = GameObject.Find ("Gunshot");
        }

        // Update is called once per frame
        void Update ()
        {
            playerRB.freezeRotation = true; //prevents the player from rotating

            if (pauseMenuController.gamePaused == false)
            {
                mousePos = InputManager.mousePosition;
                mousePos.z = 10;
                mousePos = Camera.main.ScreenToWorldPoint (mousePos);

                if (mousePos.x <= leftWall.transform.position.x + 1f)
                {
                    mousePos = new Vector3 (leftWall.transform.position.x + 1.5f, mousePos.y, transform.position.z);
                }
                else if (mousePos.x >= rightWall.transform.position.x - 1f)
                {
                    mousePos = new Vector3 (rightWall.transform.position.x - 1.5f, mousePos.y, transform.position.z);
                }

                if (InputManager.GetKeyDown (KeyCode.Mouse0))
                {
                    InvokeRepeating ("Shoot", 0, 0.15f); //Instantiates bullets
                }
                else if (InputManager.GetKeyUp (KeyCode.Mouse0))
                {
                    CancelInvoke ("Shoot");
                }

                transform.position = mousePos;
                //Debug.Log("playerhealth is " + playerHealth);

                isColliding = 0;
            }

        }

        void Shoot ()
        {
            if (pauseMenuController.gamePaused == false)
            {
                GameObject bullet = Instantiate (Resources.Load ("Bullet"), new Vector3 (player.transform.position.x, player.transform.position.y + 0.75f, //instantiate bullet gameobject on player
                    player.transform.position.z), Quaternion.identity) as GameObject;

                gunShot.GetComponent<AudioSource> ().Play ();

                Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D> ();
                //Access Bullet's Rigidbody and give it force
                bulletRB.AddForce (Vector2.up * bulletSpeed, ForceMode2D.Force);

                Destroy (bullet, 1.5f); //Destroy bullet after 1.5 seconds
            }
        }

        void OnCollisionEnter2D (Collision2D col)
        {
            if (col.gameObject.CompareTag ("Enemy"))
            {
                if (isColliding == 1)
                {
                    return;
                }
                isColliding = 1;
                Destroy (col.gameObject);
                startHealth = startHealth - 1;
            }
            if (col.gameObject.CompareTag ("EnemyBullet"))
            {
                startHealth = startHealth - 1;

            }

        }
    }
}