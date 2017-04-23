using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCondition2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int sl = collision.GetComponent<BasicParams>().speedLevel;
            if (sl < 5)
            {
                transform.parent.GetComponent<Text>().text = "Gem will give you power.";
            }
            else if (sl == 1)
            {
                transform.parent.GetComponent<Text>().text = "You are a little BIG for this world.";

            }
            else
            {
                transform.parent.GetComponent<Text>().text = " ";
            }
        }
    }
}
