using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicParams : MonoBehaviour {

    public GameObject gm;
    public GameObject bomb;
    public Sprite substitute;
    public bool avatarChanged = false;
    public int HP;
    public int Seeds;
    public int speedLevel;
    public int jumpLevel;
    public int shootLevel;
    public int gemsCollected;
    public bool HorizonDefeated;
    public bool VerticalDefeated;
    //public bool DeadlineDefeated;

    public bool atDoor=false;
    public int doorNum;


    
	void Start () {
        gm = GameObject.Find("GameManager");
        HP = 3;
        Seeds = 0;
        speedLevel = 0;
        jumpLevel = 0;
        shootLevel = 0;
        gemsCollected = 0;
        HorizonDefeated = false;
        VerticalDefeated = false;
        //DeadlineDefeated = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void getGem(int kind)
    {
        if (kind > 0)
        {
            gemsCollected += 1;
            this.transform.localScale = new Vector3(gemsCollected, gemsCollected, 1);
            switch (kind)
            {
                case 1: { speedLevel += 1; AdjustSpeed(speedLevel); break; }
                case 2: { jumpLevel += 1; AdjustJump(jumpLevel); break; }
                case 3: { shootLevel += 1; AdjustShoot(shootLevel); break; }
                default: { Debug.Log("unknown Gem,pls check!"); break; }
            }
        }
    }
private void AdjustSpeed(int speedLevel)
    {
        Movement mov = GetComponent<Movement>();
        switch(speedLevel)
        {
            case 1: { mov.speed = 0.03f;break; }
            case 2: { mov.speed = 0.05f; break; }
            case 3: { mov.speed = 0.06f; break; }
            default: { Debug.Log("too many speed gems?"); break; }
        }
    }

    private void AdjustJump(int jumpLevel)
    {
        Movement mov = GetComponent<Movement>();
        switch (jumpLevel)
        {
            case 1: { mov.jump.y = 200f; break; }
            case 2: { mov.jump.y = 250f; break; }
            case 3: { mov.jump.y = 300f; break; }
            case 4: { mov.jump.y = 350f; break; }
            default: { Debug.Log("too many jump gems?"); break; }
        }
    }

    private void AdjustShoot(int shootLevel)
    {
        Shooting shot = GetComponent<Shooting>();
        switch (shootLevel)
        {
            case 1: { shot.canShoot = true; shot.bulletDamageMultiplier = 1; break; }
            case 2: { shot.bulletDamageMultiplier = 2; break; }
            case 3: { shot.bulletDamageMultiplier = 4; break; }
            case 4: { shot.bulletDamageMultiplier = 8; break; }
            case 5: { shot.bulletDamageMultiplier = 16; break; }
            default: { Debug.Log("too many shoot gems?"); break; }
        }
    }
    public void UseSeed()
    {
        if (Seeds > 0)
        { Seeds -= 1; }// GameObject[] god = GameObject.FindGameObjectsWithTag("Bullet");foreach (GameObject i in god) { Destroy(i); };Instantiate(bomb, transform.position, Quaternion.identity); }
        else
        { GameOver(); }
    }


    public void GameOver()
    {
        Destroy(gm);
        Destroy(GameObject.FindGameObjectWithTag("Border"));
        Destroy(this.gameObject);
        SceneManager.LoadScene("Main");
    }
}
