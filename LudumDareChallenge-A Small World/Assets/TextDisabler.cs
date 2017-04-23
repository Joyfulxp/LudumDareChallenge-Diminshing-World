using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDisabler : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<CanvasRenderer>().SetAlpha(0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
