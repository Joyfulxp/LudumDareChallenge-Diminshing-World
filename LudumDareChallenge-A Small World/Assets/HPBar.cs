using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour {

    public GameObject boss;
    float maxHP;
	// Use this for initialization
	void Start () {
        maxHP = boss.GetComponentInChildren<EnemyHP>().HP;
	}
	
	// Update is called once per frame
	void Update () {
        if (boss != null)
        { GetComponent<Image>().fillAmount = boss.GetComponentInChildren<EnemyHP>().HP / maxHP; }
        if(boss==null)
        {
            GetComponent<Image>().fillAmount = 0;
        }
	}
}
