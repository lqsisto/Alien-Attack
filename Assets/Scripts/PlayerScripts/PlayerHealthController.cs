using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{

    public class PlayerHealthController : MonoBehaviour
    {

        public GameObject healthImage;
        PlayerController playerController;
        int playerHealth;

        // Use this for initialization
        void Start ()
        {
            playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
            GameObject player = playerController.player;
            healthImage = GameObject.FindGameObjectWithTag ("HealthImage");
            healthImage.GetComponent<Image> ().fillAmount = 100;
        }

        // Update is called once per frame
        public void Update ()
        {
            loseHealth ();
        }

        public void loseHealth ()
        {
            switch (PlayerController.startHealth)
            {
                case 6:
                    healthImage.GetComponent<Image> ().fillAmount = 100;
                    break;
                case 5:
                    healthImage.GetComponent<Image> ().fillAmount = 0.83713f;
                    break;
                case 4:
                    healthImage.GetComponent<Image> ().fillAmount = 0.65f;
                    break;
                case 3:
                    healthImage.GetComponent<Image> ().fillAmount = 0.5f;
                    break;
                case 2:
                    healthImage.GetComponent<Image> ().fillAmount = 0.34f;
                    break;
                case 1:
                    healthImage.GetComponent<Image> ().fillAmount = 0.16f;
                    break;
            }
            if (PlayerController.startHealth <= 0)
            {
                healthImage.GetComponent<Image> ().fillAmount = 0;
            }
        }

    }
}