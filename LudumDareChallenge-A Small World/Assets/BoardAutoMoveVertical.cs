using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAutoMoveVertical : MonoBehaviour {

    public float speed = 1f;
    public int direction = 1;
    float time;
    float interval = 2f;

    // Use this for initialization
    void Start () {
        speed = Random.Range(0.5f, 1.0f);
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0,speed * direction * Time.deltaTime, 0);
        if (time + interval < Time.time)
        {
            time = Time.time;
            direction = -direction;
        }
    }
}
