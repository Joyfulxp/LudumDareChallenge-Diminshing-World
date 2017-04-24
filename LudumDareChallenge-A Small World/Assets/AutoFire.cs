using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{

    public GameObject bulletEnemy, bulletReverseEnemy;
    public float interval = 0.5f;
    public float time;
    public bool faceleft;
    public Transform shootPlace;
    // Use this for initialization
    void Start()
    {
        time = Time.time;
        bulletEnemy = (GameObject)Resources.Load("Prefabs/bulletEnemy");
        bulletReverseEnemy = (GameObject)Resources.Load("Prefabs/bulletReverseEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        if (time + interval < Time.time)
        {

            time = Time.time;
            if (faceleft)
            {
                GameObject blt = Instantiate(bulletReverseEnemy, shootPlace.transform.position, Quaternion.identity);
            }
            else
            {
                GameObject blt = Instantiate(bulletEnemy, shootPlace.transform.position, Quaternion.identity);
            }
        }
    }
}
