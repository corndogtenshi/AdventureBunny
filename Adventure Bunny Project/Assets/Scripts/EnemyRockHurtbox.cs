using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRockHurtbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            transform.parent.gameObject.SetActive(false);
            //Destroy(transform.parent.gameObject);
        }
    }
}
