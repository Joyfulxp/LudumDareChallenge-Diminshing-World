using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet,bulletReverse;
    public float interval=0.5f;
    public float time;
    public GameObject rightShoot,leftShoot;
    public int bulletDamageMultiplier=1;
    public bool canShoot=false;
	// Use this for initialization
	void Start () {
        time = Time.time;
        bullet =(GameObject)Resources.Load("Prefabs/bullet");
        bulletReverse = (GameObject)Resources.Load("Prefabs/bulletReverse");
    }
	
	// Update is called once per frame
	void Update () {
        if (time+interval < Time.time)
        {
            if (Input.GetKey(KeyCode.C)&&canShoot)//shoot
            {
                time =Time.time;
                if (GetComponent<Movement>().faceRight)
                {
                    GameObject blt=Instantiate(bullet, rightShoot.transform.position, Quaternion.identity);
                    blt.GetComponent<BulletCollsion>().bulletDamage *= bulletDamageMultiplier;
                }
                else
                {
                    GameObject blt = Instantiate(bulletReverse, leftShoot.transform.position, Quaternion.identity);
                    blt.GetComponent<BulletCollsion>().bulletDamage *= bulletDamageMultiplier;

                }

            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<BasicParams>().UseSeed();
        }
    }
}
