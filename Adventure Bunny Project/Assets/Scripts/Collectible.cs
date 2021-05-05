using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public CollectibleManager collectibleManager;
    public ScoreManager score;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision");

        if (collision.gameObject.CompareTag("Player")){
            collectibleManager.IncreaseKeyCount();
            score.IncreaseScore(100);
            Destroy(this.gameObject);
            //Remove 1 from keys remaining
        }
    }
}
