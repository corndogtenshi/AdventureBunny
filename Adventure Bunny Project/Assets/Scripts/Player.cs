using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
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

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            playerAnimController.SetWalk();
            if (x > 0)
            {
                this.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if (Mathf.Abs(y) > Mathf.Abs(x))
        {

            if (y > 0)
            {
                playerAnimController.SetUp();
            }
            else
            {
                playerAnimController.SetDown();
            }
        }


        vel = new Vector2(x * speed, y*speed);

        //rb.velocity = vel;
        rb.velocity = vel;
        //rb.MovePosition(rb.position + new Vector2( * speed * Time.deltaTime, y * speed * Time.deltaTime));
        //transform.Translate(new Vector3(x, y, 0) * Time.deltaTime * speed);
    }
    private void ScreenWrap()
    {
        //Debug.Log(this.gameObject.transform.position.x);
        //Debug.Log(halfCameraWidth);
        if(this.gameObject.transform.position.x > 0.5 + halfCameraWidth)
        {
            this.gameObject.transform.position -= new Vector3((halfCameraWidth * 2), 0, 0);
        }
        else if (this.gameObject.transform.position.x < 0.5 - halfCameraWidth)
        {
            this.gameObject.transform.position += new Vector3((halfCameraWidth * 2), 0, 0);
        }
    }


}
