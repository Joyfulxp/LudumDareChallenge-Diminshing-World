using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BorderPlayerCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.GetComponent<BasicParams>().Seeds > 0)
            {
                collision.GetComponent<BasicParams>().Seeds -= 1;
                collision.transform.position = new Vector3(1, 1, 1);
                SceneManager.LoadScene("Shelter");
            }
            else
            { collision.GetComponent<BasicParams>().GameOver(); }
        }
    }
}
