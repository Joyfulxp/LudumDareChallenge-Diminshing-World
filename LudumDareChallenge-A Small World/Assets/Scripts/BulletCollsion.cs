using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollsion : MonoBehaviour {

    public float bulletSpeed=10f;
    public int bulletDamage=1;
    public int direction=1;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0); 
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
            collision.GetComponent<EnemyHP>().HP -= bulletDamage;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            other.GetComponent<EnemyHP>().HP -= bulletDamage;
            Destroy(this.gameObject);
        }
    }
}
