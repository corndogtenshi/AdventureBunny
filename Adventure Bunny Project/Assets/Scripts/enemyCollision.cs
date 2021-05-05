using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollision : MonoBehaviour
{
    public GameObject player;
    public Vector2 SpawnPos;
    public AudioSource playerDeath;
    public ScoreManager score;

    private void Start()
    {
        SpawnPos = new Vector2(-3.5f, 2.12f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDeath.Play();
            score.DecreaseScore(100);
            collision.transform.position = SpawnPos;
            //Destroy(collision.gameObject);
        }
    }
}
