using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicParams : MonoBehaviour {

    public GameObject gm;
    public int HP;
    public int Seeds;
    public int speedLevel;
    public int jumpLevel;
    public int shootLevel;
    public int gemsCollected;
    public bool HorizonDefeated;
    public bool VerticalDefeated;
    public bool DeadlineDefeated;

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
        DeadlineDefeated = false;
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
            default: { Debug.Log("too many jump gems?"); break; }
        }
    }

    private void AdjustShoot(int shootLevel)
    {
        Shooting shot = GetComponent<Shooting>();
        switch (shootLevel)
        {
            case 1: { shot.canShoot = true; shot.bulletDamageMultiplier = 1.0f; break; }
            case 2: { shot.bulletDamageMultiplier = 2.0f; break; }
            case 3: { shot.bulletDamageMultiplier = 3.0f; break; }
            default: { Debug.Log("too many shoot gems?"); break; }
        }
    }
    public void UseSeed()
    {
        if(Seeds>0)
        { Seeds -= 1; }
        else
        { GameOver(); }
    }


    public void GameOver() { }
}
