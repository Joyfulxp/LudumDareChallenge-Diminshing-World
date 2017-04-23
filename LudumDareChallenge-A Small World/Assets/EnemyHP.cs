using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour {

    public int HP;
    public int HPLine;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (HP <= HPLine)
        {
            Sprite sp = GetComponent<SpriteRenderer>().sprite;
            sp = Sprite.Create((Texture2D)Resources.Load("Backgrounds/boardBroken"),sp.textureRect,new Vector2(0.5f,0.5f));
                }
		if(HP<1)
        {
            Destroy(this.gameObject);
        }
	}
}
