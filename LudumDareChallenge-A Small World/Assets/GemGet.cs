using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGet : MonoBehaviour {

    public GameObject gm;
    public int level;//1 for 
    public int kind;//1 for speed,2 for jump,3 for shoot
	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            BasicParams bp = collision.GetComponent<BasicParams>();
            bp.getGem(kind);
            Destroy(this.gameObject);
        }
    }
 
}
