using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossNameH : MonoBehaviour {

    public GameObject HPBar;
    public GameObject HPtext;
    float time;
    float lifeTime=1f;
    float clearTime = 2.5f;
    float alpha;

	// Use this for initialization
	void Start () {
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(time+lifeTime<Time.time)
        {
            alpha = Mathf.Lerp(255,0, Time.deltaTime);
            GetComponent<CanvasRenderer>().SetAlpha(alpha);
        }
        if(time+clearTime<Time.time)
        {
            HPBar.SetActive(true);
            HPtext.SetActive(true);
            Destroy(this.gameObject);
        }
	}
}
