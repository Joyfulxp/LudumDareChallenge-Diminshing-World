using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimVertical : MonoBehaviour {

    public GameObject player;
    public GameObject bulletEnemy, bulletReverseEnemy;
    public GameObject next, gemgreen, door1,door2;
    public ParticleSystem ps;
    public EnemyHP HP;

    public float AttackInterval = 3f;
    float time;
    float rnd;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        HP = GetComponentInChildren<EnemyHP>();
        ps = GetComponent<ParticleSystem>();
        ps.Pause();
        time = Time.time;
        bulletEnemy = (GameObject)Resources.Load("Prefabs/bulletEnemyVert");
        bulletReverseEnemy = (GameObject)Resources.Load("Prefabs/bulletReverseEnemyVert");

        gemgreen.SetActive(false);
        door1.SetActive(false);
        door2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (time + AttackInterval < Time.time)
        {
            time = Time.time;
            rnd = Random.Range(0, 1.0f);
            if (rnd < 0.2)
            {
                transform.Translate(new Vector3(0, 1.5f, 0) - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(30, 0, 0), Time.deltaTime);
                for (int i = 0; i < 10; i++)
                {
                    float rndy = Random.Range(-2.15f, -2f);
                    float rndx = Random.Range(-4f, 4f);
                    float direction = Mathf.Sign(Random.Range(-1f, 1f));
                    if (direction > 0)
                    {
                        Instantiate(bulletEnemy, new Vector3(rndx, direction * rndy, 0), Quaternion.identity);
                        
                    }
                    else
                    {
                        Instantiate(bulletReverseEnemy, new Vector3(rndx, direction * rndy, 0), Quaternion.identity);
                    }
                }
            }
            else if (rnd >= 0.2 && rnd < 0.4f)
            {
                transform.Translate(new Vector3(2.75f, 1f, 0) - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 30, 0), Time.deltaTime);
                for (int i = 0; i < 5; i++)
                {
                    float rndy = Random.Range(-2.15f, -2f);
                    float rndx = Random.Range(-4f, 4f);
                    Instantiate(bulletEnemy, new Vector3(rndx, rndy, 0), Quaternion.identity);
                }
            }
            else if (rnd >= 0.4 && rnd < 0.6f)
            {
                transform.Translate(new Vector3(-2.75f, 1f, 0) - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -30, 0), Time.deltaTime);
                for (int i = 0; i < 5; i++)
                {
                    float rndy = Random.Range(-2.15f, -2f);
                    float rndx = Random.Range(-4f, 4f);
                    Instantiate(bulletEnemy, new Vector3(rndx, rndy, 0), Quaternion.identity);
                }

            }
            else if (rnd >= 0.6 && rnd < 0.8f)
            {
                transform.Translate(new Vector3(-2f, -1f, 0) - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(30, 60, 0), Time.deltaTime);
                for (int i = 0; i < 20; i++)
                {
                    float rndy = Random.Range(2.15f, 3f);
                    float rndx = Random.Range(-4f, 4.25f);
                    Instantiate(bulletReverseEnemy, new Vector3(rndx, rndy, 0), Quaternion.identity);
                }

            }
            else
            {
                transform.Translate(new Vector3(2.75f, -1f, 0) - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(30, -60, 0), Time.deltaTime);
                for (int i = 0; i < 20; i++)
                {
                    float rndy = Random.Range(2.15f, 3f);
                    float rndx = Random.Range(-4f, 4.25f);
                    Instantiate(bulletReverseEnemy, new Vector3(rndx, rndy, 0), Quaternion.identity);
                }
            }
            if(GetComponentInChildren<EnemyHP>().HP<1)
            {
                player.GetComponent<BasicParams>().VerticalDefeated = true;
                GameObject border = GameObject.FindGameObjectWithTag("Border");
                border.GetComponent<ShrinkingBorders>().isShrinking = false;
                border.transform.localScale = new Vector3(1, 1, 1);
                gemgreen.SetActive(true) ;
                door1.SetActive(true);
                door2.SetActive(true);
                Destroy(next.gameObject);
            }
        }
        //transform.rotation = Quaternion.LookRotation(target.transform.position - transform.position);
    }
  
}


