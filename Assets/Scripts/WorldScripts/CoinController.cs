using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public GameObject player;
    public float moveTowardsSpeed;
    Vector2 startPos;
    public float randomMaxX;
    public float randomMinY;
    public float randomMaxY;
    bool nearplayer = false;



    // Use this for initialization
    void Start()
    {
        if (!gameObject.GetComponent<Rigidbody2D>())
        {
            gameObject.AddComponent<Rigidbody2D>();
        }
        gameObject.AddComponent<PolygonCollider2D>();
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0f, randomMaxX), Random.Range(randomMinY, randomMaxY)), ForceMode2D.Impulse);

        startPos = gameObject.transform.position;
        player = GameObject.Find("Player");



    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= 5f)
        {
            nearplayer = true;
             Destroy(GetComponent<Rigidbody2D>());
        }
        if (nearplayer)
        {
            transform.Translate((player.transform.position - transform.position) * Time.deltaTime * moveTowardsSpeed);
        }


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            TextController.coins += 10;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}