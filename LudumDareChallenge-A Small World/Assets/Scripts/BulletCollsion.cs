using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollsion : MonoBehaviour {

    public float bulletSpeed=10f;
    public float bulletDamage=1.0f;
    public int direction=1;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity =new Vector2(bulletSpeed*direction,0);
        Destroy(this.gameObject, 3.0f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Obstacles")
        {
            Destroy(this.gameObject);
        }
        if(collision.tag=="Enemy")
        {
            collision.GetComponent<EnemyParams>().HP -= 1;
            Destroy(this.gameObject);
        }
    }
}
