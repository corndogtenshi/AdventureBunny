using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocksOnCollision : MonoBehaviour
{
    public TileManager tileManager; //Used to inform tiles when they should be destroyed
    AudioSource digSound;

    private void Start()
    {
        digSound = this.gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 hitPosition = Vector3.zero;
        if (collision.gameObject.tag == "Breakable")
        {
            digSound.Play();
            foreach (ContactPoint2D hit in collision.contacts)
            {
                hitPosition = new Vector2(hit.point.x - 0.01f * hit.normal.x, hit.point.y - 0.01f * hit.normal.y);
                tileManager.DestroySingleTile(hitPosition);
            }
        }
    }
}
