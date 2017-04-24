using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShoot : MonoBehaviour {

    public GameObject bullet;
    float time;
    float interval=0.5f;
	// Use this for initialization
	void Start () {
        time = Time.time;
        GameObject bullet = (GameObject)Resources.Load("Prefabs/bullet");
	}
	
	// Update is called once per frame
	void Update () {
        if (time + interval < Time.time)
        {
            time = Time.time;
            Instantiate(bullet, transform.forward, Quaternion.identity);
        }
    }
}
