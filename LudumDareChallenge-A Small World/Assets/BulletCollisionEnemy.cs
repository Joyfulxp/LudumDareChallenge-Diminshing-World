using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionEnemy : MonoBehaviour {

    public float bulletSpeed = 10f;
    public float bulletDamage = 1.0f;
    public int direction = 1;
    public bool isUpward = false;

    // Use this for initialization
    void Start()
    {
        if (!isUpward)
        { GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed * direction, 0); }
        if (isUpward)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, bulletSpeed * direction);
            transform.Rotate(0, 0, 90);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacles")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag == "Player")
        {
            collision.GetComponent<BasicParams>().HP -= 1;
            Destroy(this.gameObject);
        }
    }
}


