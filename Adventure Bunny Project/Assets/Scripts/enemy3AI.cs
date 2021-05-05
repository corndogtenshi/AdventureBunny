using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy3AI : MonoBehaviour
{
    int direction = 1;
    public float speed = 1.85f;
    private Rigidbody2D rb;
    private bool searching = false;
    bool recentlyTurned = false;

    public GameObject player;
    private Vector2 ppos;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        GetPlayerPosition();

    }

    // Update is called once per frame
    void Update()
    {
        if (!searching)
        {
            Patrol();
        }
        else
        {
            GetPlayerPosition();
            MoveTowardsPlayer();
        }
        //If not, walk towards the player.
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!recentlyTurned && !searching)
        {
            direction *= -1;
            recentlyTurned = true;
            //turnWait();
            recentlyTurned = false;
        }
    }
    private void Patrol()
    {
        rb.velocity = new Vector2(0, direction * speed); 
        //rb.AddForce(new Vector2(0, direction * speed * Time.deltaTime));
        //rb.AddForce(new Vector2(0, direction * speed * Time.deltaTime));
        //rb.MovePosition(rb.position + new Vector2(0, direction * speed * Time.deltaTime));
    }
    IEnumerator turnWait()
    {
        yield return new WaitForSeconds(0.05f);
    }
    private void GetPlayerPosition()
    {
        ppos = player.GetComponent<Transform>().position;

    }
    private void MoveTowardsPlayer()
    {
        Vector2 seekDirection = ppos - new Vector2(this.transform.position.x, this.transform.position.y);
        seekDirection = seekDirection.normalized;
        Vector2 seek = seekDirection * speed;
        rb.velocity = seek;
    }
    public void SetSearching() {
        searching = true;
    }
}
