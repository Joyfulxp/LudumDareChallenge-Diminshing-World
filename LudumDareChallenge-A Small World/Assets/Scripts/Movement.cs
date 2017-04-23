using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 0.01f;
    public bool faceRight=true;//true for right,false for left

    public Vector2 jump = new Vector2(0,0.0f);
    public bool canJump=true;
    public GameObject root;

    public Vector2 dash = new Vector2(15f,0);
    public bool canDash = true;

    public bool canDown = false;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow))//UP
        {
            if(GetComponent<BasicParams>().atDoor)
            {
                GetInDoor gid=GetComponent<BasicParams>().gm.GetComponent<GetInDoor>();
                gid.doorNum = GetComponent<BasicParams>().doorNum;
                gid.getInDoor(gid.doorNum);
                //playAnim
                //changeLevel
            }
            //transform.Translate(new Vector3(0, speed, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))//left
        {
            faceRight = false;
            transform.Translate(new Vector3(-speed, 0, 0)); 
        }   
        if (Input.GetKey(KeyCode.DownArrow))//down
        {
            if (canDown) { transform.Translate(new Vector3(0,-speed, 0));}
        }
        if (Input.GetKey(KeyCode.RightArrow))//right
        {
            faceRight = true;
            transform.Translate(new Vector3(speed,0,0));
        }
        if (Input.GetKey(KeyCode.Z))//dash
        {
            if (canDash)
            { GetComponent<Rigidbody2D>().AddForce(dash*(faceRight?1:-1)); }
        }
        if (Input.GetKeyDown(KeyCode.X)||Input.GetKeyDown(KeyCode.Space))//jump
        {
            if (canJump)
            {
                GetComponent<Rigidbody2D>().AddForce(jump);
                canJump = false;
            }
        }
            //RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector2.down, 0.2f,1<<8);
            //Debug.DrawRay(transform.position, Vector2.down, Color.green);




    }
}
