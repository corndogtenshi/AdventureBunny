using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2AI : MonoBehaviour
{
    int direction = 1;
    public float speed = 0.0007f;
    private Rigidbody2D rb;
    bool recentlyTurned = false;

    public GameObject player;
    private Vector2 ppos;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!recentlyTurned)
        {
            direction *= -1;
            recentlyTurned = true;
            //turnWait();
            recentlyTurned = false;
        }
    }
    private void Patrol()
    {
        rb.velocity = new Vector2(direction * speed, 0); 
        //rb.AddForce(new Vector2(0, direction * speed * Time.deltaTime));
        //rb.AddForce(new Vector2(0, direction * speed * Time.deltaTime));
        //rb.MovePosition(rb.position + new Vector2(0, direction * speed * Time.deltaTime));
    }
    IEnumerator turnWait()
    {
        yield return new WaitForSeconds(0.05f);
    }
}
