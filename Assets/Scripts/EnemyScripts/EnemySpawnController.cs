using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemySpawnController : MonoBehaviour
    {

        // public int numberOfEnemies;   //tells how many enemies will be spawned

        public int wavesBeforeBoss = 10;
        public int waveLimit; //how many enemies player have to destroy to advance to the next level
        public static float killedEnemies = 0; //number of destroyed enemies

        public GameObject enemy;
        GameObject instantiatedEnemy;

        public GameObject boss1;

        public GameObject leftSpawnBorder; //spawn borders for enemies
        public GameObject rightSpawnBorder;
        public GameObject enemySpawnPos; //defines y position for spawning
        public GameObject bossSpawnPos;

        public int enemyRandomizer;

        public GameObject enemy1;
        public GameObject enemy2;
        public GameObject enemy3;

        bool spawn;

        public bool instantiateBoss = true;

        // Use this for initialization
        public void InitializeEnemySpawn ()
        {
            spawn = true;
            enemySpawnPos = GameObject.Find ("EnemySpawnPos");
            bossSpawnPos = GameObject.Find ("BossSpawnPos");

            leftSpawnBorder = GameObject.Find ("EnemySpawnPosLeft");
            rightSpawnBorder = GameObject.Find ("EnemySpawnPosRight");

            StartCoroutine (spawnEnemies ());

            waveLimit = 10;

        }

        // Update is called once per frame
        public virtual void Update ()
        {
            enemyRandomizer = Random.Range (1, 11);
        }

        IEnumerator spawnEnemies ()
        {
            waveLimit = 5;
            TextController.enemiesLeft = waveLimit;
            killedEnemies = 0;

            if (TextController.waves == wavesBeforeBoss)
            {
                killedEnemies = waveLimit;
                Destroy (GameObject.FindGameObjectWithTag ("Enemy"));
            }

            while (spawn)
            {
                if (enemyRandomizer > 0 && enemyRandomizer < 4)
                {
                    enemy = enemy1;
                }
                else if (enemyRandomizer > 4 && enemyRandomizer < 8)
                {
                    enemy = enemy2;
                }
                else
                {
                    enemy = enemy3;
                }

                instantiatedEnemy = Instantiate (enemy, new Vector2 (
                        Random.Range (
                            leftSpawnBorder.transform.position.x,
                            rightSpawnBorder.transform.position.x),
                        enemySpawnPos.transform.position.y),
                    Quaternion.identity);

                yield return new WaitForSeconds (0.75f);
            }
            waveLimit = (int) (waveLimit * 1.2);
            TextController.waves++;

        }
    }
}