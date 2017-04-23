using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMDontDestroyOnLoad : MonoBehaviour {

    public GameObject player, border;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(this.player);
        DontDestroyOnLoad(this.border);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
