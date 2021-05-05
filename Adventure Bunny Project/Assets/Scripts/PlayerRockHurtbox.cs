using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRockHurtbox : MonoBehaviour
{
    public GameObject player;
    public Vector2 SpawnPos;
    public AudioSource playerDeath;
    public ScoreManager score;

    private void Start()
    {
        SpawnPos = new Vector2(-3.5f, 2.12f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Rock"))
        {
            playerDeath.Play();
            score.DecreaseScore(100);
            player.transform.position = SpawnPos;
            //Destroy(collision.gameObject);
        }
    }
}
