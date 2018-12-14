using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
namespace Enemy
{

    public class EnemyController : MonoBehaviour
    {

        public GameObject enemy;
        public Rigidbody2D enemyRB;
        GameObject explosion;
        public GameObject explosionPrefab;
        GameObject enemyBullet;
        GameObject killzone;
        public GameObject explosionSound;
        public float enemyMovingSpeed = 10;
        public Slider enemyHealthSlider;

        public float enemyStartHealth;
        public float enemyCurrentHealth;

        public int enemyBulletSpeed;

        PlayerController playerController;
        EnemySpawnController enemySpawnController;

        // Use this for initialization
        void Awake ()
        {

            enemyCurrentHealth = enemyStartHealth;
            playerController = GameObject.Find ("Player").GetComponent<PlayerController> ();
            GameObject player = playerController.player;

            explosionSound = GameObject.Find ("ExplosionSound");

            enemy = gameObject;
            enemyRB = GetComponent<Rigidbody2D> ();

            InvokeRepeating ("EnemyShoot", 0, 4);

            enemyHealthSlider = transform.Find ("EnemyHealthCanvas").transform.Find ("EnemyHealthSlider").GetComponent<Slider>();

            killzone = GameObject.Find ("Killzone");

        }

        // Update is called once per frame
        void Update ()
        {

            if (gameObject.tag == "Enemy")
            {
                transform.Translate (Vector2.down * enemyMovingSpeed * Time.deltaTime);
            }
            if (enemyCurrentHealth <= 0)
            {
                Destroy (gameObject);
                explosion = Instantiate (explosionPrefab, transform.position, Quaternion.identity);
                explosionSound.GetComponent<AudioSource> ().Play ();

                for (int i = 0; i < 10; i++)
                {
                    GameObject coin = Instantiate (Resources.Load ("Coin"), gameObject.transform.position, Quaternion.identity) as GameObject;
                }

                TextController.points++;

                EnemySpawnController.killedEnemies++;

                TextController.enemiesLeft--;
            }

            enemyHealthSlider.transform.position = (new Vector2 (transform.position.x, transform.position.y + 1.8f));

            if (transform.position.y <= killzone.transform.position.y)
            {
                Destroy (gameObject);
            }

        }

        void OnCollisionEnter2D (Collision2D col)
        {
            if (col.gameObject.CompareTag ("Bullet"))
            {
                enemyCurrentHealth--;
                takeDamage ();
                Destroy (col.gameObject);
            }
        }

        void EnemyShoot ()
        {
            enemyBullet = Instantiate (Resources.Load ("EnemyBullet"), new Vector3 (transform.position.x, transform.position.y - 0.75f, //instantiate bullet gameobject on player
                transform.position.z), Quaternion.identity) as GameObject;

            if (!enemyBullet.GetComponent<Rigidbody2D> ())
            {
                enemyBullet.AddComponent<Rigidbody2D> ();
            }

            Rigidbody2D enemyBulletRB = enemyBullet.GetComponent<Rigidbody2D> ();
            enemyBulletRB.AddForce (Vector2.down * enemyBulletSpeed, ForceMode2D.Force);

            //Destroy(enemyBullet, 1.5f);          //Destroy bullet after 1.5 seconds
        }

        private void OnBecameInvisible ()
        {
            Destroy (enemyBullet);
        }

        private void takeDamage ()
        {
            enemyHealthSlider.GetComponent<Slider> ().value = (float) enemyCurrentHealth / (float) enemyStartHealth;
        }

    }

}