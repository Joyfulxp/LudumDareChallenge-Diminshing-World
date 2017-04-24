using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public float HP;
    public float HPLine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
		if(HP<1)
        {
            if (transform.parent.name.Contains("Boss"))
            {
                transform.parent.GetComponent<ParticleSystem>().Play();
                Destroy(transform.parent.gameObject, 3.0f);
            }
            else if(transform.name.Contains("board"))
            {
                Destroy(this.gameObject);
            }
            else if(transform.name.Contains("Turret"))
            {
                Destroy(this.gameObject);
            }
        }
	}
}
