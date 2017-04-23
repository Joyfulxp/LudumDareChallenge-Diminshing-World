using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextActivator : MonoBehaviour {

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
            transform.parent.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        //StartCoroutine("wait2secs");
        transform.parent.GetComponent<CanvasRenderer>().SetAlpha(0.2f);
    }

    //IEnumerator wait2secs()
    //{
    //    yield return new WaitForSeconds(3f);
    //}
}
