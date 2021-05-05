using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    private AudioSource brickSound;
    // Start is called before the first frame update
    void Start()
    {
        brickSound = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            brickSound.Play();
        }
    }
}
