using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3SearchZone : MonoBehaviour
{
    public enemy3AI enemy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            enemy.SetSearching();
        }
    }
}
