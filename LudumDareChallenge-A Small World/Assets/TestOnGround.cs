using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Obstacles"||collision.tag=="Border")
        { transform.parent.GetComponent<Movement>().canJump = true; }
    }
}
