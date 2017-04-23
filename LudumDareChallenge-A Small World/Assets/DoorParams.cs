using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorParams : MonoBehaviour {

    public GameObject gm;
    public int DoorNum;
    public GameObject go;
    

	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager");
        GameObject go = GameObject.FindGameObjectWithTag("Border");
        go.GetComponent<ShrinkingBorders>().doors.Add(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
