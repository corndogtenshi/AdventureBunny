using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public Rigidbody2D rb; //Player's rigidbody.
    //public int speed = 35;
    public float speed = 0.1f;
    float hPressedTime = 0.0f;
    float vPressedTime = 0.0f;
    Vector2 vel;

    public Camera cam;
    private Vector3 cameraPos;
    private float halfCameraWidth;

    private PlayerAnimController playerAnimController;

    // Start is called before the first frame update
    void Start()
    {
        cameraPos = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
        halfCameraWidth = cam.orthographicSize;
        playerAnimController = GetComponent<PlayerAnimController>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ScreenWrap();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
        //Get button-down time for horizontal and vertical axis)
        if (x != 0)
        {
            if (hPressedTime == 0.0f)
            {
                hPressedTime = Time.time;
                //print(hPressedTime);
            }
        }
        else
        {
            hPressedTime = 0.0f;
        }
        if (y != 0)
        {
            if (vPressedTime == 0.0f)
            {
                vPressedTime = Time.time;
                print(vPressedTime);
            }
        }
        else
        {
            vPressedTime = 0.0f;
        }

        //Check if horizontal or vertical press was done first, change movement vector accordingly
        if (hPressedTime > vPressedTime)
        {
            vel = new Vector2(x * speed, 0);
            if (x > 0)
            {
                playerAnimController.SetWalk();
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (x < 0)
            {
                playerAnimController.SetWalk();
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }

        }
        else if (vPressedTime > hPressedTime)
        {
            vel = new Vector2(0, y * speed);
            if (y > 0)
            {
                playerAnimController.SetUp();
            }
            else if (y < 0)
            {
                playerAnimController.SetDown();
            }
        }


        //rb.velocity = vel;
        rb.velocity = vel;
        //rb.MovePosition(rb.position + new Vector2( * speed * Time.deltaTime, y * speed * Time.deltaTime));
        //transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * speed);
    }
    private void ScreenWrap()
    {
        //Debug.Log(this.gameObject.transform.position.x);
        //Debug.Log(halfCameraWidth);
        if(this.gameObject.transform.position.x > 13.5)
        {
            this.gameObject.transform.position -= new Vector3(25, 0, 0);
        }
        else if (this.gameObject.transform.position.x < -12.5)
        {
            this.gameObject.transform.position += new Vector3(25, 0, 0);
        }
    }


}
